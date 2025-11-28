using DBConnector;
using System.Data;

namespace DBConnector.Console;

class Program
{
    static async Task Main(string[] args)
    {
        System.Console.WriteLine("=== Database Connection Tester ===");
        System.Console.WriteLine();

        while (true)
        {
            System.Console.WriteLine("Select a database type:");
            System.Console.WriteLine("1. MongoDB");
            System.Console.WriteLine("2. PostgreSQL");
            System.Console.WriteLine("3. Exit");
            System.Console.Write("\nEnter your choice (1-3): ");

            string? choice = System.Console.ReadLine();

            if (choice == "3")
            {
                System.Console.WriteLine("Exiting...");
                break;
            }

            if (choice != "1" && choice != "2")
            {
                System.Console.WriteLine("Invalid choice. Please try again.\n");
                continue;
            }

            System.Console.Write("Enter connection string: ");
            string? connectionString = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                System.Console.WriteLine("Connection string cannot be empty.\n");
                continue;
            }

            IDBConnector connector;

            if (choice == "1")
            {
                System.Console.WriteLine("\nTesting MongoDB connection...");
                connector = new MongoConnector(connectionString);
            }
            else
            {
                System.Console.WriteLine("\nTesting PostgreSQL connection...");
                connector = new PostgresConnector(connectionString);
            }

            try
            {
                bool result = await connector.ping();

                if (result)
                {
                    System.Console.WriteLine("✓ Connection successful!\n");
                }
                else
                {
                    System.Console.WriteLine("✗ Connection failed.\n");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"✗ Error: {ex.Message}\n");
            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("=== Database Connection Tester ===\n");
        }
    }
}