namespace TacoMovies.Data.Postgre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaccounttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.AccountNumber, unique: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropIndex("dbo.Accounts", new[] { "AccountNumber" });
            DropTable("dbo.Accounts");
        }
    }
}
