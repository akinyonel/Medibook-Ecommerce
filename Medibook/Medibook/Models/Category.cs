using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medibook.Models
{
    public class Category
    {

        public Category()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        [DisplayName("Kategori Adı"), Required]
        public string Name { get; set; }

        //navprop
        public virtual List<Book> Books { get; set; }


    }
}