using ETicaret.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace ETicaret.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklama")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comment { get; set; } 

        public List<ProductRating> ProductRating { get; set; }
        public string StarNum { get; set; }
        public List<ProductRating> Rating { get; set; }
        public double AverageRating { get ; set; }
    }
}
//ID 'sini, adını, açıklamasını, fiyatını, stokunu, resmini, ana sayfada gösterilip gösterilmeyeceğini ve onaylanmış olup olmadığını temsil eder.