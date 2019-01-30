using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Infrastruktura
{
    public static class HelpUrl
    {
        public static string SciezkaIkonyKateg(this UrlHelper helper, string nazwaIkonyKateg)
        {
            var IkonyKategoriiFolder = AppConfig.ikonyKategoriiFolderWzgl;
            var sciezka = Path.Combine(IkonyKategoriiFolder, nazwaIkonyKateg);
            var sciezkaBezwzgl = helper.Content(sciezka);


            return sciezkaBezwzgl;
        }

        public static string SciezkaObrazka(this UrlHelper helper, string nazwaObrazka)
        {
            var ObrazkiFolder = AppConfig.obrazkiFolderWzgl;
            var sciezka = Path.Combine(ObrazkiFolder, nazwaObrazka);
            var sciezkaBezwzgl = helper.Content(sciezka);


            return sciezkaBezwzgl;
        }
    }
}