﻿namespace MoviesRental.Application.Services.Dvds.Commands.UpdateDvd;
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
