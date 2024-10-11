namespace MoviesRental.Application.Services.Directors.Commands.Write.CreateDirector;
public record CreateDirectorReponse
    (
        string Id,
        string FullName,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
