using System.Collections.ObjectModel;

namespace YuGiCount.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

    private bool? GetWinStateFromFile(string filename)
    {
        string fileContent = File.ReadAllText(filename);

        // Assuming the file format includes a "win" or "loss" marker
        if (fileContent.Contains("[WIN]"))
            return true;
        if (fileContent.Contains("[LOSS]"))
            return false;

        return null; // Default to "no selection".
    }

    public void LoadNotes()
    {
        Notes.Clear();

        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<Note> notes = Directory
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(filename => new Note()
            {
                Filename = filename,
                Text = File.ReadAllText(filename),
                Date = File.GetLastWriteTime(filename),
                IsWin = GetWinStateFromFile(filename) // Custom method to load state.
            })
            .OrderBy(note => note.Date);

        foreach (Note note in notes)
            Notes.Add(note);
    }
}
