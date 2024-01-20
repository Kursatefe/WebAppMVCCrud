using MVCCrudOdev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudOdev.Controllers
{
    public class KategoriCrudController : Controller
    {
        KategoriContext context = new KategoriContext();
        public ActionResult Index()
        {
            return View(context.Kategoriler.ToList());

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kategori kategori) // yeni kayıt ekleme sayfası
        {
            if (ModelState.IsValid) // uye nesnesi validasyondan geçtiyse
            {
                context.Kategoriler.Add(kategori); // context e ekle
                int sonuc = context.SaveChanges(); // veritabanına yansıt
                if (sonuc > 0) // ekleme başarılıysa
                {
                    return RedirectToAction("Index"); // liste sayfasına yönlendir
                }
            }

            return View(kategori); // kayıt başarısız olursa kullanıcıya validasyon hatalarını göster

        }
        public ActionResult Edit(int? id) // kayıt güncelleme sayfası - int? id değerini nullable - boş geçilebilir yapar.
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // geriye geçersiz istek hatası döndür.
            }
            Kategori kategori = context.Kategoriler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (kategori == null) // eğer db de kayıt bulamazsan
                return HttpNotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(kategori); // eğer kayıt varsa view ekranına gönder
        }
        [HttpPost]
        public ActionResult Edit(Kategori kategori) // kayıt güncelleme sayfası
        {
            if (ModelState.IsValid) // uye nesnesi validasyondan geçtiyse
            {
                context.Entry(kategori).State = System.Data.Entity.EntityState.Modified; // ekrandan gelen uye nesnesini güncellenmek üzere ayarla
                int sonuc = context.SaveChanges(); // veritabanına yansıt
                if (sonuc > 0) // ekleme başarılıysa
                {
                    return RedirectToAction("Index"); // liste sayfasına yönlendir
                }
            }
            return View(kategori); // kayıt başarısız olursa kullanıcıya validasyon hatalarını göster
        }
        public ActionResult Delete(int? id) // kayıt silme sayfası - int? id değerini nullable - boş geçilebilir yapar.
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // geriye geçersiz istek hatası döndür.
            }
            Kategori kategori = context.Kategoriler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (kategori == null) // eğer db de kayıt bulamazsan
                return HttpNotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(kategori); // eğer kayıt varsa view ekranına gönder
        }
        [HttpPost, ActionName("Delete")] // formdan action olarak delete gelecek ve method post olacak
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = context.Kategoriler.Find(id);
            context.Kategoriler.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



