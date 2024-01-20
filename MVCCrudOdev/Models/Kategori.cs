using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCrudOdev.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz!"), StringLength(15)]
        public string KategoriAdi { get; set; }
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!"), StringLength(15)]
        public string KategoriAciklamasi { get; set; }


        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!"), StringLength(15)]
        public string Urun { get; set; }

        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!"), StringLength(15)]
        public string Fiyat { get; set; }
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!"), StringLength(15)]
        public string Stock { get; set; }



    }
}