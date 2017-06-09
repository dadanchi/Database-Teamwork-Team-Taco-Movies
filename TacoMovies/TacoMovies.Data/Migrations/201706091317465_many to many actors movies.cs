namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomanyactorsmovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artists", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Movies", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Artists", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Artist_Id" });
            CreateTable(
                "dbo.ArtistMovies",
                c => new
                    {
                        Artist_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_Id, t.Movie_Id })
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Movie_Id);
            
            DropColumn("dbo.Artists", "Movie_Id");
            DropColumn("dbo.Movies", "Artist_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Artist_Id", c => c.Int());
            AddColumn("dbo.Artists", "Movie_Id", c => c.Int());
            DropForeignKey("dbo.ArtistMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ArtistMovies", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.ArtistMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ArtistMovies", new[] { "Artist_Id" });
            DropTable("dbo.ArtistMovies");
            CreateIndex("dbo.Movies", "Artist_Id");
            CreateIndex("dbo.Artists", "Movie_Id");
            AddForeignKey("dbo.Movies", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Artists", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
