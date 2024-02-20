using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRating.Models;
using FilmRatingApp.Services;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingApp.ViewModels;

public partial class UtilisateurViewModel : ObservableObject
{
    private Utilisateur utilisateurSearch;
    public Utilisateur UtilisateurSearch
    {
        get
        {
            return utilisateurSearch;
        } set
        {
            utilisateurSearch = value;
            OnPropertyChanged();
        }
    }
    private string searchMail;
    public string SearchMail
    {
        get
        {
            return searchMail; 
        }
        set
        {
            searchMail = value;
            OnPropertyChanged();
        }
    }

    public IRelayCommand BtnSearchUtilisateurCommand { get; }
    public UtilisateurViewModel()
    {
        UtilisateurSearch = new Utilisateur();
        BtnSearchUtilisateurCommand = new RelayCommand(ActionSearchUtilisateur);
    }

    public async void ActionSearchUtilisateur()
    {
        WSService wsserivce = new WSService("http://localhost:5054/api/");
        Utilisateur u = await wsserivce.GetUtilisateurEmailAsync("Utilisateurs", SearchMail);
        if (u == null)
        {
            await ShowMessage("Recherche", "Aucun utilisateur n'a été trouvé");
            return;
        }
        UtilisateurSearch = u;
    }

    private async Task ShowMessage(string title, string message)
    {

        ContentDialog contentDialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "Ok"
        };

        contentDialog.XamlRoot = App.MainRoot.XamlRoot;


        ContentDialogResult result = await contentDialog.ShowAsync();
    }
}
