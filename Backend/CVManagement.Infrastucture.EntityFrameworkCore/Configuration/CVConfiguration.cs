using CVManagement.Domain;
using Microsoft.EntityFrameworkCore;
using static CVManagement.Infrastucture.Constants;

namespace CVManagement.Infrastucture
{
    public static class CVConfiguration
    {
        public static void ConfigureCV(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CV>(builder =>
            {
                builder.Property(prop => prop.Name).HasMaxLength(Length.Normal);
                builder.HasMany(cv => cv.ExperienceInformation).WithOne();
                builder.HasOne(cv => cv.PersonalInformation).WithMany().HasForeignKey(cv => cv.PersonalInformationId);
                builder.HasQueryFilter(cv => !cv.IsDeleted);
            });
        }
    }
}
