using CVManagement.Domain;
using Microsoft.EntityFrameworkCore;
using static CVManagement.Infrastucture.Constants;

namespace CVManagement.Infrastucture
{
    public static class ExperienceInformationConfiguration
    {
        public static void ConfigureExperienceInformation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperienceInformation>(builder =>
            {
                builder.Property(prop => prop.CompanyName).HasMaxLength(Length.CompanyName).IsRequired();
                builder.Property(prop => prop.City).HasMaxLength(Length.Normal).IsRequired(false);
                builder.Property(prop => prop.CompanyField).HasColumnType(NVARCHAR_MAX).IsRequired(false);
                builder.HasQueryFilter(cv => !cv.IsDeleted);
            });
        }
    }
}
