namespace WebApiLoginLogout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefaultColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "FullName");
        }
    }
}
