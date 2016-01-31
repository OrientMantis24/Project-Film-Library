using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary
{
    public class Films
    {
        private int filmId;
        private string filmTitle;
        private string filmDescription;
        private string filmDirector;
        private string filmGenres;

        public Films() { }

        public int FilmId {
            get { return filmId; }
            set { filmId = value; }
        }

        public string FilmTitle
        {
            get { return filmTitle; }
            set { filmTitle = value; }
        }

        public string FilmDescription
        {
            get { return filmDescription; }
            set { filmDescription = value; }
        }

        public string FilmDirector
        {
            get { return filmDirector; }
            set { filmDirector = value; }
        }

        public string FilmGenres
        {
            get { return filmGenres; }
            set { filmGenres = value; }
        }
    }
}
