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

            connection.Close();
        }
        
    }
}
