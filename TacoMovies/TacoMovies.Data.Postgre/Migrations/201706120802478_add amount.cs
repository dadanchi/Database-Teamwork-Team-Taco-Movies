namespace TacoMovies.Data.Postgre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addamount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Ammount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Ammount");
        }
    }
}
