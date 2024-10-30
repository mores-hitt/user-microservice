using Microsoft.EntityFrameworkCore;
using user_microservice.Src.Models;

namespace user_microservice.Src.Data
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Career> Careers { get; set; }

        public DbSet<UserProgress> UserProgresses { get; set; }

        public DbSet<SubjectRelationship> SubjectRelationships { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
    }

}
