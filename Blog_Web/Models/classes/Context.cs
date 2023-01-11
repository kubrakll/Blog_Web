using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog_Web.Models.classes
{
    public class Context:DbContext
    {
        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Text> Texts { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}