namespace MoviesRental.Application.Services.Dvds.Commands.DeleteDvd;
public record DeleteDvdResponse
    (
        string Id,
        DateTime DeleteAt
    );
