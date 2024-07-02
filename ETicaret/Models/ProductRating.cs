using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class ProductRating
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        //public int AverageRating { get; set; }
        //public int StarNum { get; set; }
        public int TotalRating { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int Rating { get; set; }
        public bool Active { get; set; }
    }
}