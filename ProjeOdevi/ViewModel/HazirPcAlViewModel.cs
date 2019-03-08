using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOdevi.ViewModel
{
    public class HazirPcAlViewModel
    {
        public Tbl_HazirPcParcalari Ram { get; set; }
        public Tbl_HazirPcParcalari HardDisk { get; set; }
        public Tbl_HazirPcParcalari EkranKarti { get; set; }
        public Tbl_HazirPcParcalari AnaKart { get; set; }
        public IEnumerable<Tbl_Kategori> Kategoriler { get; set; }
        public IEnumerable<Tbl_Urun> urunler { get; set; }
    }
}