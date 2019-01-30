using Sklep.Data_access_layer;
using Sklep.Infrastruktura;
using Sklep.Models;
using Sklep.View_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class ProduktyController : Controller
    {
        private ProduktyContext db = new ProduktyContext();

        // GET: Produkty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string nazwaKategorii, string searchQuery = null)
        {
            var kategoria = db.Kategorie.Include("Produkt").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategorii.ToUpper()).Single();
            var produkty = kategoria.Produkt.Where(a => (searchQuery == null ||
                                                   a.Nazwa.ToLower().Contains(searchQuery.ToLower())) &&
                                                   !a.Brak);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListaProduktow", produkty);
            }

            return View(produkty);
        }

        public ActionResult Szczegoly(int id)
        {
            var produkt = db.Produkty.Find(id);
            return View(produkt);
        }

        [ChildActionOnly]
        public ActionResult MenuKategorii()
        {
            var kategorie = db.Kategorie.ToList();
            return PartialView("_MenuKategorii", kategorie);
        }

        

       }
       

    }
