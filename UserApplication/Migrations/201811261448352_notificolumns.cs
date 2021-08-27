namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Type");
        }
    }
}
