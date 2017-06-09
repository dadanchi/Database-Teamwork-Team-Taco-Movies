namespace TacoMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordlengthandvarcharonit : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20, unicode: false));
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.Users", "Username", unique: true);
        }
    }
}
