﻿using System;
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
        public List<Category> categories { get; set; }
        public List<SiberText> siberTexts { get; set; }
        public List<SistemText> sistemTexts { get; set; }
        public List<NetworkText> networkTexts { get; set; }
        

    }
}