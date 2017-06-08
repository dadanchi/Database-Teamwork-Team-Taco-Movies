namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSomerequiredconstraints : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Artists", new[] { "Country_Id" });
            AlterColumn("dbo.Artists", "Country_Id", c => c.Int());
            CreateIndex("dbo.Artists", "Country_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Artists", new[] { "Country_Id" });
            AlterColumn("dbo.Artists", "Country_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Artists", "Country_Id");
        }
    }
}
