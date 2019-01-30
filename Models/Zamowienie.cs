using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class Zamowienie
    {
        public int ZamowienieId { get; set; }
        [Required(ErrorMessage = "Wprowadź swoje imię.")]
        [StringLength(50)]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Wprowadź swoje nazwisko.")]
        [StringLength(50)]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Podaj swój adres (ulicę).")]
        [StringLength(50)]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Podaj swój adres (miasto).")]
        [StringLength(50)]
        public string Miasto { get; set; }
        [Required(ErrorMessage = "Podaj swój kod pocztowy.")]
        [StringLength(6)]
        public string KodPocztowy { get; set; }
        [Required(ErrorMessage = "Podaj swój adres email.")]
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public Stan Stan {get; set; }
        public decimal WartoscZamowienia { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Sprzedawca { get; set; }

        public List<PozycjaZamowienia> PozycjeZamowienia { get; set; }
    }
    public enum Stan
    {
        Nowe,
        Zrealizowane
    }
}