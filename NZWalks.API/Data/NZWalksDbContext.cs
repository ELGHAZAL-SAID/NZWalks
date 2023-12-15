using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data for difficulties
            //Eeasy, Hard, Medium

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("23416337-1ea7-4e1e-ad17-2a6c29f06626"),
                    Name = "Eeasy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("637befdf-f78a-4cc9-a17c-e9294257b58f"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("447fffcc-92ce-4cd1-a66b-e848c90cacb2"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // seed Data for regions

            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("480138fd-7150-4f3d-a02b-d09a5ae4d693"),
                    Code = "FS",
                    Name = "Fes-Mekness",
                    RegionImageUrl = "Image Url"
                },
                new Region
                {
                    Id = Guid.Parse("05fcec74-f560-4b25-aa4d-f7043df42f5f"),
                    Code = "LS",
                    Name = "Laayoune Sakia El hamrae",
                    RegionImageUrl = "Image Url"
                },
                new Region
                {
                    Id = Guid.Parse("05fcec74-f560-4b25-ab3d-f7043df42f5f"),
                    Code = "RB",
                    Name = "Rabat Knitra",
                    RegionImageUrl = "Image Url"
                },
                new Region
                {
                    Id = Guid.Parse("0e8cbdd0-108a-4b54-ac00-20cefeed3ad7"),
                    Code = "KB",
                    Name = "Khouribga Bni mlal",
                    RegionImageUrl = "Image Url"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
