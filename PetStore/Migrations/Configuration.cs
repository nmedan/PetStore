namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PetStore.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<PetStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetStore.Models.ApplicationDbContext context)
        {
            context.Igracke.AddOrUpdate(x => x.Id,
               new Igracka() { Id = 1, Opis = "ALL4PAWS ChillOut Igracka za pse Hydration Bone", Cijena = 5.50 },
               new Igracka() { Id = 2, Opis = "ALL4PAWS ChillOut Igracka za pse Ice Ball s gel punjenjem za hladjenje", Cijena = 6.00 },
               new Igracka() { Id = 3, Opis = "ALL4PAWS ChillOut Igracka za pse Ice Bone s gel punjenjem za hladjenje", Cijena = 5.00 },
               new Igracka() { Id = 4, Opis = "ALL4PAWS Classic Igračka za pse Zec", Cijena = 7.00 },
               new Igracka() { Id = 5, Opis = "ALL4PAws Dig It Igračka za pse Fluffy Mat", Cijena = 8.00 }
               );
            context.KorpaIgrackaKupovine.RemoveRange(context.KorpaIgrackaKupovine);
            context.KorpaIgracke.RemoveRange(context.KorpaIgracke);
            context.Kupovine.RemoveRange(context.Kupovine);
        }
    }
}
