using System;
using System.Data;
using Mono.Data.Sqlite;

namespace garden_boxes_sqlite
{
    class MainClass

    {
        
        public static void Main(string[] args)
        {

            // create and open a db connection
            string connectionString = @"Data Source=/Users/stacy/Projects/gardenbox_db/garden-boxes/database.sqlite";
            SqliteConnection connection = new SqliteConnection(connectionString);
            //connection.Open();
            connection.Open();

            Console.WriteLine("Welcome to Garden Boxes!");

          
            string length;
            Console.WriteLine("Enter the length of your box: ");
            length = Console.ReadLine();
            int userIntLength = Convert.ToInt32(length);

            string width;
            Console.WriteLine("Enter the width of your box: ");
            width = Console.ReadLine();
            int userIntWidth = Convert.ToInt32(width);

            int area;
            area = userIntWidth * userIntLength;
            Console.WriteLine("Your garden box area is: " + area + " and the perimeter of your box is: " + ((2 * userIntLength) + (2 * userIntWidth)) + ".");



            //use database to read back that number of veggies that can be planted
            while (true)
            {
                //present a menu of vegetables to plant
                Console.WriteLine("What vegetable would you like to plant? Or choose Quit to End");
                Console.WriteLine("Carrots");
                Console.WriteLine("Corn");
                Console.WriteLine("Beets");
                Console.WriteLine("Quit");

                //get Veggie choice and convert to lower
                string userChoice = Console.ReadLine().ToLower();

                if (userChoice == "carrots")
                {
                    Console.WriteLine($"You picked " + (userChoice) + " !");
                    //Get Carrot calc from data base
                    string sql = $"SELECT PlantPoss FROM Veggies1 WHERE SeedType = '{userChoice}'";
                    SqliteCommand command = new SqliteCommand(sql, connection);
                    SqliteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    //int plantPoss = Convert.ToInt32(reader["PlantPoss"]);
                    double plantPoss = reader.GetDouble(reader.GetOrdinal("PlantPoss"));
                    Console.WriteLine($"You can plant " + (area * plantPoss) + (userChoice) + " in your garden!");
                    reader.Close();
                }

                else if (userChoice == "corn")
                {
                    Console.WriteLine($"You picked " + (userChoice) + " !");
                    //Get Corn calc from data base
                    string sql = $"SELECT PlantPoss FROM Veggies1 WHERE SeedType = '{userChoice}'";
                    SqliteCommand command = new SqliteCommand(sql, connection);
                    SqliteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    double plantPoss = reader.GetDouble(reader.GetOrdinal("PlantPoss"));
                  

                    Console.WriteLine($"You can plant " + (area * plantPoss) + (userChoice) + " in your garden!");
                    reader.Close();
                }

                else if (userChoice == "beets")
                {
                    Console.WriteLine($"You picked " + (userChoice) + " !");
                    //Get Beets calc from data base
                    string sql = $"SELECT PlantPoss FROM Veggies1 WHERE SeedType = '{userChoice}'";
                    SqliteCommand command = new SqliteCommand(sql, connection);
                    SqliteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    double plantPoss = reader.GetDouble(reader.GetOrdinal("PlantPoss"));
                   

                    Console.WriteLine($"You can plant " + (area * plantPoss) + (userChoice) + " in your garden!");
                    reader.Close();
                }

                else if (userChoice == "quit")
                {
                    break;
                }

                else
                    Console.WriteLine("I don't know what  " + userChoice + " are. Please enter one of the listed options.");

            }


            connection.Close();
        }
        
    }
}
