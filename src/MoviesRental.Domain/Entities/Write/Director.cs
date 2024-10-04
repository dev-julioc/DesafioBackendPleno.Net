using MoviesRental.Domain.Validator;
using System.Text.RegularExpressions;

namespace MoviesRental.Domain.Entities.Write;
public sealed class Director : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    private List<Dvd> _dvds = new List<Dvd>();
    public IReadOnlyList<Dvd> Dvds => _dvds;

    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 30;
    public const string EMPTY_STRING_ERROR_MESSAGE = "{PropertyName} is required!";
    public const string INVALID_ERROR_MESSAGE = "Invalid {PropertyName}!";
    public const string MIN_LENGTH_ERROR_MESSAGE = "Invalid {PropertyName}! Minimum {MinLength} characteres!";
    public const string MAX_LENGTH_ERROR_MESSAGE = "Invalid {PropertyName}! Maximum {MinLength} characteres!";

    protected Director()
    { }

    public Director(string name, string surname)
    {
        Id = Guid.NewGuid();
        UpdateName(name);
        UpdateSurName(surname);
        CreatedAt = DateTime.UtcNow;
    }

    public string FullName()
    {
        return $"{Name} {Surname}";
    }

    public void UpdateName(string name)
    {
        Validation(name);
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateSurName(string surname)
    {
        Validation(surname);
        Surname = surname;
        UpdatedAt = DateTime.UtcNow;
    }

    private void Validation(string value)
    {
        DomainValidatorException.When(string.IsNullOrEmpty(value), $"{value} is required!");
        DomainValidatorException.When(value.Length < MIN_LENGTH, $"Invalid {value}! Minimum {MIN_LENGTH} characteres!");
        DomainValidatorException.When(value.Length > MAX_LENGTH, $"Invalid {value}! Maximum {MAX_LENGTH} characteres!");
        DomainValidatorException.When(!Regex.IsMatch(value, @"^[\p{L} ]+$"), $"Invalid {value}!");
    }

}
