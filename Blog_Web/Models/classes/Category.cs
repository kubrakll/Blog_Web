using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_Web.Models.classes
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Image { get; set; }

        [StringLength(120)]
        public string Description { get; set; }

        //İlişki
        public List<Text> Texts { get; set;}
    }
}