using ProjeOdevi.Models;
using ProjeOdevi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using ProjeOdevi.Security;

namespace ProjeOdevi.Controllers
{

    [Authorize(Roles = "Admin,SatisYetkilisi")]
    public class SatinAlController : Controller
    {
        ProjeOdeviDbEntities db = new ProjeOdeviDbEntities();
        // GET: SatınAl
        [HttpGet]
        public ActionResult ParcaUrunAl()
        {

            var model = new ParcaUrunAlViewModel()
            {
                Kategoriler = db.Tbl_Kategori.ToList(),
                Firmalar = db.Tbl_Firma.ToList()
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult ParcaUrunAlHata()
        {
            ViewBag.Hata = "*Ürün eklenemedi! Girmiş olduğunuz barkot numarası başka bir ürüne ait.";
            var model = new ParcaUrunAlViewModel()
            {
                Kategoriler = db.Tbl_Kategori.ToList(),
                Firmalar = db.Tbl_Firma.ToList()
            };
            return View("ParcaUrunAl", model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ParcaUrunAl(Tbl_Urun urun)
        {
            Tbl_Urun BarkotNoKontrol = db.Tbl_Urun.FirstOrDefault(x => x.BarkotNo == urun.BarkotNo);
            if (urun.UrunId == 0)
            {
                if (BarkotNoKontrol != null && (BarkotNoKontrol.Adi != urun.Adi || BarkotNoKontrol.KategoriID != urun.KategoriID))
                {
                    return RedirectToAction("ParcaUrunAlHata");
                }
                if (urun.KategoriID == 1)
                {
                    urun.SatinAlmaTarihi = DateTime.Now;
                    //urun.ArizaliMi = false;
                    urun.ZimmetDurumu = true;
                    urun.HazirPcMi = true;
                    urun.ParcaEklendiMi = false;
                    urun.BirimFiyat = urun.ToptanFiyat / urun.Adet;
                    db.Tbl_Urun.Add(urun);
                    db.SaveChanges();
                    return RedirectToAction("HazirPcAL", "SatinAl");
                }
                urun.SatinAlmaTarihi = DateTime.Now;
                //urun.ArizaliMi = false;
                urun.ZimmetDurumu = false;
                urun.HazirPcMi = false;
                urun.BirimFiyat = urun.ToptanFiyat / urun.Adet;
                db.Tbl_Urun.Add(urun);
            }
            db.SaveChanges();
            return RedirectToAction("Stok", "Stok");
        }
        [HttpGet]
        public ActionResult HazirPcAl()
        {
            var model = new HazirPcAlViewModel()
            {
                Kategoriler = db.Tbl_Kategori.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult HazirPcAl(HazirPcAlViewModel parca)
        {
            var model = new HazirPcAlViewModel()
            {
                urunler = db.Tbl_Urun.ToList()
            };
            var id = model.urunler.Last();
            int BilgisayarID = id.UrunId;

            Tbl_Urun UrunBarkotNo = db.Tbl_Urun.FirstOrDefault(x => x.UrunId == BilgisayarID);

            if (UrunBarkotNo.HazirPcMi == false || UrunBarkotNo.ParcaEklendiMi == true)
            {
                ViewBag.mesaj = "*Bilgisayar Eklme sırasında hata meydana geldi.";
                return View();
            }
            else
            {
                UrunBarkotNo.ParcaEklendiMi = true;
                for (int i = 0; i < UrunBarkotNo.Adet; i++)
                {
                    UrunBarkotNo.ZimmetDurumu = false;
                    Tbl_HazirPcParcalari hpRam = new Tbl_HazirPcParcalari();
                    hpRam.ParcaAdi = parca.Ram.ParcaAdi;
                    hpRam.KategoriID = 2;
                    hpRam.UrunID = BilgisayarID;
                    hpRam.BarkotNo = UrunBarkotNo.BarkotNo;
                    db.Tbl_HazirPcParcalari.Add(hpRam);

                    Tbl_HazirPcParcalari hpHardDisk = new Tbl_HazirPcParcalari();
                    hpHardDisk.ParcaAdi = parca.HardDisk.ParcaAdi;
                    hpHardDisk.KategoriID = 3;
                    hpHardDisk.UrunID = BilgisayarID;
                    hpHardDisk.BarkotNo = UrunBarkotNo.BarkotNo;
                    db.Tbl_HazirPcParcalari.Add(hpHardDisk);

                    Tbl_HazirPcParcalari hpEkranKarti = new Tbl_HazirPcParcalari();
                    hpEkranKarti.ParcaAdi = parca.EkranKarti.ParcaAdi;
                    hpEkranKarti.KategoriID = 4;
                    hpEkranKarti.UrunID = BilgisayarID;
                    hpEkranKarti.BarkotNo = UrunBarkotNo.BarkotNo;
                    db.Tbl_HazirPcParcalari.Add(hpEkranKarti);

                    Tbl_HazirPcParcalari hpAnaKart = new Tbl_HazirPcParcalari();
                    hpAnaKart.ParcaAdi = parca.AnaKart.ParcaAdi;
                    hpAnaKart.KategoriID = 5;
                    hpAnaKart.UrunID = BilgisayarID;
                    hpAnaKart.BarkotNo = UrunBarkotNo.BarkotNo;
                    db.Tbl_HazirPcParcalari.Add(hpAnaKart);

                    db.SaveChanges();
                }

                return RedirectToAction("Stok", "Stok");
            }
        }
    }
}