using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BlogGuncelle(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGuncelle", bl);
        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog blog)
        {
            var blg = c.Blogs.Find(blog.ID);
            blg.Aciklama = blog.Aciklama;
            blg.Baslik = blog.Baslik;
            blg.BlogImage = blog.BlogImage;
            blg.Tarih = blog.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var y = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(y);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yrm = c.Yorumlars.Find(yorumlar.ID);
            yrm.KullaniciAdi = yorumlar.KullaniciAdi;
            yrm.Mail = yorumlar.Mail;
            yrm.Yorum = yorumlar.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult Contact()
        {
            var iletisim = c.İletisims.ToList();
            return View(iletisim);
        }
        public ActionResult ContactDelete(int id)
        {
            var iletisimsil = c.İletisims.Find(id);
            c.İletisims.Remove(iletisimsil);
            c.SaveChanges();
            return RedirectToAction("Contact");
        }

    }
}