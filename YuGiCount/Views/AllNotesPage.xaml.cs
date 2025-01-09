namespace YuGiCount.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();
        BindingContext = new Models.AllNotes();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        string appDataPath = FileSystem.AppDataDirectory;
        string newFileName = Path.Combine(appDataPath, $"{Guid.NewGuid()}.notes.txt");

        await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={newFileName}");
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var selectedNote = (Models.Note)e.CurrentSelection[0];
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={selectedNote.Filename}");
            notesCollection.SelectedItem = null; // Clear selection after navigation.
        }
    }
}
