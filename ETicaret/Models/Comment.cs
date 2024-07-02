using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ETicaret.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }

        public int UserId { get; set; }

        public int ArticleID { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Active { get; set; }
    }
}
