namespace SongIpsum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttemptAddLyricTable : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lyrics");
        }
    }
}
