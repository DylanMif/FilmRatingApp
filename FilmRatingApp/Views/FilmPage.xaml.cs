using FilmRatingApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FilmRatingApp.Views;

public sealed partial class FilmPage : Page
{
    public FilmViewModel ViewModel
    {
        get;
    }

    public FilmPage()
    {
        ViewModel = App.GetService<FilmViewModel>();
        InitializeComponent();
    }
}
