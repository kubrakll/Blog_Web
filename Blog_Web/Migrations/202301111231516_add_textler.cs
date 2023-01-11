namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_textler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NetworkTexts",
                c => new
                    {
                        NetworkTextID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CoverLetter = c.String(maxLength: 120),
                        Description = c.String(),
                        TextDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NetworkTextID);
            
            CreateTable(
                "dbo.SistemTexts",
                c => new
                    {
                        SistemTextID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CoverLetter = c.String(maxLength: 120),
                        Description = c.String(),
                        TextDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SistemTextID);
            
            CreateTable(
                "dbo.SiberTexts",
                c => new
                    {
                        SiberTextID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CoverLetter = c.String(maxLength: 120),
                        Description = c.String(),
                        TextDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SiberTextID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiberTexts");
            DropTable("dbo.SistemTexts");
            DropTable("dbo.NetworkTexts");
        }
    }
}
