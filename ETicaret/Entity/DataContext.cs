using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ETicaret.Models;

namespace ETicaret.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public object StarRatings { get; internal set; }
        public DbSet<ProductRating> Ratings { get; set; }
    }
}

        

//veri bağlamı sınıfı sağlar, veritabanı bağlantısını ve veritabanı tablolarına erişim için kullanılan tanımlar