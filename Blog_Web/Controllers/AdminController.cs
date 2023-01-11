using Blog_Web.Models.classes;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Blog_Web.Controllers
{
    public class AdminController : Controller
    {
       
        Context c=new Context();

        public ActionResult Index()
        {
            return View();
        }

        //Slider işlemleri

        public ActionResult sliderlist(int sayfa = 1)
        {
            // var listele = c.Sliders.ToPagedList<Slider>(sayfa, 5);
            var listele = c.Sliders.OrderByDescending(x => x.SliderID).ToPagedList<Slider>(sayfa, 5);
            return View(listele);
        }

        [HttpGet] //İstek atma
        public ActionResult SliderGetir(int id)
        {
            var slidergetir = c.Sliders.Find(id);
            return View("SliderGetir", slidergetir);
        }

        [HttpPost] //İsteğe cevap verme
        public ActionResult SliderGuncelle(Slider slider, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid) //Kontrol Mekanizmasıdır
            {
                var sliderıd = c.Sliders.Find(slider.SliderID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    sliderıd.Image = "~/Content/img/" + dosya.FileName;
                }
                sliderıd.Title = slider.Title;
                sliderıd.Description = slider.Description;
                sliderıd.ButtonName = slider.ButtonName;
                sliderıd.ButtonLink = slider.ButtonLink;
            }
            c.SaveChanges();
            return View("Index");
        }

        //Slider işlemleri Son

        //About işlemleri

        public ActionResult aboutlist(int sayfa=1)
        {
            var liste = c.Abouts.OrderByDescending(x => x.AboutID).ToPagedList<About>(sayfa, 5);
            return View(liste);
        }

        [HttpGet]
        public ActionResult AboutGetir(int id)
        {
            var aboutgetir = c.Abouts.Find(id);
            return View("AboutGetir",aboutgetir);
        }

        [HttpPost]
        public ActionResult aboutguncelle(About about, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid) //Kontrol Mekanizmasıdır
            {
                var aboutıd = c.Abouts.Find(about.AboutID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    about.Image = "~/Content/img/" + dosya.FileName;
                }
                aboutıd.Tittle = about.Tittle;
                aboutıd.Tittle2 = about.Tittle2;
                aboutıd.Description = about.Description;
            }
            c.SaveChanges();
            return View("Index");

        }

        [HttpGet]
        public ActionResult yeniabout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniabout(About about, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(path);
                c.Abouts.Add(new About
                {
                    AboutID = about.AboutID,
                    Tittle = about.Tittle,
                    Description = about.Description,
                    Tittle2 = about.Tittle2,
                    Image = "~/Content/img/" + dosya.FileName,

                });
                c.SaveChanges();
            }
            return View("Index");
        }

        //About İşlemleri Son

        //Yazı İşlemleri

        public ActionResult yazilist(int sayfa = 1)
        {
            var liste = c.Texts.OrderByDescending(x => x.TextID).ToPagedList<Text>(sayfa, 5);
            return View(liste);
        }

        [HttpGet]
        public ActionResult yaziGetir(int id)
        {
            var yazigetir = c.Texts.Find(id);
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View("yaziGetir", yazigetir);

        }

        [HttpPost]
        public ActionResult yaziGüncelle(Text text,HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid) //Kontrol Mekanizmasıdır
            {
                var textıd = c.Texts.Find(text.TextID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    text.Image = "~/Content/img/" + dosya.FileName;
                }
                textıd.Title = text.Title;
                textıd.Description = text.Description;
                textıd.TextDate = text.TextDate;
                textıd.CoverLetter = text.CoverLetter;
                textıd.CategoryID = text.CategoryID;
                textıd.IsActive = true;
            }
            c.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult yeniYazi()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public ActionResult yeniYazi(Text text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(path);
                c.Texts.Add(new Text
                {
                    TextID = text.TextID,
                    Title = text.Title,
                    Description = text.Description,
                    TextDate = text.TextDate,
                    CoverLetter = text.CoverLetter,
                    IsActive = true,
                    CategoryID=text.CategoryID,
                    Image = "~/Content/img/" + dosya.FileName,

                }) ;
                
            }
            c.SaveChanges();
            return View("Index");
        }

        public ActionResult yaziSil(int id)
        {
            var s = c.Texts.Find(id);
            s.IsActive = false;
            c.SaveChanges();
            return View("Index");
        }

        //Yazı İşlemleri Son

        //Siber Yazı İşlemleri

        public ActionResult siberyazilist(int sayfa = 1)
        {
            var liste = c.SiberTexts.OrderByDescending(x => x.SiberTextID).ToPagedList<SiberText>(sayfa, 6);
            return View(liste);
        }

        [HttpGet]
        public ActionResult siberyaziGetir(int id)
        {
            var siberyazigetir = c.SiberTexts.Find(id);
            return View("siberyaziGetir", siberyazigetir);

        }

        [HttpPost]
        public ActionResult siberyaziGüncelle(SiberText text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid) //Kontrol Mekanizmasıdır
            {
                var siberıd = c.SiberTexts.Find(text.SiberTextID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    text.Image = "~/Content/img/" + dosya.FileName;
                }
                siberıd.Title = text.Title;
                siberıd.Description = text.Description;
                siberıd.TextDate = text.TextDate;
                siberıd.CoverLetter = text.CoverLetter;
                siberıd.IsActive = true;
                siberıd.Image = text.Image;
                siberıd.source2 = text.source2;
                siberıd.source3 = text.source3;
                siberıd.source4 = text.source4;
                siberıd.source5 = text.source5;
                siberıd.source6 = text.source6;
                siberıd.source1 = text.source1;

                
            }

            c.SaveChanges();
            return View("Index");
        }


        [HttpGet]
        public ActionResult siberyeniYazi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult siberyeniYazi(SiberText text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(path);
                c.SiberTexts.Add(new SiberText
                {
                    SiberTextID= text.SiberTextID,
                    Title = text.Title,
                    Description = text.Description,
                    TextDate = text.TextDate,
                    CoverLetter = text.CoverLetter,
                    IsActive = true,
                    source1=text.source1,
                    source2=text.source2,
                    source3=text.source3,   
                    source4=text.source4,   
                    source5=text.source5,
                    source6=text.source6,
                    Image = "~/Content/img/" + dosya.FileName,

                });

            }
            c.SaveChanges();
            return View("Index");
        }

        public ActionResult siberyaziSil(int id)
        {
            var s = c.SiberTexts.Find(id);
            s.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("siberyazilist");
        }

        //Siber Yazı İşlemleri Son

        //Sistem Yazı İşlemleri 
        public ActionResult sistemyazilist(int sayfa = 1)
        {
            var liste = c.SistemTexts.OrderByDescending(x => x.SistemTextID).ToPagedList<SistemText>(sayfa, 6);
            return View(liste);
        }

        [HttpGet]
        public ActionResult sistemyaziGetir(int id)
        {
            var sistemyazigetir = c.SistemTexts.Find(id);
            return View("sistemyaziGetir", sistemyazigetir);

        }

        [HttpPost]
        public ActionResult sistemyaziGüncelle(SistemText text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid) //Kontrol Mekanizmasıdır
            {
                var sistemıd = c.SistemTexts.Find(text.SistemTextID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    text.Image = "~/Content/img/" + dosya.FileName;
                }
                sistemıd.Title = text.Title;
                sistemıd.Description = text.Description;
                sistemıd.TextDate = text.TextDate;
                sistemıd.CoverLetter = text.CoverLetter;
                sistemıd.IsActive = true;
                sistemıd.source1 = text.source1;
                sistemıd.source2 = text.source2;
                sistemıd.source3 = text.source3;
                sistemıd.source4 = text.source4;
                sistemıd.source5 = text.source5;
                sistemıd.source6 = text.source6;

            }
            c.SaveChanges();
            return RedirectToAction("sistemyazilist");
        }

        [HttpGet]
        public ActionResult sistemyeniYazi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sistemyeniYazi(SistemText text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(path);
                c.SistemTexts.Add(new SistemText
                {
                    SistemTextID = text.SistemTextID,
                    Title = text.Title,
                    Description = text.Description,
                    TextDate = text.TextDate,
                    CoverLetter = text.CoverLetter,
                    IsActive = true,
                    Image = "~/Content/img/" + dosya.FileName,
                    source1= text.source1,
                    source2= text.source2,
                    source3= text.source3,
                    source4= text.source4,
                    source5= text.source5,
                    source6= text.source6,

                });

            }
            c.SaveChanges();
            return RedirectToAction("sistemyazilist");
        }

        public ActionResult sistemyaziSil(int id)
        {
            var s = c.SistemTexts.Find(id);
            s.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("sistemyazilist");
        }

        //Sistem Yazı İşlemleri son

        //Network Yazı İşlemleri
        public ActionResult networkyazilist(int sayfa = 1)
        {
            var liste = c.NetworkTexts.OrderByDescending(x => x.NetworkTextID).ToPagedList<NetworkText>(sayfa, 6);
            return View(liste);
        }

        [HttpGet]
        public ActionResult networkyaziGetir(int id)
        {
            var networkyazigetir = c.NetworkTexts.Find(id);
            return View("networkyaziGetir", networkyazigetir);

        }

        [HttpPost]
        public ActionResult networkyaziGüncelle(NetworkText text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid) //Kontrol Mekanizmasıdır
            {
                var networkıd = c.NetworkTexts.Find(text.NetworkTextID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    text.Image = "~/Content/img/" + dosya.FileName;
                }
                networkıd.Title = text.Title;
                networkıd.Description = text.Description;
                networkıd.TextDate = text.TextDate;
                networkıd.CoverLetter = text.CoverLetter;
                networkıd.IsActive = true;
                networkıd.source1 = text.source1;
                networkıd.source2 = text.source2;
                networkıd.source3 = text.source3;
                networkıd.source4 = text.source4;
                networkıd.source5 = text.source5;
                networkıd.source6 = text.source6;
            }
            c.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult networkyeniYazi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult networkyeniYazi(NetworkText text, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(path);
                c.NetworkTexts.Add(new NetworkText
                {
                    NetworkTextID = text.NetworkTextID,
                    Title = text.Title,
                    Description = text.Description,
                    TextDate = text.TextDate,
                    CoverLetter = text.CoverLetter,
                    IsActive = true,
                    Image = "~/Content/img/" + dosya.FileName,
                    source1= text.source1,
                    source2= text.source2,
                    source3= text.source3,
                    source4= text.source4,
                    source5 = text.source5,
                    source6 = text.source6,

                });

            }
            c.SaveChanges();
            return View("Index");
        }

        public ActionResult networkyaziSil(int id)
        {
            var s = c.NetworkTexts.Find(id);
            s.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("networkyazilist");
        }
        //Network Yazı İşlemleri Son
    }
}