namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomanyusersmovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "User_Id" });
            CreateTable(
                "dbo.UserMovies",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Movie_Id })
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Movie_Id);
            
            DropColumn("dbo.Movies", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "User_Id", c => c.Int());
            DropForeignKey("dbo.UserMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.UserMovies", "User_Id", "dbo.Users");
            DropIndex("dbo.UserMovies", new[] { "Movie_Id" });
            DropIndex("dbo.UserMovies", new[] { "User_Id" });
            DropTable("dbo.UserMovies");
            CreateIndex("dbo.Movies", "User_Id");
            AddForeignKey("dbo.Movies", "User_Id", "dbo.Users", "Id");
        }
    }
}
