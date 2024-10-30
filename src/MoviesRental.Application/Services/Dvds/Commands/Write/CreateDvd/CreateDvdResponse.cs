namespace MoviesRental.Application.Services.Dvds.Commands.Write.CreateDvd;
public record CreateDvdResponse
    (
        string Id,
        string Title,
        string Genre,
        DateTime Published,
        bool IsAvailable,
        int Copies,
        string DirectorId,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );