using Ims.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infra.Customers;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.PersonInfo, person =>
        {
            person.Property(p => p.CPF).HasColumnName("CPF");
            person.Property(p => p.Name).HasColumnName("Name");
            person.Property(p => p.BirthDate).HasColumnName("BirthDate");
        });

        builder.OwnsOne(c => c.CompanyInfo, company =>
        {
            company.Property(p => p.CNPJ).HasColumnName("CNPJ");
            company.Property(p => p.CorporateName).HasColumnName("CorporateName");
            company.Property(p => p.TradeName).HasColumnName("TradeName");
            company.Property(p => p.StateRegistration).HasColumnName("StateRegistration");
            company.Property(p => p.BillingTerm).HasColumnName("BillingTerm");
            company.Property(p => p.Interest).HasColumnName("Interest");
            company.Property(p => p.Fine).HasColumnName("Fine");
        });

        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Country).HasColumnName("Country");
            address.Property(a => a.PostalCode).HasColumnName("PostalCode");
            address.Property(a => a.State).HasColumnName("State");
            address.Property(a => a.City).HasColumnName("City");
            address.Property(a => a.Street).HasColumnName("Street");
            address.Property(a => a.Number).HasColumnName("Number");
            address.Property(a => a.Neighborhood).HasColumnName("Neighborhood");
            address.Property(a => a.AdditionalInfo).HasColumnName("AdditionalInfo");
        });

        builder.OwnsOne(c => c.ContactInfo, contact =>
        {
            contact.OwnsOne(p => p.Phone, phone =>
            {
                phone.Property(p => p.Number).HasColumnName("Phone");
            });

            contact.OwnsOne(p => p.Mobile, mobile =>
            {
                mobile.Property(p => p.Number).HasColumnName("Mobile");
            });

            contact.Property(p => p.Emails).HasColumnName("Emails");
        });

        builder.Property(c => c.Notes).HasColumnName("Notes");
        builder.Property(c => c.Type).HasConversion<string>();
    }
}
