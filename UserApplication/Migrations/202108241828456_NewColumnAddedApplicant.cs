namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAddedApplicant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "DateOfApplication", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "DateOfApplication");
        }
    }
}
