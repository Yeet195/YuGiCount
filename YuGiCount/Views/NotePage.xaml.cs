namespace YuGiCount.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId { get; set; } = string.Empty;

    public NotePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!string.IsNullOrEmpty(ItemId))
        {
            LoadNote();
        }
    }

    private void WinButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            note.IsWin = true;
            // Ensure UI is updated by notifying the UI of the property change.
            OnPropertyChanged(nameof(note.IsWin));
        }
    }

    private void LossButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            note.IsWin = false;
            // Ensure UI is updated by notifying the UI of the property change.
            OnPropertyChanged(nameof(note.IsWin));
        }
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Update the note file with the current win/loss state and text.
            string content = $"{(note.IsWin == true ? "[WIN]" : note.IsWin == false ? "[LOSS]" : "[UNDEFINED]")}\n{TextEditor.Text}";
            File.WriteAllText(note.Filename, content);

            await Shell.Current.GoToAsync("..");
        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note && File.Exists(note.Filename))
        {
            File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote()
    {
        if (File.Exists(ItemId))
        {
            BindingContext = new Models.Note
            {
                Filename = ItemId,
                Text = File.ReadAllText(ItemId),
                Date = File.GetCreationTime(ItemId)
            };
        }
        else
        {
            BindingContext = new Models.Note
            {
                Filename = ItemId,
                Date = DateTime.Now
            };
        }
    }
}
