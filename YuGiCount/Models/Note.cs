using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YuGiCount.Models;

internal class Note : INotifyPropertyChanged
{
    private bool? _isWin; // Nullable to handle the "nothing selected" state.

    public string Filename { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public bool? IsWin
    {
        get => _isWin;
        set
        {
            if (_isWin != value)
            {
                _isWin = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
