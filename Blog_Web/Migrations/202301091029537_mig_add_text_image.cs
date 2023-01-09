namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_text_image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "Image");
        }
    }
}
