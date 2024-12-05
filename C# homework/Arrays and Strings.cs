//1.Copying an Array
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        int[] originalArray = new int[10];
        for (int i = 0; i < originalArray.Length; i++)
        {
            originalArray[i] = i * 10; // Assigning values like 0, 10, 20, 30, ...
        }

        int[] copiedArray = new int[originalArray.Length];

        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }

        Console.WriteLine("Original Array:");
        for (int i = 0; i < originalArray.Length; i++)
        {
            Console.Write(originalArray[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Copied Array:");
        for (int i = 0; i < copiedArray.Length; i++)
        {
            Console.Write(copiedArray[i] + " ");
        }
        Console.WriteLine();

        Console.ReadLine();
    }
}
*/

//2.Write a simple program that lets the user manage a list of elements. 
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        int maxSize = 10;
        string[] itemArray = new string[maxSize];
        int currentItemCount = 0;

        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine().Trim();

            if (input.StartsWith("+"))
            {
                string itemToAdd = input.Substring(1).Trim();
                if (!string.IsNullOrEmpty(itemToAdd))
                {
                    if (currentItemCount < maxSize)
                    {
                        itemArray[currentItemCount] = itemToAdd;
                        currentItemCount++;
                        Console.WriteLine($"Added: {itemToAdd}");
                    }
                    else
                    {
                        Console.WriteLine("Array is full. Cannot add more items.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please provide an item to add.");
                }
            }
            else if (input.StartsWith("-") && input.Length > 1)
            {
                string itemToRemove = input.Substring(1).Trim();
                bool itemFound = false;

                for (int i = 0; i < currentItemCount; i++)
                {
                    if (itemArray[i] == itemToRemove)
                    {
                        for (int j = i; j < currentItemCount - 1; j++)
                        {
                            itemArray[j] = itemArray[j + 1];
                        }
                        itemArray[currentItemCount - 1] = null; 
                        itemFound = true;
                        Console.WriteLine($"Removed: {itemToRemove}");
                        break;
                    }
                }

                if (!itemFound)
                {
                    Console.WriteLine($"Item not found: {itemToRemove}");
                }
            }
            else if (input == "--")
            {
                for (int i = 0; i < currentItemCount; i++)
                {
                    itemArray[i] = null;
                }
                currentItemCount = 0;
                Console.WriteLine("Array cleared.");
            }
            else
            {
                Console.WriteLine("Invalid command. Please try again.");
            }

            Console.WriteLine("Current array contents:");
            if (currentItemCount > 0)
            {
                for (int i = 0; i < currentItemCount; i++)
                {
                    Console.WriteLine("- " + itemArray[i]);
                }
            }
            else
            {
                Console.WriteLine("[The array is empty]");
            }

            Console.WriteLine(); 
        }
    }
}
*/

//3.Write a method that calculates all prime numbers in given range and returns them as array of integers
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        int[] primeNumbers = FindPrimesInRange(10, 50);
        Console.WriteLine("Prime numbers in the range: " + string.Join(" ", primeNumbers));

        Console.ReadLine();
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        int[] tempArray = new int[endNum - startNum + 1];
        int count = 0;
        for (int num = Math.Max(2, startNum); num <= endNum; num++)
        {
            if (IsPrime(num))
            {
                tempArray[count++] = num;
            }
        }
        int[] primes = new int[count];
        Array.Copy(tempArray, primes, count);

        return primes;
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
*/

//4.Write a program to read an array of n integers (space separated on a single line) and an integer k, rotate the array right k times and sum the obtained arrays after each rotation as shown below.
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the array elements (space separated):");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter the number of rotations:");
        int k = int.Parse(Console.ReadLine());

        int n = array.Length;
        int[] sumArray = new int[n]; 

        for (int r = 0; r < k; r++)
        {
            int[] rotatedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                int newPosition = (i + 1) % n;  
                rotatedArray[newPosition] = array[i];
            }
            for (int i = 0; i < n; i++)
            {
                sumArray[i] += rotatedArray[i];
            }
            array = rotatedArray;
        }

        Console.WriteLine("Sum array after all rotations:");
        Console.WriteLine(string.Join(" ", sumArray));
        Console.ReadLine();

    }
}
*/

