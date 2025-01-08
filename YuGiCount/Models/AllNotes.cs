using System.Collections.ObjectModel;

namespace YuGiCount.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

    public AllNotes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<Note> notes = Directory
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(filename =>
            {
                var lines = File.ReadAllLines(filename);
                return new Note()
                {
                    Filename = filename,
                    Text = string.Join(Environment.NewLine, lines.Skip(1)),
                    Date = File.GetLastWriteTime(filename),
                    IsWin = lines.FirstOrDefault()?.Trim().ToUpper() switch
                    {
                        "WIN" => true,
                        "LOSS" => false,
                        _ => null
                    }
                };
            })
            .OrderBy(note => note.Date);

        foreach (Note note in notes)
            Notes.Add(note);
    }
}
