using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace FilmLibrary
{
    public static class FilmDatabase
    {
        public static void AddFilm(string filmTitle, string filmDescription, string filmDirector, string filmGenres)
        {
            using (var ctx = new FilmsContextClass())
            {
                FILMS film = new FILMS() { Title = filmTitle, Description = filmDescription, Director = filmDirector, Genre = filmGenres };

                ctx.Films.Add(film);
                ctx.SaveChanges();
            }
        }

        public static List<FILMS> GetFilm()
        {
            List<FILMS> filmsList = new List<FILMS>();

            using (var context = new FilmsContextClass())
            {
                foreach (var film in context.Films)
                {
                    filmsList.Add(film);
                }
            }
            return filmsList;
        }

        public static void EditFilm(int filmId, string filmTitle, string filmDescription, string filmDirector, string filmsGenre)
        {
            using (var context = new FilmsContextClass())
            {
                var original = context.Films.Find(filmId);

                original.Title = filmTitle;
                original.Description = filmDescription;
                original.Director = filmDirector;
                original.Genre = filmsGenre;
                context.SaveChanges();
            }
        }
    }
}
