namespace MoviesRental.Application.Services.Directors.Commands.CreateDirector;
public record CreateDirectorReponse
    (
        string Id,
        string FullName,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
