namespace Blog_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tex_CoverLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "CoverLetter", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "CoverLetter");
        }
    }
}
