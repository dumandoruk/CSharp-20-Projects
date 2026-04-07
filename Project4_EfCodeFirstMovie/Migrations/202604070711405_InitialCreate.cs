namespace Project4_EfCodeFirstMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(maxLength: 100),
                        MovieDescription = c.String(),
                        MovieDuration = c.Int(nullable: false),
                        MovieReleaseDate = c.DateTime(nullable: false),
                        MovieStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
