namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAdded_01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Male", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employers", "ProfessionOrOccupation", c => c.String(nullable: false));
            DropColumn("dbo.People", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Sex", c => c.String(nullable: false));
            DropColumn("dbo.Employers", "ProfessionOrOccupation");
            DropColumn("dbo.People", "Female");
            DropColumn("dbo.People", "Male");
        }
    }
}
