namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Message = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LoginDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        LoginTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    From = c.String(maxLength: 128),
                    To = c.String(maxLength: 128),
                    MesssageSubject = c.String(),
                    MessageBody = c.String(),
                    SendTime = c.DateTime(nullable: false),
                    MessageID = c.Int(nullable: false),
                    Vu = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.To)
                .ForeignKey("dbo.AspNetUsers", t => t.From)
                .Index(t => t.From)
                .Index(t => t.To);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationUser = c.String(maxLength: 128),
                        Time = c.DateTime(nullable: false),
                        NotificationMessage = c.String(),
                        Viewed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.NotificationUser)
                .Index(t => t.NotificationUser);
            
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.String());
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Skype", c => c.String());
            AddColumn("dbo.AspNetUsers", "Facebook", c => c.String());
            AddColumn("dbo.AspNetUsers", "Twitter", c => c.String());
            AddColumn("dbo.AspNetUsers", "Profile", c => c.String());
            AddColumn("dbo.AspNetUsers", "Banned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginDetails", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "NotificationUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "From", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "To", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "NotificationUser" });
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Messages", new[] { "To" });
            DropIndex("dbo.Messages", new[] { "From" });
            DropIndex("dbo.LoginDetails", new[] { "UserId" });
            DropIndex("dbo.Activities", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "Banned");
            DropColumn("dbo.AspNetUsers", "Profile");
            DropColumn("dbo.AspNetUsers", "Twitter");
            DropColumn("dbo.AspNetUsers", "Facebook");
            DropColumn("dbo.AspNetUsers", "Skype");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Adress");
            DropColumn("dbo.AspNetUsers", "Birthday");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.LoginDetails");
            DropTable("dbo.Activities");
        }
    }
}
