namespace MoviesRental.Application.Services.Dvds.Queries;
public record GetDvdReponse
(
    string Id,
    string Title,
    string Genre,
    DateTime Publisher,
    int Copies,
    string DirectorId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
