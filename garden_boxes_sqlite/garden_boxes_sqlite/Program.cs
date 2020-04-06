using System;
using System.Data;
using Mono.Data.Sqlite;

namespace garden_boxes_sqlite
{
    class MainClass

    {
        static void veggieChoice(int area, string userChoice)
        {
            // create and open a db connection
            string connectionString = @"Data Source=/Users/stacy/Projects/gardenbox_db/garden-boxes/database.sqlite";
            SqliteConnection connection = new SqliteConnection(connectionString);
            //connection.Open();
            connection.Open();
            
            Console.WriteLine($"You picked " + (userChoice) + " !");
            //Get calc from data base
            //$"SELECT PlantPoss FROM Veggies1 WHERE SeedType = '{userChoice}'";

            string sql = $"IF SeedType = '{userChoice}' BEGIN SELECT PlantPoss FROM Veggies1 END ELSE BEGIN PRINT 'I am not sure what '{userChoice}' are.  Please select from menu of veggies.'";




            SqliteCommand command = new SqliteCommand(sql, connection);
 
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();
            double plantPoss = reader.GetDouble(reader.GetOrdinal("PlantPoss"));

            
            Console.WriteLine($"You can plant " + (area * plantPoss) + (userChoice) + " in your garden!");
            reader.Close();
            
            connection.Close();
        }
        
        public static void Main(string[] args)
        {

            

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


                if (userChoice == "quit")
                {
                    break;
                }

                else
                {
                    veggieChoice(area, userChoice);
                }

                

            }



        }

        

        
    }
}
