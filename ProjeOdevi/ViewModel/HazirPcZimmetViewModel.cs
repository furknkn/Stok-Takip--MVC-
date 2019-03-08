using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjeOdevi.ViewModel
{
    public class HazirPcZimmetViewModel
    {
        public Tbl_HazirPcParcalari HazirPcParcalari { get; set; }
        public IEnumerable<Tbl_Urun> HazirPc { get; set; }
        public List<Tbl_Urun> Zimmetsiz { get; set; }
        public Tbl_Zimmet Tbl_Zimmet { get; set; }
        public IEnumerable<Tbl_Kullanici> Kullanicilar { get; set; }
    }
}