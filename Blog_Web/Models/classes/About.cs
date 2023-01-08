using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web.Models.classes
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        public string Tittle { get; set; }

        public string Tittle2 { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string Image { get; set; }
    }
}