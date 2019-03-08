using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOdevi.ViewModel
{
    public class ZimmetFormViewModel
    {
        public IEnumerable<Tbl_Urun> Urunler { get; set; }
        public List<Tbl_Urun> Zimmetsiz { get; set; }
        public List<Tbl_Kullanici> Kullanicilar { get; set; }
        public List<Tbl_Kullanici> BirimKullanicilari { get; set; }
        public Tbl_Zimmet Tbl_Zimmet { get; set; }
        public string Bolum { get; set; }
    }
}