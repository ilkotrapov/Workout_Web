using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data.Entities;

namespace Products_Web.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Diet> Diets { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<PushUp> PushUps { get; set; }

        public DbSet<PullUp> PullUps { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
    }
}