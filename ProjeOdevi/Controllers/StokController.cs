using ProjeOdevi.Models;
using ProjeOdevi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ProjeOdevi.Controllers
{
    [Authorize]
    public class StokController : Controller
    {
        ProjeOdeviDbEntities db = new ProjeOdeviDbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Stok()
        {
            var model = db.Tbl_Urun.Include(x=>x.Tbl_Kategori).ToList();
            return View(model);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult ArizaliUrunler()
        {
            var model = db.Tbl_Zimmet.Include(x=>x.Tbl_Urun).ToList();
            return View(model);
        }

        
    }
}