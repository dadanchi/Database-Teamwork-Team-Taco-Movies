namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinttofloatinMoviesclassRatingprop : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
        }
    }
}
