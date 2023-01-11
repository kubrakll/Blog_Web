namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_source : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NetworkTexts", "source1", c => c.String());
            AddColumn("dbo.NetworkTexts", "source2", c => c.String());
            AddColumn("dbo.NetworkTexts", "source3", c => c.String());
            AddColumn("dbo.NetworkTexts", "source4", c => c.String());
            AddColumn("dbo.NetworkTexts", "source5", c => c.String());
            AddColumn("dbo.NetworkTexts", "source6", c => c.String());
            AddColumn("dbo.SiberTexts", "source1", c => c.String());
            AddColumn("dbo.SiberTexts", "source2", c => c.String());
            AddColumn("dbo.SiberTexts", "source3", c => c.String());
            AddColumn("dbo.SiberTexts", "source4", c => c.String());
            AddColumn("dbo.SiberTexts", "source5", c => c.String());
            AddColumn("dbo.SiberTexts", "source6", c => c.String());
            AddColumn("dbo.SistemTexts", "source1", c => c.String());
            AddColumn("dbo.SistemTexts", "source2", c => c.String());
            AddColumn("dbo.SistemTexts", "source3", c => c.String());
            AddColumn("dbo.SistemTexts", "source4", c => c.String());
            AddColumn("dbo.SistemTexts", "source5", c => c.String());
            AddColumn("dbo.SistemTexts", "source6", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SistemTexts", "source6");
            DropColumn("dbo.SistemTexts", "source5");
            DropColumn("dbo.SistemTexts", "source4");
            DropColumn("dbo.SistemTexts", "source3");
            DropColumn("dbo.SistemTexts", "source2");
            DropColumn("dbo.SistemTexts", "source1");
            DropColumn("dbo.SiberTexts", "source6");
            DropColumn("dbo.SiberTexts", "source5");
            DropColumn("dbo.SiberTexts", "source4");
            DropColumn("dbo.SiberTexts", "source3");
            DropColumn("dbo.SiberTexts", "source2");
            DropColumn("dbo.SiberTexts", "source1");
            DropColumn("dbo.NetworkTexts", "source6");
            DropColumn("dbo.NetworkTexts", "source5");
            DropColumn("dbo.NetworkTexts", "source4");
            DropColumn("dbo.NetworkTexts", "source3");
            DropColumn("dbo.NetworkTexts", "source2");
            DropColumn("dbo.NetworkTexts", "source1");
        }
    }
}
