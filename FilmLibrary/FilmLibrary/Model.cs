namespace FilmLibrary
{
    class Model
    {
        public static void AddAFilm(string filmTitle, string filmDescription, string filmDirector, string filmGenres)
        {
            FilmDatabase.AddFilm(filmTitle, filmDescription, filmDirector, filmGenres);
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
