using Ims.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infra.Customers;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd().IsRequired();

        builder.Property<int>("TenantId").IsRequired();

        builder.Property<int>("CreatedBy").HasColumnType("int").IsRequired();
        builder.Property<DateTime>("CreatedAt").HasColumnType("datetime").IsRequired();
        builder.Property<int?>("UpdatedBy").HasColumnType("int");
        builder.Property<DateTime?>("UpdatedAt").HasColumnType("datetime");
        builder.Property<bool>("Status").HasColumnType("bit").HasDefaultValue(true).IsRequired();

        builder.OwnsOne(c => c.PersonInfo, person =>
        {
            person.OwnsOne(c => c.CPF, cpf =>
            {
                cpf.Property(p => p.Value).HasColumnName("CPF").HasColumnType("char(14)");
            });

            person.Property(p => p.Name).HasColumnName("Name").HasColumnType("nvarchar(200)");
            person.Property(p => p.BirthDate).HasColumnName("BirthDate").HasColumnType("datetime");
        });

        builder.OwnsOne(c => c.CompanyInfo, company =>
        {
            company.OwnsOne(c => c.CNPJ, cnpj =>
            {
                cnpj.Property(p => p.Value).HasColumnName("CNPJ").HasColumnType("char(18)");
            });

            company.Property(p => p.CorporateName).HasColumnName("CorporateName").HasColumnType("nvarchar(200)");
            company.Property(p => p.TradeName).HasColumnName("TradeName").HasColumnType("nvarchar(200)");
            company.Property(p => p.StateRegistration).HasColumnName("StateRegistration").HasColumnType("nvarchar(50)");
            company.Property(p => p.BillingTerm).HasColumnName("BillingTerm").HasColumnType("nvarchar(200)");
            company.Property(p => p.Interest).HasColumnName("Interest").HasColumnType("decimal(8,2)");
            company.Property(p => p.Fine).HasColumnName("Fine").HasColumnType("decimal(10,4)");
        });

        builder.OwnsOne(c => c.Address, address =>
        {
            address.OwnsOne(p => p.PostalCode, postalCode =>
            {
                postalCode.Property(p => p.Value).HasColumnName("PostalCode").HasColumnType("char(9)").IsRequired();
            });

            address.Property(a => a.Country).HasColumnName("Country").HasColumnType("nvarchar(60)").IsRequired();
            address.Property(a => a.State).HasColumnName("State").HasColumnType("char(2)").IsRequired();
            address.Property(a => a.City).HasColumnName("City").HasColumnType("nvarchar(50)").IsRequired();
            address.Property(a => a.Street).HasColumnName("Street").HasColumnType("nvarchar(100)").IsRequired();
            address.Property(a => a.Number).HasColumnName("Number").HasColumnType("nvarchar(10)").IsRequired();
            address.Property(a => a.Neighborhood).HasColumnName("Neighborhood").HasColumnType("nvarchar(100)").IsRequired();
            address.Property(a => a.AdditionalInfo).HasColumnName("AdditionalInfo").HasColumnType("nvarchar(150)");
        });

        builder.OwnsOne(c => c.ContactInfo, contact =>
        {
            contact.OwnsOne(p => p.Phone, phone =>
            {
                phone.Property(p => p.Number).HasColumnName("Phone").HasColumnType("char(14)");
            });

            contact.OwnsOne(p => p.Mobile, mobile =>
            {
                mobile.Property(p => p.Number).HasColumnName("Mobile").HasColumnType("char(16)");
            });

            contact.OwnsMany(p => p.Emails, email =>
            {
                email.WithOwner().HasForeignKey("CustomerId");

                email.Property(p => p.Address).HasColumnName("Address").HasColumnType("nvarchar(200)");

                email.HasKey("CustomerId", "Address");
            });
        });

        builder.Property(c => c.Notes).HasColumnName("Notes").HasColumnType("nvarchar(1000)");
        builder.Property(c => c.Type).HasColumnName("Type").HasConversion<string>().HasColumnType("nvarchar(30)").IsRequired();
    }
}
