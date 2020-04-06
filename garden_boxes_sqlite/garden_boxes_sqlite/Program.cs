using System;
using System.Data;
using Mono.Data.Sqlite;

namespace garden_boxes_sqlite
{
    class MainClass

    {
        static string veggieChoice(int area, string userChoice)
        {
            // create and open a db connection
            string connectionString = @"Data Source=/Users/stacy/Projects/gardenbox_db/garden-boxes/database.sqlite";
            SqliteConnection connection = new SqliteConnection(connectionString);
            //connection.Open();
            connection.Open();
            
            Console.WriteLine($"You picked " + (userChoice) + "!");
            //Get calc from data base
           
            string sql = $"SELECT PlantPoss FROM Veggies1 WHERE SeedType = '{userChoice}'";
            
            SqliteCommand command = new SqliteCommand(sql, connection);
 
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();

            string result;

            if (reader.IsDBNull(reader.GetOrdinal("PlantPoss")))
            {
                result = $"{userChoice} not currently available. Please select an option from the menu.";
            }
            else
            {
                double plantPoss = reader.GetDouble(reader.GetOrdinal("PlantPoss"));
                reader.Close();

                connection.Close();
                result = ($"You can plant " + (area * plantPoss) + " " + (userChoice) + " in your garden!");
            }
            return result;
        }

        static int GetLength()
        {
            Console.WriteLine("How long is your garden box?");
            string userInput = Console.ReadLine();
            int length = Convert.ToInt32(userInput);
            return length;
        }

        static int GetWidth()
        {
            Console.WriteLine("How wide is your garden box?");
            string userInput = Console.ReadLine();
            int width = Convert.ToInt32(userInput);
            return width;
        }

        static int SetArea(int length, int width)
        {  
            int area = length * width;
            return area;
        }

        static int SetPerimeter(int length, int width)
        {
            int perimeter = (2 * length) + (2 * width);
            return perimeter;
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Garden Boxes!");

            //Call get length function
            int length = GetLength();
            //print out length
            Console.WriteLine("The length of your item is " + length);

            //Call get width function
            int width = GetWidth();
            //print out width
            Console.WriteLine("The width of your item is " + width);

            //Call area function
            int area = SetArea(length, width);
            //print area
            Console.WriteLine("Your garden box area is " + area);

            //Call perimeter function
            int perimeter = SetPerimeter(length, width);
            //print area
            Console.WriteLine("Your garden box perimeter is " + perimeter);

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

                if (userChoice == "quit")
                {
                   break;
                }
                else
                {
                   string result = veggieChoice(area, userChoice);
                   Console.WriteLine(result);
                }

            }

        }
    
    }
}
