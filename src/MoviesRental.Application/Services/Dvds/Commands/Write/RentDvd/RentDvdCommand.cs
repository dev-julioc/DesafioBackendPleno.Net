﻿using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Write.RentDvd;
public record RentDvdCommand(Guid Id) : IRequest<ResultService<RentDvdResponse>>;
