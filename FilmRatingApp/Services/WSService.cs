using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FilmRating.Models;

namespace FilmRatingApp.Services;
public class WSService : IService
{
    private HttpClient client;

    public HttpClient Client
    {
        get
        {
            return client;
        }
        set
        {
            client = value;
        }
    }

    public WSService(string uri)
    {
        Client = new HttpClient();
        Client.BaseAddress = new Uri(uri);
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    public WSService() : this("http://localhost:5054/api/") { }

    public async Task<List<Utilisateur>> GetSeriesAsync(string nomControleur)
    {
        try
        {
            return await Client.GetFromJsonAsync<List<Utilisateur>>(String.Concat(nomControleur, "/GetUtilisateurs"));
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Utilisateur> GetUtilisateurEmailAsync(string nomControleur, string email)
    {
        try
        {
            string s = String.Concat(nomControleur, "/GetUtilisateurByEmail/", email);
            return await Client.GetFromJsonAsync<Utilisateur>(s);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Utilisateur> GetSerieAsync(string nomControleur, int serieId)
    {
        try
        {
            return await Client.GetFromJsonAsync<Utilisateur>(String.Concat(nomControleur, "/", serieId));
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> PostSerieAsync(string nomControleur, Utilisateur serie)
    {
        var response = await Client.PostAsJsonAsync(nomControleur, serie);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteSerieAsync(string nomControler, Utilisateur serie)
    {
        var response = await Client.DeleteAsync(String.Concat(nomControler, "/", serie.UtilisateurId));
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditSerieAsync(string nomControler, int idToEdit, Utilisateur serie)
    {
        var response = await Client.PutAsJsonAsync(String.Concat(nomControler, "/", idToEdit), serie);
        return response.IsSuccessStatusCode;
    }
}
