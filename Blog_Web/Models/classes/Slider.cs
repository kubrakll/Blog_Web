using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web.Models.classes
{
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string ButtonName { get; set; }

        public string ButtonLink { get; set; }

        public string Image { get; set; }
    }
}