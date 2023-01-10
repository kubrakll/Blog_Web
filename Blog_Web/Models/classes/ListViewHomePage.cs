using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Web.Models.classes
{
    public class ListViewHomePage
    {
        public List<Slider> sliders { get; set; }
        public List<About> about{ get; set; }
        public List<Text> text { get; set; }
        public List<Contact> contacts { get; set; } 

    }
}