//5.Write a program that finds the longest sequence of equal elements in an array of integers.If several longest sequences exist, print the leftmost one.
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the array elements (space separated):");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int maxLength = 1;
        int currentLength = 1;
        int element = array[0];
        int bestElement = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    bestElement = array[i];
                }
            }
            else
            {
                currentLength = 1;
            }
        }

        Console.WriteLine("Longest sequence of equal elements:");
        for (int i = 0; i < maxLength; i++)
        {
            Console.Write(bestElement + " ");
        }
        Console.ReadLine();
    }
}
*/

//7.Write a program that finds the most frequent number in a given sequence of numbers. In case of multiple numbers with the same maximal frequency, print the leftmost of them
/*
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the array elements (space separated):");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Dictionary<int, int> frequencyDict = new Dictionary<int, int>();

        foreach (int num in array)
        {
            if (frequencyDict.ContainsKey(num))
            {
                frequencyDict[num]++;
            }
            else
            {
                frequencyDict[num] = 1;
            }
        }

        int maxFrequency = frequencyDict.Values.Max();
        int mostFrequentNumber = array.First(num => frequencyDict[num] == maxFrequency);         // Find the most frequent number in mostleft


        Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFrequency} times)");
        Console.ReadLine();
    }
}
*/

//"Strings":
//1.Write a program that reads a string from the console, reverses its letters and prints the result back at the console
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        // Read input string
        Console.WriteLine("Enter a string to reverse:");
        string input = Console.ReadLine();

        // Print the string in reverse using a for loop
        Console.WriteLine("Reversed string:");
        for (int i = input.Length - 1; i >= 0; i--)
        {
            Console.Write(input[i]);
        }

        Console.WriteLine(); 
        Console.ReadLine();
    }
}
*/

//2.Write a program that reverses the words in a given sentence without changing the punctuation and spaces
/*
using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string pattern = @"(\s+|[.,;=()&[\]""'\\\/!?]+)";

        string[] tokens = Regex.Split(input, pattern);         // Split input into words and separators using regex


        string[] words = tokens.Where(token => !Regex.IsMatch(token, pattern) && !string.IsNullOrEmpty(token)).ToArray();         // Extract only the words into an array


        Array.Reverse(words);

        StringBuilder result = new StringBuilder();
        int wordIndex = 0;

        foreach (string token in tokens)
        {
            if (!Regex.IsMatch(token, pattern) && !string.IsNullOrEmpty(token))
            {
                result.Append(words[wordIndex++]);
            }
            else
            {
                result.Append(token);
            }
        }

        Console.WriteLine("Reversed sentence:");
        Console.WriteLine(result.ToString().TrimStart());
        Console.ReadLine();
    }
}
*/

//3.Write a program that extracts from a given text all palindromes
/*
using System;

class Program
{
    static void Main()
    {
        string input = "Hi,exe? ABBA! Hog fully a string: ExE. Bob a";
        string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        string palindromes = "";

        foreach (string word in words)
        {
            if (IsPalindrome(word))
            {
                if (!ContainsWord(palindromes, word))
                {
                    if (!string.IsNullOrEmpty(palindromes))
                    {
                        palindromes += ", ";
                    }
                    palindromes += word;
                }
            }
        }

        string[] sortedPalindromes = palindromes.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(sortedPalindromes);

        Console.WriteLine(string.Join(", ", sortedPalindromes));
        Console.ReadLine();

    }

    static bool IsPalindrome(string word)
    {
        int length = word.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (word[i] != word[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static bool ContainsWord(string words, string word)
    {
        string[] wordArray = words.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string w in wordArray)
        {
            if (w == word)
            {
                return true;
            }
        }
        return false;
    }
}
*/

//4.Write a program that parses an URL given in the following format:
/*
using System;

class Program
{
    static void Main()
    {
        string[] urls = {
            "https://www.apple.com/iphone",
            "ftp://www.example.com/employee",
            "https://google.com",
            "www.apple.com"
        };

        foreach (string url in urls)
        {
            ParseUrl(url);
            Console.WriteLine();
        }
    }

    static void ParseUrl(string url)
    {
        string protocol = "";
        string server = "";
        string resource = "";

        // Find protocol 
        int protocolEndIndex = url.IndexOf("://");
        if (protocolEndIndex != -1)
        {
            protocol = url.Substring(0, protocolEndIndex);
            url = url.Substring(protocolEndIndex + 3);
        }

        // Find server
        int serverEndIndex = url.IndexOf('/');
        if (serverEndIndex != -1)
        {
            server = url.Substring(0, serverEndIndex);
            resource = url.Substring(serverEndIndex + 1);
        }
        else
        {
            server = url;
        }

        // Print the parsed components
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
        Console.ReadLine();

    }
}
*/



