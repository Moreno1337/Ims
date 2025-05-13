using Ims.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infra.Customers;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("TbParameter001Customers");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("TbParameter001Id").HasColumnType("int").ValueGeneratedOnAdd().IsRequired();

        builder.OwnsOne(c => c.PersonInfo, person =>
        {
            person.Property(p => p.CPF).HasColumnName("TbParameter001CPF").HasColumnType("char(14)");
            person.Property(p => p.Name).HasColumnName("TbParameter001Name").HasColumnType("nvarchar(200)");
            person.Property(p => p.BirthDate).HasColumnName("TbParameter001BirthDate").HasColumnType("datetime");
        });

        builder.OwnsOne(c => c.CompanyInfo, company =>
        {
            company.Property(p => p.CNPJ).HasColumnName("TbParameter001CNPJ").HasColumnType("char(18)");
            company.Property(p => p.CorporateName).HasColumnName("TbParameter001CorporateName").HasColumnType("nvarchar(200)");
            company.Property(p => p.TradeName).HasColumnName("TbParameter001TradeName").HasColumnType("nvarchar(200)");
            company.Property(p => p.StateRegistration).HasColumnName("TbParameter001StateRegistration").HasColumnType("nvarchar(50)");
            company.Property(p => p.BillingTerm).HasColumnName("TbParameter001BillingTerm").HasColumnType("nvarchar(200)");
            company.Property(p => p.Interest).HasColumnName("TbParameter001Interest").HasColumnType("decimal(8,2)");
            company.Property(p => p.Fine).HasColumnName("TbParameter001Fine").HasColumnType("decimal(10,4)");
        });

        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Country).HasColumnName("TbParameter001Country").HasColumnType("nvarchar(60)").IsRequired();
            address.Property(a => a.PostalCode).HasColumnName("TbParameter001PostalCode").HasColumnType("char(9)").IsRequired();
            address.Property(a => a.State).HasColumnName("TbParameter001State").HasColumnType("char(2)").IsRequired();
            address.Property(a => a.City).HasColumnName("TbParameter001City").HasColumnType("nvarchar(50)").IsRequired();
            address.Property(a => a.Street).HasColumnName("TbParameter001Street").HasColumnType("nvarchar(100)").IsRequired();
            address.Property(a => a.Number).HasColumnName("TbParameter001Number").HasColumnType("nvarchar(10)").IsRequired();
            address.Property(a => a.Neighborhood).HasColumnName("TbParameter001Neighborhood").HasColumnType("nvarchar(100)").IsRequired();
            address.Property(a => a.AdditionalInfo).HasColumnName("TbParameter001AdditionalInfo").HasColumnType("nvarchar(150)");
        });

        builder.OwnsOne(c => c.ContactInfo, contact =>
        {
            contact.OwnsOne(p => p.Phone, phone =>
            {
                phone.Property(p => p.Number).HasColumnName("TbParameter001Phone").HasColumnType("char(14)");
            });

            contact.OwnsOne(p => p.Mobile, mobile =>
            {
                mobile.Property(p => p.Number).HasColumnName("TbParameter001Mobile").HasColumnType("char(16)");
            });

            contact.Property(p => p.Emails).HasColumnName("TbParameter001Emails").HasColumnType("nvarchar(max)");
        });

        builder.Property(c => c.Notes).HasColumnName("TbParameter001Notes").HasColumnType("nvarchar(1000)");
        builder.Property(c => c.Type).HasColumnName("TbParameter001Type").HasConversion<string>().HasColumnType("nvarchar(30)").IsRequired();
    }
}
