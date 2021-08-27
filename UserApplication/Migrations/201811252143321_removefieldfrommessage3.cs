namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefieldfrommessage3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id1" });
            // DropColumn("dbo.Messages", "ApplicationUser_Id");
            //RenameColumn(table: "dbo.Messages", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            // AlterColumn("dbo.Messages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "ApplicationUser_Id", c => c.Int());
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Messages", "ApplicationUser_Id", c => c.String());
            RenameColumn(table: "dbo.Messages", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            AddColumn("dbo.Messages", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.Messages", "ApplicationUser_Id1");
        }
    }
}
