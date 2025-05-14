using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infra;

public static class EntityBuilderExtensions
{
    public static void AddTenantField<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property<int>("TenantId").IsRequired();
    }

    public static void AddAuditFields<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property<int>("CreatedBy").HasColumnType("int").IsRequired();
        builder.Property<DateTime>("CreatedAt").HasColumnType("datetime").IsRequired();
        builder.Property<int?>("UpdatedBy").HasColumnType("int");
        builder.Property<DateTime?>("UpdatedAt").HasColumnType("datetime");
        builder.Property<bool>("Status").HasColumnType("bit").HasDefaultValue(true).IsRequired();
    }
}
