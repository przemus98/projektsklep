using Sklep.Data_access_layer;
using Sklep.Models;
using Sklep.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class HomeController : Controller
    {
        private ProduktyContext db = new ProduktyContext();


        public ActionResult Index()
        {
            var kategorie = db.Kategorie.ToList();

            var vm = new GlownaVM()
            {
                Kategorie = kategorie
            };
            
            return View(vm);
        }
        
    }
}