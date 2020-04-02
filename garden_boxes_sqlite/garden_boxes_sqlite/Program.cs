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

            //ask length and width
            string length;
            Console.WriteLine("Enter the length of your box: ");
            length = Console.ReadLine();
            int userIntLength = Convert.ToInt32(length);

            string width;
            Console.WriteLine("Enter the width of your box: ");
            width = Console.ReadLine();
            int userIntWidth = Convert.ToInt32(width);
            
            Console.WriteLine("Your garden box area is: " + userIntLength * userIntWidth + " and the perimeter of your box is: " + ((2 * userIntLength) + (2 * userIntWidth)) + ".");
           

            //use database to read back that number of veggies that can be planted
            while (true)
            {
                //present a menu of vegetables to plant
                Console.WriteLine("What vegetable would you like to plant? (Please select letter.)");
                Console.WriteLine("a.  Carrots");
                Console.WriteLine("b.  Corn");
                Console.WriteLine("c.  Beets");
                Console.WriteLine("d.  Quit");

                //get answer choice and convert to lower
                string userChoice = Console.ReadLine().ToLower();
            }


            connection.Close();
        }
        
    }
}
