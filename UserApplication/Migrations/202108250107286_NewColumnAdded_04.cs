namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAdded_04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "PassportNumber", c => c.String());
            AlterColumn("dbo.Employers", "FaxNo", c => c.String());
            AlterColumn("dbo.SelfEmployeds", "TypeOfBusiness", c => c.String());
            AlterColumn("dbo.SelfEmployeds", "FaxNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SelfEmployeds", "FaxNo", c => c.String(nullable: false));
            AlterColumn("dbo.SelfEmployeds", "TypeOfBusiness", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "FaxNo", c => c.String(nullable: false));
            AlterColumn("dbo.People", "PassportNumber", c => c.String(nullable: false));
        }
    }
}
