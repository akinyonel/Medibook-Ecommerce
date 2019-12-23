using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medibook.Models
{
    public class Book
    {
        

        public int Id { get; set; }
        [DisplayName("Ad"), Required]
        public string Name { get; set; }
        [DisplayName("Yazar"), Required]
        public string Author { get; set; }
        [DisplayName("Yayınevi"), Required]
        public string Publisher { get; set; }
        [DisplayName("Dil"), Required]
        public string Language { get; set; }
        [DisplayName("Fiyat"), Required]
        public double Price { get; set; }
        [DisplayName("Popülerlik")]
        public int Ratio { get; set; }
        [UIHint("tinymce_full_compressed"), AllowHtml]
        [DisplayName("Açıklama"), Required]
        public string Description { get; set; }
        [DisplayName("Resim"), Required]
        public string ImageString { get; set; }

        [DisplayName("Kategori"), Required]
        public int CategoryId { get; set; }

        //navprop
        public virtual Category Category { get; set; }
    }
}