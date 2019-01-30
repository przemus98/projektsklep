using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class DaneUzytkownika
    {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Ulica { get; set; }
            public string Miasto { get; set; }
            public string KodPocztowy { get; set; }

        [EmailAddress(ErrorMessage = "Błędny adres Email.")]
            public string Email { get; set; }
    }
}