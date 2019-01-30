using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        [Required(ErrorMessage = "Podaj nazwę kategorii.")]
        [StringLength(30)]
        public string NazwaKategorii { get; set; }
        public string NPI { get; set; }

        public virtual ICollection<Produkt> Produkt { get; set; }

    }
}