namespace WebApiLoginLogout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAnnonce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonce",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    UserName = c.String(nullable: false, maxLength: 128),
                    ContenuAnnonce = c.String(nullable: false, maxLength: 1000),
                    DateAnnonce = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)

                .Index(t => t.UserName, unique: true, name: "AnnonceIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Annonce", "UserId", "dbo.User");
            DropIndex("dbo.Annonce", new[] { "AnnonceIndex" });
            DropTable("dbo.Annonce");


        }
    }
}
