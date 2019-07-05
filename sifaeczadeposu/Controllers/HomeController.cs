using sifaeczadeposu.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sifaeczadeposu.Controllers
{

    public class HomeController : Controller
    {

        sifaeczadposuEntities db = new sifaeczadposuEntities();
        public ActionResult Index()
        { return View();
           
        }
        public ActionResult ilaclar()
        {
            var model = db.ilaclar.ToList();
            ViewBag.Message = "Your application ilaçlar page.";

            return View(model);
        }
        public ActionResult fuarlar()
        {
            var model = db.fuar.ToList();
            ViewBag.Message = "Your application fuarlar page.";

            return View(model);
        }

        public ActionResult hakkimizda()
        {
            ViewBag.Message = "BİZ KİMİZ?";

            return View();
        }

        public ActionResult iletisim()
        {
            ViewBag.Message = "İLETİŞİM BİLGİLERİMİZ:";

            return View();
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

        public class AnaSayfaDTO
        {
            public List<ilaclar> ilac { get; set; }
            public List<fuar> fuar { get; set; }
           
        }
    }
}