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
                textıd.IsActive = true;
            }
            c.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult yeniYazi()
        {
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
                    CoverLetter=text.CoverLetter,
                    IsActive=true,
                    Image = "~/Content/img/" + dosya.FileName,

                });
                c.SaveChanges();
            }
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


    }
}