namespace TacoMovies.Data.Postgre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustaccountNumberrange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Accounts", new[] { "AccountNumber" });
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Accounts", "AccountNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "AccountNumber" });
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "AccountNumber", unique: true);
        }
    }
}
