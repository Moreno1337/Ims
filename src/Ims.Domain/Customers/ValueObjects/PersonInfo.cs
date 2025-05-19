using Ims.Domain.Shared.Exceptions;
using Ims.Domain.Shared.ValueObjects;

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
            throw new MissingRequiredFieldException(nameof(Name));

        if (birthDate is null)
            throw new MissingRequiredFieldException(nameof(BirthDate));

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
