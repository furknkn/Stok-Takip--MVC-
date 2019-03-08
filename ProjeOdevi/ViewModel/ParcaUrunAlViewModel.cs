using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjeOdevi.ViewModel
{
    public class ParcaUrunAlViewModel
    {
        public IEnumerable<Tbl_Kategori> Kategoriler { get; set; }
        public IEnumerable<Tbl_Firma> Firmalar { get; set; }
        public Tbl_Urun urun { get; set; }
    }
}