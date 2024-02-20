using FilmRatingApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FilmRatingApp.Views;

public sealed partial class UtilisateurPage : Page
{
    public UtilisateurViewModel ViewModel
    {
        get;
    }

    public UtilisateurPage()
    {
        InitializeComponent();
        ViewModel = App.GetService<UtilisateurViewModel>();
        DataContext = ViewModel;
    }
}
