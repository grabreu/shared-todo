using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedTodo.Api.Identity;

namespace SharedTodo.Api.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.DisplayName)
            .IsRequired()
            .HasMaxLength(ApplicationUser.DisplayNameMaxLength);
    }
}
