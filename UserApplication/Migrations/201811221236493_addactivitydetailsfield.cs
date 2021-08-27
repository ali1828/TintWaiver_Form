namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addactivitydetailsfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "IPAdress", c => c.String());
            AddColumn("dbo.Activities", "Agent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Agent");
            DropColumn("dbo.Activities", "IPAdress");
        }
    }
}
