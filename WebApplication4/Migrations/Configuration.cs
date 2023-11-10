namespace WebApplication4.Migrations
{
    using Ass2_Valorant.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication4.Data.WebApplication4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication4.Data.WebApplication4Context";
        }

        protected override void Seed(WebApplication4.Data.WebApplication4Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var nats = new List<Nat>
            {
                new Nat{Nation="USA"},
                new Nat{Nation="France"},
                new Nat{Nation="UK"},
                new Nat{Nation="Russia"},
                new Nat{Nation="South Africa"},
                new Nat{Nation="PRC"}
            };
            nats.ForEach(c => context.Nats.AddOrUpdate(p => p.Nation, c));
            context.SaveChanges();

            var players = new List<Player>
            { 
                new Player{ID = "Donald John Trump",Rank=642,NatID = nats.Single(c => c.Nation=="USA").ID },
                new Player{ID = "Bill Gates",Rank=525,NatID = nats.Single(c => c.Nation=="USA").ID },
                new Player{ID = "EDG-Chichoo",Rank=1898,NatID = nats.Single(c => c.Nation=="PRC").ID },
                new Player{ID = "EDG-Haodong",Rank=1899,NatID = nats.Single(c => c.Nation=="PRC").ID },
                new Player{ID = "EDG-Nobody",Rank=1902,NatID = nats.Single(c => c.Nation=="PRC").ID },
                new Player{ID = "EDG-Smoggy",Rank=1905,NatID = nats.Single(c => c.Nation=="PRC").ID },
                new Player{ID = "EDG-Zmjjkk",Rank=1999,NatID = nats.Single(c => c.Nation=="PRC").ID },
                new Player{ID = "Elon Reeve Musk",Rank=999,NatID = nats.Single(c => c.Nation=="South Africa").ID },
                new Player{ID = "Emmanuel Macron",Rank=900,NatID = nats.Single(c => c.Nation=="France").ID },
                new Player{ID = "Joe Biden",Rank=764,NatID = nats.Single(c => c.Nation=="USA").ID },
                new Player{ID = "Rishi Sunak",Rank=822,NatID = nats.Single(c => c.Nation=="UK").ID },
                new Player{ID = "Vladimir Putin",Rank=867,NatID = nats.Single(c => c.Nation=="Russia").ID }
            };
            players.ForEach(c => context.Players.AddOrUpdate(p => p.ID, c));
            context.SaveChanges();
        }
    }
}
