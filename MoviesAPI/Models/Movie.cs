namespace MoviesAPI.Models
{
    public class Movie
    {
        public Guid? Id { get; set; }

        public string? Title { get; set; }

        public string? MovieLanguage { get; set; }

        public string? ReleaseYear { get; set; }

        public string? OTT { get; set; }

    }
}
