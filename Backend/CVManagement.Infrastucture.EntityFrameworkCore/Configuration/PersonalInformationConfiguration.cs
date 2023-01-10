using CVManagement.Domain;
using Microsoft.EntityFrameworkCore;
using static CVManagement.Infrastucture.Constants;

namespace CVManagement.Infrastucture
{
    public static class PersonalInformationConfiguration
    {
        public static void ConfigurePersonalInformation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalInformation>(builder =>
            {
                builder.Property(prop => prop.FullName).HasMaxLength(Length.Normal);
                builder.Property(prop => prop.CityName).HasMaxLength(Length.Normal).IsRequired(false);
                builder.Property(prop => prop.Email).HasMaxLength(Length.Normal).IsRequired(false);
                builder.Property(prop => prop.MobileNumber).HasMaxLength(Length.Phone);
                builder.HasQueryFilter(cv => !cv.IsDeleted);
            });
        }
    }
}
