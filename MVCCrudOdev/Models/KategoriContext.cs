using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCrudOdev.Models
{
    public class KategoriContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}