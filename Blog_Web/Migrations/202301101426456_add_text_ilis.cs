namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_text_ilis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "CategoryID", c => c.Int());
            CreateIndex("dbo.Texts", "CategoryID");
            AddForeignKey("dbo.Texts", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Texts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Texts", new[] { "CategoryID" });
            DropColumn("dbo.Texts", "CategoryID");
        }
    }
}
