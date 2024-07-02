using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Entity;
using ETicaret.Models;


namespace ETicaret.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId
                }).ToList();

            return View(urunler);
        }

        public ActionResult Details(int id)//ayrıntı gösterir ve ıd gösterir
        {
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault(); //context kullanarak product erişir ve id eşleşen ilk ürünü döndürür
            product.Comment = _context.Comments.Where(i => i.ArticleID == id).ToList();

            
            var ProductRating = _context.Ratings.Where(pr => pr.ProductId == id/.ToList();
                var totalranting = 0;
                var totaluser = Convert.ToInt32(ProductRating.Count().ToString());
                foreach (var item in ProductRating)
                {
                    totalranting += item.TotalRating;
                }

                product.StarNum = (totalranting / totaluser).ToString();
                return View("details", product);
            }
            else
            {
                // Başarısız işlem durumu 
                return View("ErrorView");
            }
        }

      
    }


}

