using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary
{
    class View
    {

        public static void GenerateMenu()
        {
            Console.Clear();

            Program.Foo myFoo;

            int selection = 0;

            Console.WriteLine("****Menu***");
            Console.WriteLine("1. Choose film");
            Console.WriteLine("2. Add a film");
            Console.WriteLine("3. Exit");
            selection = int.Parse(Console.ReadLine());


            if (selection == 1)
            {
                myFoo = new Program.Foo(View.ChooseAFilm);
                myFoo();
            }
            else if (selection == 2)
            {
                myFoo = new Program.Foo(View.AddAFilm);
                myFoo();
            }
            else if (selection == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                myFoo = new Program.Foo(View.GenerateMenu);
                myFoo();
            }
        }
        public static void ChooseAFilm()
        {
            Console.Clear();

            int filmNumber = 1;
            Console.WriteLine("***All films in database***");
            foreach (Films aFilm in FilmDatabase.GetFilm())
            {
                Console.WriteLine(filmNumber + " " + aFilm.FilmTitle);
                filmNumber++;
            }

            
            BackExit();
        }

        public static void AddAFilm()
        {
            Console.Clear();

            string filmTitle;
            string filmDescription;
            string filmDirector; 
            string filmGenres;

            Console.WriteLine("Please write title of the film");
            filmTitle = Console.ReadLine().ToString();
            Console.Clear();

            Console.WriteLine("Please write description of the film");
            filmDescription = Console.ReadLine().ToString();
            Console.Clear();

            Console.WriteLine("Please write director of the film");
            filmDirector = Console.ReadLine().ToString();
            Console.Clear();

            Console.WriteLine("Please write genree of the film");
            filmGenres = Console.ReadLine().ToString();
            Console.Clear();

            Model.AddAFilm(filmTitle, filmDescription, filmDirector, filmGenres);

            BackExit();
        }
            
        public static void BackExit()
        {


            Program.Foo myFoo;
            int selection = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Main Menu");
            Console.WriteLine("2. Exit");
            selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                myFoo = new Program.Foo(View.GenerateMenu);
                myFoo();
            }
            if (selection == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                myFoo = new Program.Foo(View.ChooseAFilm);
                myFoo();         
       
            }
        }
    }
}
