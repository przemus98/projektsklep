using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public int KategoriaId { get; set; }
        [Required(ErrorMessage ="Wprowadź nazwę produktu.")]
        [StringLength(30)]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Podaj cenę.")]
        public decimal Cena { get; set; }
        [Required(ErrorMessage = "Podaj ilość.")]
        public int IloscProd { get; set; }
        [StringLength(100)]
        public string NPO { get; set; }
        public string Opis { get; set; }
        public int KoszykId { get; set; }
        public bool Brak { get; set; }
        public string Sprzedawca { get; set; }
        
        public virtual Kategoria Kategoria { get; set; }
    }
}