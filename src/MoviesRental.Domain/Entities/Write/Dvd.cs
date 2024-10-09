using MoviesRental.Domain.Enums;
using MoviesRental.Domain.Validator;

namespace MoviesRental.Domain.Entities.Write;
public sealed class Dvd : Entity
{
    public string Title { get; private set; }
    public EGenre Genre { get; private set; }
    public DateTime Publisher { get; private set; }
    public bool IsAvailable { get; private set; }
    public int Copies { get; private set; }
    public Guid DirectorId { get; private set; }
    public Director Director { get; private set; }

    public const int MIN_TITLE_LENGTH = 3;
    public const int MAX_TITLE_LENGTH = 50;
    public const string EMPTY_STRING_ERROR_MESSAGE = "{PropertyName} is required!";
    public const string INVALID_ERROR_MESSAGE = "Invalid {PropertyName}!";
    public const string MIN_LENGTH_ERROR_MESSAGE = "Invalid {PropertyName}! Minimum {MinLength} characteres!";
    public const string MAX_LENGTH_ERROR_MESSAGE = "Invalid {PropertyName}! Maximum {MinLength} characteres!";
    public const string GENRE_ERROR_MESSAGE = "Invalid genre!";
    public const int GENRE_MIN_NUMBER = 0;
    public const int GENRE_MAX_NUMBER = 18;
    public const int COPIES_ERROR_NUMBER = -1;

    protected Dvd()
    { }

    public Dvd(int genre, DateTime publisher, int copies, Guid directorId)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdateGenre(genre);
        UpdatePublisheDate(publisher);
        UpdateCopies(copies);
        UpdateDirector(directorId);
    }

    public void RentCopy()
    {
        DomainValidatorException.When(Copies == 0 || !IsAvailable, $"Dvd {Title} is not available to rent!");

        var copies = Copies - 1;
        UpdateCopies(copies);
    }

    public void ReturnCopy()
    {
        DomainValidatorException.When(!IsAvailable, $"Dvd {Title} is not avaiable!");

        var copies = Copies + 1;
        UpdateCopies(copies);
    }

    public void UpdateTitle(string title)
    {
        DomainValidatorException.When(string.IsNullOrEmpty(title), "Title is required!");
        DomainValidatorException.When(title.Length < MIN_TITLE_LENGTH, "Invalid title! Minimum 3 characteres!");
        DomainValidatorException.When(title.Length > MAX_TITLE_LENGTH, "Invalid title! Maximum 50 characteres!");

        Title = title;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateGenre(int genre)
    {
        DomainValidatorException.When(!IsAvailable, $"Dvd {Title} is not available!");
        DomainValidatorException.When(genre < GENRE_MIN_NUMBER || genre > GENRE_MAX_NUMBER, "Invalid genre!");

        Genre = genre switch
        {
            0 => EGenre.Action,
            1 => EGenre.Adventure,
            2 => EGenre.Animation,
            3 => EGenre.Comedy,
            4 => EGenre.Crime,
            5 => EGenre.Documentary,
            6 => EGenre.Drama,
            7 => EGenre.Fantasy,
            8 => EGenre.Horror,
            9 => EGenre.Musical,
            10 => EGenre.Mistery,
            11 => EGenre.Romance,
            12 => EGenre.SciFi,
            13 => EGenre.Thriller,
            14 => EGenre.Western,
            15 => EGenre.Biography,
            16 => EGenre.Historic,
            17 => EGenre.War,
            18 => EGenre.Family,
            _ => throw new InvalidOperationException("Invalid genre value")
        };

        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePublisheDate(DateTime date)
    {
        DomainValidatorException.When(!IsAvailable, $"Dvd {Title} is not available!");

        var todayDate = DateTime.UtcNow;

        DomainValidatorException.When(todayDate < date, "Invalid published date!");

        Publisher = date;
        UpdatedAt = todayDate;
    }

    public void UpdateDirector(Guid directorId)
    {
        DomainValidatorException.When(!IsAvailable, $"Dvd {Title} is not available!");
        DomainValidatorException.When(directorId == Guid.Empty, $"Invalid director id!");

        DirectorId = directorId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCopies(int copies)
    {
        DomainValidatorException.When(!IsAvailable, $"Dvd {Title} is not available!");
        DomainValidatorException.When(copies < 0, "Invalid copies! Must be greater than 0!");

        Copies = copies;
        UpdatedAt = DateTime.UtcNow;
    }

    public void DeleteDvd()
    {
        DomainValidatorException.When(!IsAvailable, $"Dvd is already deleted!");

        IsAvailable = false;
        Copies = 0;
        DeletedAt = DateTime.UtcNow;
    }
}