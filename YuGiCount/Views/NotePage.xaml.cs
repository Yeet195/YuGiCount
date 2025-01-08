namespace YuGiCount.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

	public string ItemId
	{
		set { LoadNote(value); }
	}

	public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName}.notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            var lines = new List<string>
        {
            note.IsWin == true ? "WIN" : "LOSS",
            TextEditor.Text
        };
            File.WriteAllLines(note.Filename, lines);
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.Note note)
		{
			if (File.Exists(note.Filename))
				File.Delete(note.Filename);
		}

		await Shell.Current.GoToAsync("..");
	}

	private void LoadNote(string fileName)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.Filename = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;

	}
}