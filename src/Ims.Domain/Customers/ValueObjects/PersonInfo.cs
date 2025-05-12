namespace Ims.Domain.Customers.ValueObjects;

public class PersonInfo
{
    public CPF CPF { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }

    private PersonInfo() { }

    private PersonInfo(
        string? cpfValue,
        string? name,
        DateTime? birthDate
    )
    {
        CPF cpf = CPF.Create(cpfValue);

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required", nameof(name));

        if (birthDate is null)
            throw new ArgumentException("Birth Date is required", nameof(birthDate));

        CPF = cpf;
        Name = name;
        BirthDate = (DateTime)birthDate;
    }

    public static PersonInfo Create(
        string? cpf,
        string? name,
        DateTime? birthDate
    )
    {
        return new PersonInfo(
            cpf,
            name,
            birthDate
        );
    }
}
