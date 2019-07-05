using sifaeczadeposu.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using sifaeczadeposu.Migrations;

namespace sifaeczadeposu.Controllers
{
    public class AdminController : Controller
    {
        private sifaeczadposuEntities db = new sifaeczadposuEntities();
       
        public ActionResult Index()
        {
            return View();
        }
        #region// kayit
        public ActionResult kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kaydol(uye s)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    uye _slide = new uye();
                    _slide.ad = s.ad;
                    _slide.soyad= s.soyad;
                    _slide.k_ad = s.k_ad;
                    _slide.sifre = s.sifre;
                    _slide.tel = s.tel;
                    _slide.cins = s.cins;
                    context.uye.Add(_slide);
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        #endregion
        #region// cıkıs
        public ActionResult cıkıs()
        {
            Session["k_ad"] = null;
            return RedirectToAction("Index", "Home");
     
        }

        #endregion
        #region// giris
        public ActionResult giris()
        {
            return View();
        }

        #endregion
        #region//giris
        [HttpPost]
        public ActionResult giris(uye model)
        { var Kullanici = db.uye.FirstOrDefault(x=>x.k_ad == model.k_ad);
            if (Kullanici != null)
            {
                Session["cins"] = "Admin";
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        #endregion
        #region // Slider
        public ActionResult Slider()
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var slider = context.Slider.ToList();
                return View(slider);
            }
        }
        public ActionResult SlideEkle()
        {
            return View();
        }
        public ActionResult SlideDuzenle(int SlideID)
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var _slideDuzenle = context.Slider.Where(x => x.ID == SlideID).FirstOrDefault();
                return View(_slideDuzenle);
            }
        }
        public ActionResult SlideSil(int SlideID)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    context.Slider.Remove(context.Slider.First(d => d.ID == SlideID));
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
       
        [HttpPost]
        public ActionResult SlideEkle(Slider s, HttpPostedFileBase file)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    Slider _slide = new Slider();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slide.SliderFoto = memoryStream.ToArray();
                    }
                    _slide.SliderText = s.SliderText;
                    _slide.BaslangicTarih = s.BaslangicTarih;
                    _slide.BitisTarih = s.BitisTarih;
                    context.Slider.Add(_slide);
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult SlideDuzenle(Slider slide, HttpPostedFileBase file)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    var _slideDuzenle = context.Slider.Where(x => x.ID == slide.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slideDuzenle.SliderFoto = memoryStream.ToArray();
                    }
                    _slideDuzenle.SliderText = slide.SliderText;
                    _slideDuzenle.BaslangicTarih = slide.BaslangicTarih;
                    _slideDuzenle.BitisTarih = slide.BitisTarih;
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region//Fuarlar
        public ActionResult Fuar()
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var fuar = context.fuar.ToList();
                return View(fuar);
            }
        }
        public ActionResult FuarEkle()
        {
            return View();
        }
        public ActionResult FuarDuzenle(int FuarID)
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var _FuarDuzenle = context.fuar.Where(x => x.ID == FuarID).FirstOrDefault();
                return View(_FuarDuzenle);
            }
        }
        public ActionResult FuarSil(int fuarID)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    context.fuar.Remove(context.fuar.First(d => d.ID == fuarID));
                    context.SaveChanges();
                    return RedirectToAction("fuar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult fuarEkle(fuar b)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    fuar _fuar = new fuar();
                    _fuar.fuaradi = b.fuaradi;
                    _fuar.aciklama = b.aciklama;
                    _fuar.tarih = DateTime.Now;
                    context.fuar.Add(_fuar);
                    context.SaveChanges();
                    return RedirectToAction("fuar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult fuarDuzenle(fuar b)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    var _fuarDuzenle = context.fuar.Where(x => x.ID == b.ID).FirstOrDefault();
                    
                    _fuarDuzenle.fuaradi = b.fuaradi;
                    _fuarDuzenle.aciklama = b.aciklama;
                    _fuarDuzenle.tarih = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("fuar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }
        #endregion
        #region // İlaclar

        public ActionResult Ilaclar()
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var ilaclar = context.ilaclar.ToList();
                return View(ilaclar);
            }
        }
        public ActionResult IlacEkle()
        {
            return View();
        }
        public ActionResult IlacDuzenle(int IlacID)
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var _ilacDuzenle = context.ilaclar.Where(x => x.ID == IlacID).FirstOrDefault();
                return View(_ilacDuzenle);
            }
        }
        public ActionResult IlacSil(int IlacID)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    context.ilaclar.Remove(context.ilaclar.First(d => d.ID == IlacID));
                    context.SaveChanges();
                    return RedirectToAction("Ilaclar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult IlacEkle(ilaclar m, HttpPostedFileBase file)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    ilaclar _ilac= new ilaclar();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _ilac.resim = memoryStream.ToArray();
                    }
                    _ilac.ilacadi = m.ilacadi;
                    _ilac.aciklama = m.aciklama;
                    _ilac.fiyat = m.fiyat;
                    _ilac.indirimorani = m.indirimorani;
                    context.ilaclar.Add(_ilac);
                    context.SaveChanges();
                    return RedirectToAction("Ilaclar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult IlacDuzenle(ilaclar m, HttpPostedFileBase file)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    var _ilacDuzenle = context.ilaclar.Where(x => x.ID == m.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _ilacDuzenle.resim = memoryStream.ToArray();
                    }
                    _ilacDuzenle.ilacadi = m.ilacadi;
                    _ilacDuzenle.aciklama = m.aciklama;
                    _ilacDuzenle.fiyat = m.fiyat;
                    _ilacDuzenle.indirimorani = m.indirimorani;
                    context.SaveChanges();
                    return RedirectToAction("Ilaclar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region//Duyurular
        public ActionResult Duyurular()
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var duyuru = context.duyurular.ToList();
                return View(duyuru);
            }
        }
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        public ActionResult DuyuruDuzenle(int DuyuruID)
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var _DuyuruDuzenle = context.duyurular.Where(x => x.ID == DuyuruID).FirstOrDefault();
                return View(_DuyuruDuzenle);
            }
        }
        public ActionResult DuyuruSil(int duyuruID)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    context.duyurular.Remove(context.duyurular.First(d => d.ID == duyuruID));
                    context.SaveChanges();
                    return RedirectToAction("Duyurular", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult DuyuruEkle(duyurular b)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    duyurular _duyuru = new duyurular();
                    _duyuru.duyuruadi = b.duyuruadi;
                    _duyuru.aciklama = b.aciklama;
                    _duyuru.tarih = DateTime.Now;
                    context.duyurular.Add(_duyuru);
                    context.SaveChanges();
                    return RedirectToAction("Duyurular", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult DuyuruDuzenle(duyurular b)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    var _duyuruDuzenle = context.duyurular.Where(x => x.ID == b.ID).FirstOrDefault();

                    _duyuruDuzenle.duyuruadi = b.duyuruadi;
                    _duyuruDuzenle.aciklama = b.aciklama;
                    _duyuruDuzenle.tarih = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("Duyurular", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }
        #endregion
        #region//OneriSikayet
        public ActionResult OneriSikayet()
        {
            using (sifaeczadposuEntities context = new sifaeczadposuEntities())
            {
                var onerisikayet = context.onerisikayet.ToList();
                return View(onerisikayet);
            }
        }
        public ActionResult OneriSikayetSil(int onerisikayetID)
        {
            try
            {
                using (sifaeczadposuEntities context = new sifaeczadposuEntities())
                {
                    context.onerisikayet.Remove(context.onerisikayet.First(d => d.ID == onerisikayetID));
                    context.SaveChanges();
                    return RedirectToAction("OneriSikayet", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        #endregion
    }
}
