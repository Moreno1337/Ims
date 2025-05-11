namespace Ims.Domain.Customers.ValueObjects;

public class PersonInfo
{
    public string CPF { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }

    private PersonInfo() { }

    private PersonInfo(
        string? cpf,
        string? name,
        DateTime? birthDate
    )
    {
        ValidateFields(cpf, name, birthDate);

        CPF = cpf!;
        Name = name!;
        BirthDate = (DateTime)birthDate!;
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

    private void ValidateFields(string? cpf, string? name, DateTime? birthDate)
    {
        if (string.IsNullOrEmpty(cpf))
            throw new ArgumentException("CPF is required");

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required");

        if (birthDate is null)
            throw new ArgumentNullException(nameof(BirthDate));
    }
}
