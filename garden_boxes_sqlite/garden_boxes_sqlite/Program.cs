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
            string connectionString = @"Data Source=/Users/stacy/Documents/Academy_Pgh/Projects/gardenbox_db/garden-boxes/database.sqlite";
            
            SqliteConnection connection = new SqliteConnection(connectionString);
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

        //static int Measurements(int length, int width)
        //{
            //Console.WriteLine("How long is your garden box?");
            //string userLength = Console.ReadLine();
            //int uLength = Convert.ToInt32(userLength);


            //Console.WriteLine("How wide is your garden box?");
            //string userWidth = Console.ReadLine();
            //int uWidth = Convert.ToInt32(userWidth);
            //    return uWidth && uLength;

            //}

            //    static int GetLength()
            //{
            //    Console.WriteLine("How long is your garden box?");
            //    string userInput = Console.ReadLine();
            //    int length = Convert.ToInt32(userInput);
            //    return length;
            //}

            //static int GetWidth()
            //{
            //    Console.WriteLine("How wide is your garden box?");
            //    string userInput = Console.ReadLine();
            //    int width = Convert.ToInt32(userInput);
            //    return width;
            //}

            static int SetArea(int uLength, int uWidth)
        {  
            int area = uLength * uWidth;
            return area;
        }

        static int SetPerimeter(int uLength, int uWidth)
        {
            int perimeter = (2 * uLength) + (2 * uWidth);
            return perimeter;
        }

        public static void Main(string[] args)
        {
        

            Console.WriteLine("Welcome to Garden Boxes!");

            Console.WriteLine("How long is your garden box?");
            string userLength = Console.ReadLine();
            int uLength = Convert.ToInt32(userLength);

            Console.WriteLine("How wide is your garden box?");
            string userWidth = Console.ReadLine();
            int uWidth = Convert.ToInt32(userWidth);

            //Call measurement function
            //int size = Measurements(int length, int width);
            //print out length
            //Console.WriteLine("The length of your item is " + length);
            //Console.WriteLine("The width of your item is " + width);

            //Call get width function
            //int width = userWidth();
            //print out width
            //Console.WriteLine("The width of your item is " + width);

            //Call area function
            int area = SetArea(uLength, uWidth);
            //print area
            Console.WriteLine("Your garden box area is " + area);

            //Call perimeter function
            int perimeter = SetPerimeter(uLength, uWidth);
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
