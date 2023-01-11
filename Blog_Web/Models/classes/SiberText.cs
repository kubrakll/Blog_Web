using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web.Models.classes
{
    public class SiberText
    {
        [Key]
        public int SiberTextID { get; set; }

        public string Title { get; set; }

        [StringLength(120)]
        public string CoverLetter { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        
        public DateTime TextDate { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public string source1 { get; set; }
        public string source2 { get; set; }
        public string source3 { get; set; }
        public string source4 { get; set; }
        public string source5 { get; set; }
        public string source6 { get; set; }
    }
}