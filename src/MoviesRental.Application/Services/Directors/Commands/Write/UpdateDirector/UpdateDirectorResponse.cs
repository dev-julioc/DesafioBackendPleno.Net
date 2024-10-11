namespace MoviesRental.Application.Services.Directors.Commands.Write.UpdateDirector;
public record UpdateDirectorResponse
    (
        string Id,
        string FullName,
        DateTime UpdatedAt
    );
