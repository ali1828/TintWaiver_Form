namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefieldfrommessage2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.Messages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Messages", "ApplicationUser_Id1");
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
