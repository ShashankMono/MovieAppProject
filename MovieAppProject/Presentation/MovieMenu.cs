using MovieAppLib.Exceptions;
using MovieAppLib.Models;
using MovieAppLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppProject.Presentation
{
    public class MovieMenu
    {
        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome! to Movies App\n" +
                    $"Choose option\n" +
                    $"1.Display Movie by Id\n" +
                    $"2.Add Movie\n" +
                    $"3.Clear All\n" +
                    $"4.Display movie by name\n" +
                    $"5.Delete movie by id\n" +
                    $"6.Display all movies\n" +
                    $"7.Edit movie\n" +
                    $"8.Exit\n");
                int choice = int.Parse(Console.ReadLine());
                RunCasesOfMovieApp(choice);
            }
        }

        public static void RunCasesOfMovieApp(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayMovieById();
                    break;

                case 2:
                    AddMovie();
                    break;

                case 3:
                    Console.WriteLine(Services.ClearingAllMovieInfo());
                    break;

                case 4:
                    DisplayMovieByName();
                    break;

                case 5:
                    DeleteMovieById();
                    break;

                case 6:
                    DisplayAllMovies();
                    break;

                case 7:
                    EditMovieMenu();
                    break;

                case 8:
                    Services.StoreMovie();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("please choose correct option\n");
                    break;

            }
        }

        public static Movie GetMovieById()
        {
            Movie movie = null;
            try
            {
                Services.CheckMovieStackIsEmpty();
                Console.WriteLine("Enter Movie ID:");
                int id = int.Parse(Console.ReadLine());

                 movie = Services.FindMovieById(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return movie;
        }

        public static void DisplayMovieById() {
            Movie movie = GetMovieById();
            if(movie != null)
            {
                Console.WriteLine(Services.SendMovieInfo(movie));
            }
        }

        public static void DeleteMovieById()
        {
            Movie movie = GetMovieById();
            if (movie != null) { 
                Console.WriteLine(Services.DeleteMovie(movie));
            }
        }

        public static void AddMovie()
        {
            try
            {
                Services.CheckMovieStackIsFull();

                Console.WriteLine("Enter movie Id:\n");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter movie name:\n");
                string name = Console.ReadLine();
                Console.WriteLine("Enter genre of movie:\n");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter release year of movie:\n");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine(Services.AddingNewMovie(id, name, genre, year));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void DisplayMovieByName()
        {
            try
            {
                Services.CheckMovieStackIsEmpty();
                Console.WriteLine("Enter Movie Name:");
                string name = Console.ReadLine();

                Movie movie = Services.FindMovieByName(name);
                Console.WriteLine(Services.SendMovieInfo(movie));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DisplayAllMovies()
        {
            try
            {
                Services.CheckMovieStackIsEmpty();
                Console.WriteLine(Services.SendAllMovieInfo());
            }catch(Exception m)
            {
                Console.WriteLine(m.Message);
            }
        }

        public static void EditMovieMenu()
        {
            Movie movie = GetMovieById();
            if(movie != null)
            {
                while (true)
                {
                    Console.WriteLine($"\nEditing details of \"{movie.MovieName}\" movie!\n" +
                        $"1.Edit movie Id\n" +
                        $"2.Edit movie genre\n" +
                        $"3.Edit movie year\n" +
                        $"4.Edit movie name\n" +
                        $"5.Back to main menu\n");
                    int choice = int.Parse(Console.ReadLine());
                    ExecuteEditMovieCases(choice,movie);
                }
                
            }
        }

        public static void ExecuteEditMovieCases(int choice,Movie movie)
        {
            //Not creating new function because callStack can be full after some time
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter new id:");
                    int id = int.Parse(Console.ReadLine());
                    Services.ChangeMovieId(movie,id);
                    break;

                case 2:
                    Console.WriteLine("Enter new Genre:");
                    string genre = Console.ReadLine();
                    Services.ChangeMovieGenre(movie, genre);
                    break;

                case 3:
                    Console.WriteLine("Enter new year:");
                    int year = int.Parse(Console.ReadLine());
                    Services.ChangeMovieYear(movie, year);
                    break;

                case 4:
                    Console.WriteLine("Enter new Name:");
                    string name = Console.ReadLine();
                    Services.ChangeMovieName(movie, name);
                    break;

                case 5:
                    DisplayMenu();
                    break;
            }
        }
    }
}
