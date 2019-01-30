using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sklep.Models;
using Sklep.Migrations;
using System.Data.Entity.Migrations;

namespace Sklep.Data_access_layer
{
    public class ProduktyInitializer : MigrateDatabaseToLatestVersion<ProduktyContext, Configuration>
    {
        public static void SeedProduktyData(ProduktyContext context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId=1, NazwaKategorii="Elektronika", NPI="elektronika.png" },
                new Kategoria() {KategoriaId=2, NazwaKategorii="Moda", NPI="moda.png"},
                new Kategoria() {KategoriaId=3, NazwaKategorii="Dom i ogród", NPI="domiogrod.png"},
                new Kategoria() {KategoriaId=4, NazwaKategorii="Dziecko", NPI="dziecko.png"},
                new Kategoria() {KategoriaId=5, NazwaKategorii="Kultura i rozrywka", NPI="kulturairozrywka.png"},
                new Kategoria() {KategoriaId=6, NazwaKategorii="Sport", NPI="sport.png"},
                new Kategoria() {KategoriaId=7, NazwaKategorii="Uroda", NPI="uroda.png"},
                new Kategoria() {KategoriaId=8, NazwaKategorii="Motoryzacja", NPI="motoryzacja.png" },

                
            };
            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
                context.SaveChanges();

            var produkty = new List<Produkt>
            {
                new Produkt() {ProduktId=1, KategoriaId=1, IloscProd=10, Cena=2000, Nazwa="Super szybki komputer ekstra", NPO="komputer.png", Opis="Ten komputer wyleczył mnie z raka" },
                new Produkt() {ProduktId=2, KategoriaId=2, IloscProd=80, Cena=79, Nazwa="Jeansy prawie jak z Pewexu", NPO="jeansy.png"},
                new Produkt() {ProduktId=3, KategoriaId=5, IloscProd=24, Cena=29, Nazwa="Steezy - Calm Songs (2019)", NPO="steezy.jpg", Opis="Kompilacja utworów do nauki/spania."},
                new Produkt() {ProduktId=4, KategoriaId=5, IloscProd=25, Cena=39, Nazwa="Top muzyka kompilacja", NPO="muzykahehe.png", Opis="Niezłe nutki do wrzucenia na słuchaweczki."},
                new Produkt() {ProduktId=5, KategoriaId=4, IloscProd=1, Cena=1, Nazwa="Popek - uszkodzone", NPO="popek.jpg", Opis="Sprzedaję jako uszkodzone, nie działa jak powinien."},
                new Produkt() {ProduktId=6, KategoriaId=5, IloscProd=19, Cena=19, Nazwa="Zimbabwe best music", NPO="zimbabwe.png", Opis="Good music for good people."}
            };
            produkty.ForEach(p => context.Produkty.AddOrUpdate(p));
                context.SaveChanges();
        }
    }
}