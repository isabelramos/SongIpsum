namespace SongIpsum.Migrations
{
	using SongIpsum.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SongIpsum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SongIpsum.Models.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			//context.Artist.AddOrUpdate(
			//		new Artist { ArtistName = "Foo Fighters", Decade = 1990, Genre = "Rock"}
			//);

			//context.SaveChanges();
			//var artist = context.Artist.First();

			//context.Track.AddOrUpdate(
			//		new Track { TrackName = "My Hero", Artist = artist },
			//		new Track { TrackName = "Monkey Wrench", Artist = artist },
			//		new Track { TrackName = "This is a Call", Artist = artist },
			//		new Track { TrackName = "Everlong", Artist = artist },
			//		new Track { TrackName = "Big Me", Artist = artist },
			//		new Track { TrackName = "Enough Space", Artist = artist }
			//);
		}
    }
}
