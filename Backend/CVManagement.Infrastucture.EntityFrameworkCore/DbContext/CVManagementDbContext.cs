using CVManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagement.Infrastucture
{
    public class CVManagementDbContext : DbContext
    {

        public DbSet<CV> CVs { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ExperienceInformation> ExperienceInformations { get; set; }

        public CVManagementDbContext(DbContextOptions<CVManagementDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCV();
            modelBuilder.ConfigureExperienceInformation();
            modelBuilder.ConfigurePersonalInformation();
        }
    }
}
