namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Tittle2 = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mail = c.String(),
                        Subject = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ButtonName = c.String(),
                        ButtonLink = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.SliderID);
            
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        TextID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        TextDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TextID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Texts");
            DropTable("dbo.Sliders");
            DropTable("dbo.Contacts");
            DropTable("dbo.Abouts");
        }
    }
}
