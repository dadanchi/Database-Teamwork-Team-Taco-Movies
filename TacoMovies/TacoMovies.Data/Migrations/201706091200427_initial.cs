namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        DateOfBirth = c.DateTime(),
                        Profession = c.Int(nullable: false),
                        Country_Id = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Rating = c.Single(),
                        PublishDate = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        Coutry_Id = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Coutry_Id)
                .ForeignKey("dbo.Artists", t => t.DirectorId)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.DirectorId)
                .Index(t => t.Coutry_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Authorization = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.AwardArtists",
                c => new
                    {
                        Award_Id = c.Int(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Award_Id, t.Artist_Id })
                .ForeignKey("dbo.Awards", t => t.Award_Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Award_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Movie_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Movies", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.GenreMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.Artists");
            DropForeignKey("dbo.Movies", "Coutry_Id", "dbo.Countries");
            DropForeignKey("dbo.Artists", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Artists", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.AwardArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.AwardArtists", "Award_Id", "dbo.Awards");
            DropIndex("dbo.GenreMovies", new[] { "Movie_Id" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_Id" });
            DropIndex("dbo.AwardArtists", new[] { "Artist_Id" });
            DropIndex("dbo.AwardArtists", new[] { "Award_Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Movies", new[] { "User_Id" });
            DropIndex("dbo.Movies", new[] { "Artist_Id" });
            DropIndex("dbo.Movies", new[] { "Coutry_Id" });
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropIndex("dbo.Movies", new[] { "Name" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Artists", new[] { "Movie_Id" });
            DropIndex("dbo.Artists", new[] { "Country_Id" });
            DropTable("dbo.GenreMovies");
            DropTable("dbo.AwardArtists");
            DropTable("dbo.Users");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Countries");
            DropTable("dbo.Awards");
            DropTable("dbo.Artists");
        }
    }
}
