using LBAreas.Entities.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Entities.Data
{
    public class LBAreasDbContext : DbContext
    {
        public LBAreasDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data for Difficulties
            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("3d99c20c-987a-483c-8788-90670258c672"),
                    Name = "Easy"
                },
                 new Difficulty
                {
                    Id = Guid.Parse("bbbf1c33-df7d-4721-9547-111644ac8bb1"),
                    Name = "Medium"
                },
                  new Difficulty
                {
                    Id = Guid.Parse("d3045da1-c6b6-4267-a908-c2c9264e67ff"),
                    Name = "Hard"
                }
            };
              // Seed difficulties to Database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("b453ec82-345b-4761-ba87-a6d6222f6d0b"),
                    Name = "Akkar",
                    Code = "AR",
                    RegionImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIQwWSZKnnDMLL3fq_6bDn1x1UeTi0wLTrpg&s"
                },
                   new Region
                {
                    Id = Guid.Parse("7414847b-b57a-4d50-8a72-bf4dce5606e6"),
                    Name = "Baalbeck-Hermel",
                    Code = "BH",
                    RegionImageUrl = "https://media.safarway.com/content/f5370e10-51c9-46b6-8694-ae8df0df1805_sm.jpg"
                },
                      new Region
                {
                    Id = Guid.Parse("f27e7f6f-cd6a-497f-b2ec-066ee21b86db"),
                    Name = "Bekaa",
                    Code = "BA",
                    RegionImageUrl = "https://www.wine-searcher.com/images/region/bekaa-valley-7088-1-3.jpg"
                },
                         new Region
                {
                    Id = Guid.Parse("0dd644b9-0675-47da-bcb5-9b97c6c7ba6f"),
                    Name = " Mount Lebanon",
                    Code = "ML",
                    RegionImageUrl = "https://mountainsmagleb.com/wp-content/uploads/2020/03/Mount-Kneisse-Mario-Fares-300x225.jpg"
                },
                            new Region
                {
                    Id = Guid.Parse("29399f0e-6a9b-40ed-9e3e-a4d1b8d5d1d7"),
                    Name = "North Lebanon",
                    Code = "NB",
                    RegionImageUrl = "https://i.ytimg.com/vi/39qYU5MC_M0/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLBz5cYN1W-0IIQT36IqUZ1tiP3jeA"
                },
                               new Region
                {
                    Id = Guid.Parse("fe6734b6-1b1a-490f-8a66-8ac6458347f8"),
                    Name = "South Lebanon",
                    Code = "SB",
                    RegionImageUrl = "https://i.pinimg.com/236x/5c/b8/88/5cb8883d65f0c9db94bc208cd2982750.jpg"
                },
         
            };

            modelBuilder.Entity<Region>().HasData(regions);
             
        }
    }
}
