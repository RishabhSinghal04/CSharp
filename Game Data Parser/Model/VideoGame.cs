
namespace GameDataParser.Model;

public class VideoGame
{
    public string? Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() =>
        $"{Title}\n\t Year : {ReleaseYear} \t Rating : {Rating}";
}

/* public class Game
{
    private const int InitialYear = 1970;
    private const double LowestRating = 0.0, HighestRating = 5.0;
    private string? _title;
    private int _releaseYear;
    private double _rating;

    public string? Title
    {
        get { return _title; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException("Title cannot be null or empty");
            }
            _title = value;
        }
    }

    public int ReleaseYear
    {
        get { return _releaseYear; }
        set
        {
            if (!int.TryParse(value.ToString(), out _releaseYear))
            {
                throw new ArgumentException("Invalid Value");
            }
            if (value < InitialYear || value > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException(
                    $"Release year must be between {InitialYear} and the current year");
            }
            _releaseYear = value;
        }
    }

    public double Rating
    {
        get { return _rating; }
        set
        {
            if (!double.TryParse(value.ToString(), out _rating))
            {
                throw new ArgumentException("Invalid Value");
            }
            if (value < LowestRating || value > HighestRating)
            {
                throw new ArgumentOutOfRangeException(
                    $"Rating must be between {LowestRating} and {HighestRating}");
            }
            _rating = value;
        }
    }
} */