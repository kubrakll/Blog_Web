using Blog_Web.Models.classes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web.Controllers
{
    public class AnasayfaController : Controller
    {
        Context c = new Context();

        public ActionResult Home()
        {
            var liste = new ListViewHomePage();
            liste.sliders = c.Sliders.ToList();
            liste.about=c.Abouts.ToList();
            liste.text=c.Texts.OrderByDescending(x=>x.TextID).Take(3).ToList();
            return View(liste);
        }

        public ActionResult About()
        {
            var liste = new ListViewHomePage();
            liste.about = c.Abouts.ToList();
            return View(liste);
        }

        public ActionResult Text(int sayfa=1)
        {
            
            //var liste = new ListViewHomePage();
           var liste= c.Texts.OrderBy(x => x.TextID).ToPagedList<Text>(sayfa, 6);
            //liste.text=c.Texts.ToList();
            return View(liste);
        }


        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult ContactForm()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult ContactForm(Contact m)
        {
            c.Contacts.Add(new Contact
            {
                ContactID = m.ContactID,
                Name = m.Name,
                Mail = m.Mail,
                Phone = m.Mail,
                Subject = m.Subject,
                Message = m.Message,
                DateTime = DateTime.Parse(DateTime.Now.ToLongTimeString())
            });
            c.SaveChanges();
            try
            {
                SmtpClient client = new SmtpClient("mail.gmail.com", 587); //Burası aynı kalacak   mail artı dns adı            
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("kubraklc149@gmail.com", "Berat.37"); //Mail&Şifre
                //client.EnableSsl = true;
                MailMessage msj = new MailMessage(); //Yeni bir MailMesajı oluşturuyoruz
                msj.BodyEncoding = System.Text.Encoding.UTF8;
                msj.From = new MailAddress("kubraklc149@gmail.com", m.Mail + " " + m.Name + " " + m.Phone); // msj.From = new MailAddress(m.email, m.name + " " + m.phone); //iletişim kısmında girilecek mail buaraya gelecektir
                msj.To.Add("kubraklc149@gmail.com"); //Buraya kendi mail  adresimizi yazıyoruz
                msj.Subject = m.Subject; //Buraya iletişim sayfasında gelecek konu ve mail adresini mail içeriğine yazacaktır
                msj.IsBodyHtml = true;
                msj.Body = "<strong>Ad Soyad: </strong>" + m.Name + "<br>" + "<strong>Telefon Numarası: </strong>" + m.Phone + "<br>" + "<strong>Konu: </strong>" + m.Subject + "<br>" + "<strong>Mesaj İçeriği:</strong>" + "<br>" + m.Message;
                client.Send(msj); //Clien sent kısmında gönderme işlemi gerçeklecektir.
                //Bu kısımdan itibaren sizden kullanıcıya gidecek mail bilgisidir 
                MailMessage msj1 = new MailMessage();
                msj1.BodyEncoding = System.Text.Encoding.UTF8;
                msj1.From = new MailAddress("kubraklc149@gmail.com", "Blog Sitesi");
                msj1.To.Add(m.Mail); //Buraua iletişim sayfasında gelecek mail adresi gelecktir.
                msj1.Subject = "Blog Sitesi";
                msj1.Body = "Merhaba Sevgili" + m.Name;
                msj1.IsBodyHtml = true;
                msj1.Body = "Merhaba Sevgili " + m.Name + "," + "<br>" + " Bizimle iletişime geçtiğiniz için teşekkür ederiz." + "<br>" + "Size en kısa sürede geri dönüş sağlayacağız." + "<br>" + "Blog Sitesi";
                client.Send(msj1);
                ViewBag.Succes = "Teşekkür ederiz " + m.Name + " ,sizlere en kısa sürede dönüş yapacağız."; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur
                return PartialView();
            }
            catch (Exception)
            {
                ViewBag.Error = "Hata! Lütfen tekrar deneyiniz."; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur
                return PartialView();
            }
        }
       
        public ActionResult yaziDetails(int id)
        {
            var yazigetir = c.Texts.Find(id);
            return View("yaziDetails", yazigetir);
        }

        public ActionResult CategoryText()
        {
            var liste=new ListViewHomePage();
            liste.categories = c.Categories.ToList();
            return View(liste);
        }

        public ActionResult CategoryDetails(int id)
        {
            var yazigetir = c.Texts.Find(id);
            return View("CategoryDetails", yazigetir);
        }
    }
}