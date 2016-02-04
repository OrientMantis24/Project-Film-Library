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
            Console.WriteLine("3. Edit a film");
            Console.WriteLine("4. Exit");
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
                myFoo = new Program.Foo(View.EditAFilm);
                myFoo();
            }
            else if (selection == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                myFoo = new Program.Foo(View.GenerateMenu);
                myFoo();
            }
        }
        public static void FilmList()
        {
            Console.Clear();

            int filmNumber = 1;

            Console.WriteLine("***All films in database***");
            foreach (Films aFilm in FilmDatabase.GetFilm())
            {
                Console.WriteLine(filmNumber + " " + aFilm.FilmTitle);
                filmNumber++;
            }
            
        }
        public static void ChooseAFilm()
        {
            FilmList();

            int filmNumber = 1;
            Console.WriteLine("Type a number of the movie you want to know more about");
            filmNumber = int.Parse(Console.ReadLine());

            DisplayFilm(filmNumber);
        }
        public static void DisplayFilm(int filmNumber)
        {
            int selectedFilm = 1;

            foreach (Films aFilm in FilmDatabase.GetFilm())
            {
                if(selectedFilm == filmNumber)
                {
                    Console.Clear();
                    Console.WriteLine(aFilm.FilmTitle);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(aFilm.FilmDescription);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(aFilm.FilmDirector);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(aFilm.FilmGenres);
                    //Console.WriteLine("Press any button to continue...");
                    //Console.ReadLine();
                    break;
                }
                
                selectedFilm++;
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
        public static void EditAFilm()
        {
            FilmList();

            int filmNumber = 1;
            Console.WriteLine("What film do you want to edit?");
            filmNumber = int.Parse(Console.ReadLine());

            int selectedFilm = 1;

            foreach (Films aFilm in FilmDatabase.GetFilm())
            {
                if (selectedFilm == filmNumber)
                {
                    string filmTitle, filmDescription, filmDirector, filmsGenres;

                    Console.Clear();
                    Console.WriteLine("Old title:");
                    Console.WriteLine(aFilm.FilmTitle);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New title:");
                    filmTitle = Console.ReadLine().ToString();


                    Console.Clear();
                    Console.WriteLine("Old description:");
                    Console.WriteLine(aFilm.FilmDescription);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New description:");
                    filmDescription = Console.ReadLine().ToString();

                    Console.Clear();
                    Console.WriteLine("Old director:");
                    Console.WriteLine(aFilm.FilmDirector);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New director:");
                    filmDirector = Console.ReadLine().ToString();

                    Console.Clear();
                    Console.WriteLine("Old genre:");
                    Console.WriteLine(aFilm.FilmGenres);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New genre:");
                    filmsGenres = Console.ReadLine().ToString();

                    FilmDatabase.EditFilm(aFilm.FilmId, filmTitle, filmDescription, filmDirector, filmsGenres);

                    break;
                }
                selectedFilm++;
            }
        }
    }
}