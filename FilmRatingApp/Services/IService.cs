using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRating.Models;
using FilmRatingApp.Models;

namespace FilmRatingApp.Services;
public interface IService
{
    public Task<List<Utilisateur>> GetSeriesAsync(string nomControleur);
    public Task<Utilisateur> GetSerieAsync(string nomControleur, int serieId);
}
