namespace MoviesRental.Query.Domain.Models;
public class Dvd
{
    public string Id { get; set; }
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public DateTime Publisher { get; private set; }
    public bool IsAvailable { get; private set; }
    public int Copies { get; private set; }
    public string DirectorId { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
