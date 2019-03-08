using ProjeOdevi.Models;
using ProjeOdevi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjeOdevi.Security;

namespace ProjeOdevi.Controllers
{
    public class ZimmetController : Controller
    {
        ProjeOdeviDbEntities db = new ProjeOdeviDbEntities();
        KullaniciRoleProvider k = new KullaniciRoleProvider();
        // GET: Zimmet
        public ActionResult ParcaUrunZimmet()
        {
            var isim = k.BolumGetir(User.Identity.Name);
            var model = new ZimmetFormViewModel()
            {
                Urunler = db.Tbl_Urun.ToList(),
                BirimKullanicilari = db.Tbl_Kullanici.ToList(),
                Kullanicilar = db.Tbl_Kullanici.ToList(),
                Zimmetsiz = db.Tbl_Urun.ToList(),
                Bolum = isim[0].ToString()
            };
            return View(model);
        }

        public ActionResult ParcaUrunZimmetle(ZimmetFormViewModel model)
        {
            if (model.Tbl_Zimmet.ZimmetId == 0)
            {
                Tbl_Urun ZimmetlenecekUrun = db.Tbl_Urun.FirstOrDefault(x => x.UrunId == model.Tbl_Zimmet.UrunID);
                ZimmetlenecekUrun.Adet--;
                if (ZimmetlenecekUrun.Adet == 0)
                {
                    ZimmetlenecekUrun.ZimmetDurumu = true;
                }
                ZimmetlenecekUrun.ToptanFiyat = ZimmetlenecekUrun.ToptanFiyat - ZimmetlenecekUrun.BirimFiyat;

                Tbl_Zimmet Zimmetle = model.Tbl_Zimmet;
                Zimmetle.KullaniciID = model.Tbl_Zimmet.KullaniciID;
                Zimmetle.UrunID = model.Tbl_Zimmet.UrunID;
                Zimmetle.ArizaDurmu = false;
                Zimmetle.HazirPcParcalariID = null;
                db.Tbl_Zimmet.Add(Zimmetle);
                db.SaveChanges();
            }
            return RedirectToAction("ZimmetListesi");
        }

        public ActionResult HazirPcZimmet()
        {
            var model = new HazirPcZimmetViewModel()
            {
                HazirPc = db.Tbl_Urun.ToList(),
                Kullanicilar = db.Tbl_Kullanici.ToList(),
                Zimmetsiz = db.Tbl_Urun.ToList()
            };
            return View(model);
        }

        public ActionResult HazirPcZimmetle(HazirPcZimmetViewModel model)
        {
            if (model.Tbl_Zimmet.ZimmetId == 0)
            {
                Tbl_HazirPcParcalari ParcaZimmet = db.Tbl_HazirPcParcalari.FirstOrDefault(x => x.UrunID == model.Tbl_Zimmet.UrunID);
                int HazirPcParcalariID = ParcaZimmet.HazirPcParcalariId;
                Tbl_Urun ZimmetlenecekUrun = db.Tbl_Urun.FirstOrDefault(x => x.UrunId == model.Tbl_Zimmet.UrunID);
                ZimmetlenecekUrun.Adet--;
                if (ZimmetlenecekUrun.Adet==0)
                {
                    ZimmetlenecekUrun.ZimmetDurumu = true;
                }
                for (int i = 0; i < 4; i++)
                {
                    Tbl_Zimmet Zimmetle = model.Tbl_Zimmet;
                    Zimmetle.KullaniciID = model.Tbl_Zimmet.KullaniciID;
                    Zimmetle.UrunID = model.Tbl_Zimmet.UrunID;
                    Zimmetle.HazirPcParcalariID = HazirPcParcalariID;
                    Zimmetle.ArizaDurmu = false;
                    db.Tbl_Zimmet.Add(Zimmetle);
                    db.SaveChanges();
                    HazirPcParcalariID++;
                }
            }
            return RedirectToAction("Zimmetlistesi");
        }


        public ActionResult ZimmetListesi()
        {
            var model = db.Tbl_Zimmet.ToList();
            return View(model);
        }

        public ActionResult Arizalandi(int id)
        {
            var ZimmettenSil = db.Tbl_Zimmet.Find(id);
            ZimmettenSil.ArizaDurmu = true;
            db.SaveChanges();

            return RedirectToAction("ArizaliUrunler","Stok");
        }
    }
}