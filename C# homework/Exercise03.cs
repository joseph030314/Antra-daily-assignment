// "Practice loops and operators"
// 1.FizzBuzz game
/* 
using System;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            // Keep the console window open until the user presses a key
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
*/

//2.Print-a-Pyramid.
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        int totalLines = 5; // You can change this value to make a larger pyramid

        for (int i = 1; i <= totalLines; i++)
        {
            // Print spaces
            for (int j = i; j < totalLines; j++)
            {
                Console.Write(" ");
            }

            // Print stars
            for (int k = 1; k <= (2 * i - 1); k++)
            {
                Console.Write("*");
            }

            // Move to the next line
            Console.WriteLine();
        }

        // Keeping the console open
        Console.ReadLine();
    }
}
*/

//3.Write a program that generates a random number between 1 and 3 and asks the user to guess what the number is. Tell the user if they guess low, high, or get the correct answer.
/*
using System;
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a random number between 1 and 3
            int correctNumber = new Random().Next(3) + 1;
            Console.WriteLine("I have picked a number between 1 and 3. Try to guess what it is!");
            int guessedNumber = int.Parse(Console.ReadLine());
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess is out of range! Please guess a number between 1 and 3.");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine("Too low! Please try again.");
            }
            else if (guessedNumber > correctNumber)
            {
                Console.WriteLine("Too high! Please try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the correct number.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Take another guess:");
            guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess is out of range! Please guess a number between 1 and 3.");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine($"Too low! The correct number was {correctNumber}.");
            }
            else if (guessedNumber > correctNumber)
            {
                Console.WriteLine($"Too high! The correct number was {correctNumber}.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the correct number.");
            }

            Console.ReadLine();
        }
    }
*/

//4.Write a simple program that defines a variable representing a birth date and calculates how many days old the person with that birth date is currently.
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your birth date (yyyy-mm-dd): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        DateTime currentDate = DateTime.Now;
        TimeSpan ageSpan = currentDate - birthDate;
        int daysOld = ageSpan.Days;

        Console.WriteLine($"You are {daysOld} days old.");

        // Calculate days until the next 10,000 day anniversary
        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversaryDate = currentDate.AddDays(daysToNextAnniversary);

        Console.WriteLine($"Your next 10,000-day anniversary will be on: {nextAnniversaryDate.ToString("yyyy-MM-dd")}");

        Console.ReadLine();
    }
}
*/

//5.Write a program that greets the user using the appropriate greeting for the time of day.
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime currentTime = DateTime.Now;
        int currentHour = currentTime.Hour;

        if (currentHour >= 5 && currentHour < 12)
        {
            Console.WriteLine("Good Morning");
        }
        if (currentHour >= 12 && currentHour < 17)
        {
            Console.WriteLine("Good Afternoon");
        }
        if (currentHour >= 17 && currentHour < 21)
        {
            Console.WriteLine("Good Evening");
        }
        if ((currentHour >= 21 && currentHour < 24) || (currentHour >= 0 && currentHour < 5))
        {
            Console.WriteLine("Good Night");
        }

        Console.ReadLine();
    }
}
*/

//6.Write a program that prints the result of counting up to 24 using four different increments.
/*
using System;
class Program
{
    static void Main(string[] args)
    {
        for (int increment = 1; increment <= 4; increment++)
        {
            for (int i = 0; i <= 24; i += increment)
            {
                if (i != 0) Console.Write(", ");
                Console.Write(i);
            }

            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
*/