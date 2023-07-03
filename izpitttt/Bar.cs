using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UASD_Retake
{
    public class Bar
    {
        private string name;
        private List<Cocktail> cocktails;

        public Bar(string name)
        {
            
            this.name = name;
            cocktails = new List<Cocktail>();
        }

        public string Name
        {
            get { return name; }
            set {  name = value; }
        }

        public List<Cocktail> Cocktails
        {
            get {  return cocktails; }
            set {  cocktails = value; }
        }

        public void AddCocktail(string name, double price)
        {

            Cocktail cocktail = new Cocktail(name, price);
            cocktails.Add(cocktail);
        }

        public double AveragePriceInRange(double start, double end)
        {
            int count = 0;
            double totalPrice = 0;

            foreach (Cocktail cocktail in cocktails)
            {
                if (cocktail.Price >= start && cocktail.Price <= end)
                {
                    count++;
                    totalPrice += cocktail.Price;
                }
            }

            if (count > 0)
                return totalPrice / count;
            else
                return 0;
        }

        public List<string> FilterCocktailsByPrice(double price)
        {
            List<string> filteredCocktails = new List<string>();

            foreach (Cocktail cocktail in cocktails)
            {
                if (cocktail.Price == price)
                {
                    filteredCocktails.Add(cocktail.Name);
                }
            }

            return filteredCocktails;
        }

        public List<Cocktail> SortAscendingByName()
        {
            List<Cocktail> sortedCocktails = new List<Cocktail>(cocktails);
            sortedCocktails.Sort((c1, c2) => string.Compare(c1.Name, c2.Name));
            return sortedCocktails;
        }

        public List<Cocktail> SortDescendingByPrice()
        {
            List<Cocktail> sortedCocktails = new List<Cocktail>(cocktails);
            sortedCocktails.Sort((c1, c2) => c2.Price.CompareTo(c1.Price));
            return sortedCocktails;
        }

        public bool CheckCocktailIsInBar(string name)
        {
            foreach (Cocktail cocktail in cocktails)
            {
                if (cocktail.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public string[] ProvideInformationAboutAllCocktails()
        {
            string[] cocktailInfo = new string[cocktails.Count];

            for (int i = 0; i < cocktails.Count; i++)
            {
                cocktailInfo[i] = cocktails[i].ToString();
            }

            return cocktailInfo;
        }
    }
}