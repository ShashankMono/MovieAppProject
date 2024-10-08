using MovieAppLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieAppLib.Services
{
    public class DataSerializer
    {
        public static string path = @"D:\monocept_c# learning\Assignment\MoviePorject\MovieAppLib\Store.json";
        public static void Serialization(List<Movie> movies)
        {
            string jsonString = JsonSerializer.Serialize(movies);
            using (StreamWriter sr = new StreamWriter(path))
            {
                sr.WriteLine(jsonString);
            }
        }

        public static List<Movie> Deserialization()
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Movie>>(jsonString);
            }
            return new List<Movie>();
        }
    }
}
