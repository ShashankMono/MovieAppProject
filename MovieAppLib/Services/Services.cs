using MovieAppLib.Exceptions;
using MovieAppLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLib.Services
{
    public class Services
    {
        static List<Movie> movies = DataSerializer.Deserialization();

        public static Movie FindMovieById(int id)
        {

            Movie movie = movies.Where(movie => movie.MovieId == id).FirstOrDefault();

            if (movie == null)
            {
                throw new InvalidIdException("Invalid Id!");
            }
            return movie;
        }

        public static Movie FindMovieByName(string name)
        {

            Movie movie = movies.Where(movie => movie.MovieName == name).FirstOrDefault();

            if (movie == null)
            {
                throw new InvalidNameException("Invalid Name!");
            }
            return movie;
        }
        public static void CheckMovieStackIsEmpty()
        {
            if (movies.Count == 0)
            {
                throw new MovieStackIsEmptyException("Movie stack is Empty!");
            }
        }

        public static string SendMovieInfo(Movie movie)
        {
            return $"\nMovie Id: {movie.MovieId}\n" +
                    $"Movie Name: {movie.MovieName}\n" +
                    $"Movie Gnere: {movie.MovieGenre}\n" +
                    $"Movie release year: {movie.MovieYear}\n" +
                    $"==================================\n"; ;
        }

        public static string ClearingAllMovieInfo()
        {
            movies.Clear();
            return "Cleared All Movies!";
        }

        public static string AddingNewMovie(int mId, string mName, string mGenre, int mYear)
        {

            Movie movie = new Movie(mId, mName, mGenre, mYear);
            movies.Add(movie);
            return "Movie Added Sucessfully!";
        }

        public static void CheckMovieStackIsFull()
        {
            if (movies.Count == 5)
            {
                throw new MovieStackFullException("Movie stack is full!");
            }
        }

        public static void StoreMovie()
        {
            DataSerializer.Serialization(movies);
        }

        public static string DeleteMovie(Movie movie)
        {
            movies.Remove(movie);
            return "Movie deleted sucessfully!";
        }

        public static string SendAllMovieInfo()
        {
            StringBuilder result = new StringBuilder();
            foreach (Movie movie in movies)
            {
                result.Append(SendMovieInfo(movie)+"\n");
            }
            return result.ToString();
        }

        public static string ChangeMovieName(Movie movie,string name)
        {
            movie.MovieName = name;
            return "Name changed sucessfully!";
        }
        public static string ChangeMovieGenre(Movie movie, string genre)
        {
            movie.MovieGenre = genre;
            return "Genre changed sucessfully!";
        }
        public static string ChangeMovieYear(Movie movie, int year)
        {
            movie.MovieYear = year;
            return "Year changed sucessfully!";
        }
        public static string ChangeMovieId(Movie movie, int Id)
        {
            movie.MovieId = Id;
            return "Id changed sucessfully!";
        }
    }
}
