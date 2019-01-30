using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.View_Model
{
    public class GlownaVM
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
    }
}