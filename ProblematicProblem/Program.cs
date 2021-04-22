
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();
            bool cont = true;
            List<string> activities = new List<string>() 
            { 
                "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", 
                "Hiking", "Axe Throwing", "Wine Tasting" 
            };

            Console.Write("Hello, welcome to the random activity generator! \n\n" +
                "Would you like to generate a random activity? Yes/No: ");
            if (Console.ReadLine().ToLower().StartsWith('n'))
                return;

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            
            Console.WriteLine();

            Console.Write("What is your age? ");

            int userAge;    
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.WriteLine("\nOops! Please enter a number for age.\n");
                Console.Write("What is the numerical value of your age? ");
            }

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Yes/No: ");
            bool seeList = Console.ReadLine().ToLower().StartsWith('y');

            Console.WriteLine();

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.WriteLine($" {activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
            }

            Console.Write("Would you like to add any activities before we generate one? Yes/No: ");
            bool addToList = Console.ReadLine().ToLower().StartsWith('y');

            Console.WriteLine();

            while (addToList)
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();

                Console.WriteLine();

                activities.Add(userAddition);

                foreach (string activity in activities)
                {
                    Console.WriteLine($" {activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                Console.Write("Would you like to add more? Yes/No: ");
                addToList = Console.ReadLine().ToLower().StartsWith('y');

                Console.WriteLine();
            }

            Console.Write("Connecting to the database");

            for (int i = 0; i < 8; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine("\n");

            string randomActivity = "";
            string lastActivity = "";

            while (cont)
            {
                Console.Write("Choosing your random activity");

                for (int i = 0; i < 7; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                while (lastActivity.Equals(randomActivity))
                {
                    int randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                lastActivity = randomActivity;

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"\nOh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("We'll pick something else!");

                    activities.Remove(randomActivity);

                    Console.WriteLine();

                    continue;
                }

                Console.WriteLine();

                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! \n");
                Console.Write($"Would you like to generate a different activity? Yes/No: ");
                
                cont = Console.ReadLine().ToLower().StartsWith('y');

                Console.WriteLine();
            }
        }
    }
}
