﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret.Entity
{
    public class Category
    {
        public int Id { get; set; }

        //Data annotations
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength: 20, ErrorMessage = "en fazla 20 karakter girebilirsiniz.")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
//bir kategori nesnesi için bir sınıf tanımı sağlar. Bu sınıf, bir kategorinin ID'sini, adını, açıklamasını ve ürünlerini temsil eder.