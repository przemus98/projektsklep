using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sklep.App_Start;
using Sklep.Data_access_layer;
using Sklep.Infrastruktura;
using Sklep.Models;
using Sklep.View_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ProduktyContext db = new ProduktyContext();

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsVM
            {
                Message = message,
                DaneUzytkownika = user.DaneUzytkownika
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "DaneUzytkownika")]DaneUzytkownika daneUzytkownika)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.DaneUzytkownika = daneUzytkownika;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        public ActionResult ListaZamowien()
        {
            IEnumerable<Zamowienie> zamowieniaUzytkownika;
            var userId = User.Identity.GetUserId();
            zamowieniaUzytkownika = db.Zamowienia.Where(o => o.UserId == userId).Include("PozycjeZamowienia").OrderByDescending(o => o.Data).ToArray();
            return View(zamowieniaUzytkownika);
        }

        public ActionResult ListaSprzedanychProduktów()
        {
            IEnumerable<Zamowienie> sprzedaneProdukty;
            var userId = User.Identity.GetUserId();
            sprzedaneProdukty = db.Zamowienia.Where(p => p.Sprzedawca == userId).Include("PozycjeZamowienia").OrderByDescending(o => o.Data).ToArray();
            return View(sprzedaneProdukty);
            
        }
        
        public ActionResult DodajProdukt(int? produktId, bool? potwierdzenie)
        {
            var userId = User.Identity.GetUserId();
            Produkt produkt;
            produkt = new Produkt();
            var result = new DodajProduktVM();
            produkt.Sprzedawca = userId;
            result.Kategorie = db.Kategorie.ToList();
            result.Produkt = produkt;
            result.Potwierdzenie = potwierdzenie;
            

            return View(result);
        }
        [HttpPost]
        public ActionResult DodajProdukt(DodajProduktVM model, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                if (ModelState.IsValid)
                {
                    var fileExt = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid() + fileExt;

                    var path = Path.Combine(Server.MapPath(AppConfig.obrazkiFolderWzgl), fileName);
                    file.SaveAs(path);

                    model.Produkt.NPO = fileName;

                    db.Entry(model.Produkt).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("DodajKurs", new { potwierdzenie = true });
                }
                else
                {
                    var kategorie = db.Kategorie.ToList();
                    model.Kategorie = kategorie;
                    return View(model);
                }

            }
            else
            {
                ModelState.AddModelError("", "Nie dodano pliku.");
                var kategorie = db.Kategorie.ToList();
                model.Kategorie = kategorie;
                return View(model);
            }
        }
    }
}