namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlogindetailsfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginDetails", "UserAgent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginDetails", "UserAgent");
        }
    }
}
