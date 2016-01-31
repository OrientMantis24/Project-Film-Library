using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary
{
    class Program
    {
        public delegate void Foo();
        static void Main(string[] args)
        {
            View.GenerateMenu();
        }
    }
}
