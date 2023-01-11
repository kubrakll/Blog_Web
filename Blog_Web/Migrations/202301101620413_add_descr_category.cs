namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_descr_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Description");
        }
    }
}
