using System;
using System.Collections.Generic;
using System.Text;

namespace Allinox
{
    public class SelectedArtikel
    {
        public int SelectArtikel { get; set; }
        public string SelectArtikelNaam { get; set; }

        public SelectedArtikel(string artikelnr, string artikelomschrijving)
        {
            SelectArtikel = int.Parse(artikelnr);
            SelectArtikelNaam = artikelomschrijving;
        }
    }
}
