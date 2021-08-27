namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addipdress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginDetails", "IPadress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginDetails", "IPadress");
        }
    }
}
