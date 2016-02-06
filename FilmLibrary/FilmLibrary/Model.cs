using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary
{
    class Model
    {
        public static void AddAFilm(string filmTitle, string filmDescription, string filmDirector, string filmGenres)
        {
            FilmDatabase.AddFilm(filmTitle, filmDescription, filmDirector, filmGenres);
            //View.AddAFilm();
        }

        public static FILMS SearchForAFilm(string filmTitle)
        {
            foreach (FILMS aFilm in FilmDatabase.GetFilm())
            {
                if(aFilm.Title == filmTitle)
                {
                    return aFilm;
                }
            }

            return null;
        }
    }
       
}
