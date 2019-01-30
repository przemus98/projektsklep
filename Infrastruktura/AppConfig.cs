using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Sklep.Infrastruktura
{
    public class AppConfig
    {
        private static string _ikonyKategoriiFolderWzgl = ConfigurationManager.AppSettings["IkonaKategoriiFolder"];

        public static string ikonyKategoriiFolderWzgl
        {
            get
            {
                return _ikonyKategoriiFolderWzgl;
            }
        }
    

        private static string _obrazkiFolderWzgl = ConfigurationManager.AppSettings["ObrazkiFolder"];

        public static string obrazkiFolderWzgl
        {
            get
            {
                return _obrazkiFolderWzgl;
            }
        }
}
}