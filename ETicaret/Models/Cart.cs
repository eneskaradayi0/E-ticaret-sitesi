using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaret.Entity;

namespace ETicaret.Models
{
    public class Cart//alışveriş sepeti
    {
        
        private List<CartLine> _cardLines = new List<CartLine>();//// Bir alışveriş sepetindeki satır, bir ürünü ve ürünün miktarını temsil eder.

        public List<CartLine> CartLines
        {
            get { return _cardLines; }// // Bu yöntem, kullanıcının satın almak istediği ürünlerin bir listesini döndürür.
        }

        public void AddProduct(Product product, int quantity)/// bir ürünü alışveriş sepetine ekler
        {
            var line = _cardLines.FirstOrDefault(i => i.Product.Id == product.Id);//alışveriş sepetinin satırlarından ürünün ID'sine eşit olan bir satır bulur
            if (line == null)
            {
                _cardLines.Add(new CartLine() { Product = product, Quantity = quantity });// Eğer böyle bir satır yoksa  yeni bir satır oluşturur ve ürünü ve miktarı satırda saklar
            }
            else
            {
                line.Quantity += quantity;//satırın miktarını günceller
            }
        }

        public void DeleteProduct(Product product)//sepetten siler
        {
            _cardLines.RemoveAll(i => i.Product.Id == product.Id);//alışveriş sepetinin satırlarından, ürünün ID'sine eşit olan tüm satırları siler
        }

        public double Total()//toplama
        {
            return _cardLines.Sum(i => i.Product.Price * i.Quantity);//satırları gezer ve adet ve fiyatı çarpar
        }

        public void Clear()
        {
            _cardLines.Clear();//sepeti boşaltır
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }//ürünü temsil eden
        public int Quantity { get; set; }//ürünün miktarını 
    }
}