using System;
using System.Collections.Generic;

namespace UASD_Retake
{
    class Program
    {
        static Bar bar = new Bar("Bar1");

        static void Main(string[] args)
        {
            string line;

            while ("END" != (line = Console.ReadLine()))
            {
                string[] cmdArgs = line.Split(' ');

                switch (cmdArgs[0])
                {
                    case "Add":
                        AddCocktail(cmdArgs[1], double.Parse(cmdArgs[2]));
                        break;
                    case "AveragePrice":
                        AverageResultInRange(double.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                        break;
                    case "FilterCocktails":
                        FilterCocktailsByGrade(double.Parse(cmdArgs[1]));
                        break;
                    case "SortByName":
                        SortAscendingByName();
                        break;
                    case "SortByPrice":
                        SortDescendingByPrice();
                        break;
                    case "CheckCocktail":
                        CheckCocktailIsInBar(cmdArgs[1]);
                        break;
                    case "Print":
                        ProvideInformationAboutAllCocktails();
                        break;
                }
            }
        }

        private static void ProvideInformationAboutAllCocktails()
        {
            string[] info = bar.ProvideInformationAboutAllCocktails();
            foreach (string item in info)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckCocktailIsInBar(string name)
        {
            if (bar.CheckCocktailIsInBar(name))
            {
                Console.WriteLine($"Cocktail {name} is available.");
            }
            else
            {
                Console.WriteLine($"Cocktail {name} is not available.");
            }
        }
        private static void SortDescendingByPrice()
        {
            bar.SortDescendingByPrice();
            Console.WriteLine("The cheapest cocktail is: " + bar.Cocktails[bar.Cocktails.Count - 1].Name);
        }
        private static void SortAscendingByName()
        {
            bar.SortAscendingByName();
            Console.WriteLine("The first cocktail is: " + bar.Cocktails[0].Name);
        }
        private static void FilterCocktailsByGrade(double grade)
        {
            List<string> leftCocktails = bar.FilterCocktailsByPrice(grade);
            Console.WriteLine("Filtered cocktails: " + string.Join(", ", leftCocktails));
        }

        private static void AverageResultInRange(double start, double end)
        {
            double averageGrade = bar.AveragePriceInRange(start, end);
            Console.WriteLine($"Average result: {averageGrade:f2}");
        }

        private static void AddCocktail(string name, double grade)
        {
            bar.AddCocktail(name, grade);
            Console.WriteLine($"Added cocktail {name}.");
        }
    }
}