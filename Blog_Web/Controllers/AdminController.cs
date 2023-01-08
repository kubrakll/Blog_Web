using Blog_Web.Models.classes;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}