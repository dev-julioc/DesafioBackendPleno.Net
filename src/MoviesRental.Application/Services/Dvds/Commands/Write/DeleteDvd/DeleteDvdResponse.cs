namespace MoviesRental.Application.Services.Dvds.Commands.Write.DeleteDvd;
public record DeleteDvdResponse
    (
        string Id,
        DateTime DeleteAt
    );
