namespace YuGiCount.Models;

internal class Note
{
    public string Filename { get; set; } = string.Empty; // Ensure non-null default value.
    public string? Text { get; set; } // Allow null for optional text.
    public DateTime Date { get; set; }
    public bool? IsWin { get; set; } // Nullable to handle undefined states.
}
