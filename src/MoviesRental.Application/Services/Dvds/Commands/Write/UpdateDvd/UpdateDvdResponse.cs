namespace MoviesRental.Application.Services.Dvds.Commands.Write.UpdateDvd;
public record UpdateDvdResponse
    (
        string Id,
        string Title,
        string Genre,
        DateTime Published,
        int Copies,
        string DirectorId,
        DateTime UpdatedAt
    );
