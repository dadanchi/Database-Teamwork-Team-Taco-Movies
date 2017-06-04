namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
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
                        Name = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        Coutry_Id = c.Int(),
                        Director_Id = c.Int(),
                        Artist_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Coutry_Id)
                .ForeignKey("dbo.Artists", t => t.Director_Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Coutry_Id)
                .Index(t => t.Director_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Authorization = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Movies", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Genres", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Movies", "Director_Id", "dbo.Artists");
            DropForeignKey("dbo.Movies", "Coutry_Id", "dbo.Countries");
            DropForeignKey("dbo.Artists", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Artists", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Awards", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Genres", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "User_Id" });
            DropIndex("dbo.Movies", new[] { "Artist_Id" });
            DropIndex("dbo.Movies", new[] { "Director_Id" });
            DropIndex("dbo.Movies", new[] { "Coutry_Id" });
            DropIndex("dbo.Awards", new[] { "Artist_Id" });
            DropIndex("dbo.Artists", new[] { "Movie_Id" });
            DropIndex("dbo.Artists", new[] { "Country_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Countries");
            DropTable("dbo.Awards");
            DropTable("dbo.Artists");
        }
    }
}
