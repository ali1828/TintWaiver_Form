namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAdded_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "Yes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applicants", "No", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "No");
            DropColumn("dbo.Applicants", "Yes");
        }
    }
}
