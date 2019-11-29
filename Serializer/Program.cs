using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serializer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Game> games = new List<Game>
            {
                new Game {Title = "The Elder Scrolls III: Morrowind", Company = new Company {Name = "Bethesda"}, Price = 600},
                new Game {Title = "Gothic 2", Company = new Company{Name = "Piranha Bytes"}, Price = 300},
                new Game {Title = "Dark Souls 3", Company = new Company{Name = "From Software"}, Price = 1200 }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));

            using (Stream stream = new FileStream("games.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, games);
            }

            using (Stream stream = new FileStream("games.xml", FileMode.OpenOrCreate))
            {
                List<Game> newGames = (List<Game>)serializer.Deserialize(stream);

                foreach (Game game in newGames)
                    Console.WriteLine($"Title: {game.Title} - Company: {game.Company.Name} - Price: {game.Price}");
            }
        }
        public class Game
        {
            public string Title { get; set; }
            public Company Company { get; set; }
            public decimal Price { get; set; }
            public Game() { }
        }

        public class Company
        {
            public string Name { get; set; }
        }
    }
}
