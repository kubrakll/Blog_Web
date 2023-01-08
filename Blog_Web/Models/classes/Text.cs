using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web.Models.classes
{
    public class Text
    {
        [Key]
        public int TextID { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(0:dd/MM/yyyy)")]
        public DateTime TextDate { get; set; }

        public bool IsActive { get; set; }
    }
}