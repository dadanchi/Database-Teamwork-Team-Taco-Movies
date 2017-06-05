namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoutryToIntInMovieClas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Coutry_Id", "dbo.Countries");
            DropIndex("dbo.Movies", new[] { "Coutry_Id" });
            AddColumn("dbo.Movies", "Coutry", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Coutry_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Coutry_Id", c => c.Int());
            DropColumn("dbo.Movies", "Coutry");
            CreateIndex("dbo.Movies", "Coutry_Id");
            AddForeignKey("dbo.Movies", "Coutry_Id", "dbo.Countries", "Id");
        }
    }
}
