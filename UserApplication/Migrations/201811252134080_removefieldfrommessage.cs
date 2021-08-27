namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefieldfrommessage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "MesssageSubject");
            DropColumn("dbo.Messages", "MessageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageID", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "MesssageSubject", c => c.String());
        }
    }
}
