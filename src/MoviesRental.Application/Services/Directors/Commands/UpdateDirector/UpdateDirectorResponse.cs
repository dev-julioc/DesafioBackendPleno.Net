namespace MoviesRental.Application.Services.Directors.Commands.UpdateDirector;
public record UpdateDirectorResponse
    (
        string Id, 
        string FullName,
        DateTime UpdatedAt
    );
