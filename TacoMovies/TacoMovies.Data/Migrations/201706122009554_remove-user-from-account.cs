namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeuserfromaccount : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "AccountNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "AccountNumber" });
        }
    }
}
