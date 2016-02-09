using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FilmLibrary
{
    public class FilmsContextClass : DbContext
    {
        public DbSet<FILMS> Films { get; set;}
    }
}
