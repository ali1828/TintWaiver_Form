namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAdded_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "NameOfEmployer", c => c.String(nullable: false));
            DropColumn("dbo.Employers", "NationalIDNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "NationalIDNo", c => c.String(nullable: false));
            DropColumn("dbo.Employers", "NameOfEmployer");
        }
    }
}
