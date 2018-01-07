namespace SongIpsum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTrackTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        Decade = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackName = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            DropTable("dbo.Lyrics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lyrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Artist = c.String(),
                        Decade = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Tracks", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "Artist_Id" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Artists");
        }
    }
}
