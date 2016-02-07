using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary
{
    class View

    {
        public static void ChooseOption()
        {
            Console.Clear();

            Program.Foo myFoo;

            int selection = 0;

            Console.WriteLine("****Menu***");
            Console.WriteLine("1. Film list");
            Console.WriteLine("2. Choose film");
            Console.WriteLine("3. Add a film");
            Console.WriteLine("4. Edit a film");
            Console.WriteLine("5. Search for a film");
            Console.WriteLine("6. Exit");
            selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    myFoo = FilmList;
                    myFoo();
                    BackExit();
                    break;
                case 2:
                    myFoo = ChooseAFilm;
                    myFoo();
                    break;
                case 3:
                    myFoo = AddAFilm;
                    myFoo();
                    break;
                case 4:
                    myFoo = EditAFilm;
                    myFoo();
                    break;
                case 5:
                    myFoo = SearchAFilm;
                    myFoo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    myFoo = ChooseOption;
                    myFoo();
                    break;
            }
        }
        public static void FilmList()
        {
            Console.Clear();

            Console.WriteLine();

            int filmNumber = 1;

            Console.WriteLine("***All films in database***");
            Console.WriteLine();

            foreach (FILMS aFilm in FilmDatabase.GetFilm())
            {
                Console.WriteLine(filmNumber + " " + aFilm.Title);
                filmNumber++;
            }

            
            
        }
        public static void ChooseAFilm()
        {
            FilmList();

            int  displayedFilm = 1;
            Console.WriteLine("Type a number of the movie you want to know more about");
            int filmNumber = int.Parse(Console.ReadLine());

            foreach (FILMS aFilm in FilmDatabase.GetFilm())
            {
                if (displayedFilm == filmNumber)
                    DisplayFilm(aFilm);
                else
                    displayedFilm++;
            }
        }
        public static void DisplayFilm(FILMS aFilm)
        {
                    Console.Clear();
                    Console.WriteLine(aFilm.Title);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(aFilm.Description);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(aFilm.Director);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(aFilm.Genres);
            

            BackExit();
        }
        public static void AddAFilm()
        {
            Console.Clear();

            Console.WriteLine("Please write title of the film");
            string filmTitle = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please write description of the film");
            string filmDescription = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please write director of the film");
            string filmDirector = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please write genre of the film");
            string filmGenres = Console.ReadLine();
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
                myFoo = new Program.Foo(View.ChooseOption);
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

            foreach (FILMS aFilm in FilmDatabase.GetFilm())
            {
                if (selectedFilm == filmNumber)
                {
                    string filmTitle, filmDescription, filmDirector, filmsGenres;

                    Console.Clear();
                    Console.WriteLine("Old title:");
                    Console.WriteLine(aFilm.Title);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New title:");
                    filmTitle = Console.ReadLine().ToString();


                    Console.Clear();
                    Console.WriteLine("Old description:");
                    Console.WriteLine(aFilm.Description);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New description:");
                    filmDescription = Console.ReadLine().ToString();

                    Console.Clear();
                    Console.WriteLine("Old director:");
                    Console.WriteLine(aFilm.Director);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New director:");
                    filmDirector = Console.ReadLine().ToString();

                    Console.Clear();
                    Console.WriteLine("Old genre:");
                    Console.WriteLine(aFilm.Genres);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("New genre:");
                    filmsGenres = Console.ReadLine().ToString();

                    FilmDatabase.EditFilm(aFilm.Id, filmTitle, filmDescription, filmDirector, filmsGenres);

                    break;
                }
                selectedFilm++;
            }

            Console.Clear();
            BackExit();
        }
        public static void SearchAFilm()
        {
            Console.WriteLine("Write a title of the film");
            string filmTitle = Console.ReadLine().ToString();

            if (Model.SearchForAFilm(filmTitle) != null)
                DisplayFilm(Model.SearchForAFilm(filmTitle));
            else
                Console.WriteLine("No films found :(");

            Console.ReadLine();
        }
    }
}