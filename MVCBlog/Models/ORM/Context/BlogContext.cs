using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace MVCBlog.Models.ORM.Context
{
    //yorum satıralrını silme
    public class BlogContext : DbContext
    {
        public  BlogContext()
        {
            Database.Connection.ConnectionString = @"server=bim\sql2014;Database=MVCBlog;User ID=TestUser; Password=Tu123456*-;pooling=false;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { // bu metod olmazsa adminUser class ını db ye adminUser(s) olarak basar. Şuanda AdminUser olarak tablo açacak
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
        public DbSet<SiteBilgileri> SiteBilgileris { get; set; }
        


        //kullanılacak komutlar
        // 1 - enable-migrations - Class ların tablo olarak basılmasına izin ver  - 1 kere yazılıyor ilk başta
        // 2 - update-database - tablolardaki her değişiklikte bu konu kullanacaz - package manager console 
        // 3 - update-database -force - tablolardaki her değişiklikte bu konu kullanacaz - package manager console 
    }
}
