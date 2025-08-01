﻿namespace MoviesRental.Domain.Entities.Read;
public class DvdRead
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime Publisher { get; set; }
    public bool IsAvailable { get; set; }
    public int Copies { get; set; }
    public string DirectorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
