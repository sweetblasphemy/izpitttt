using System;
using System.Collections.Generic;
using System.Text;

namespace UASD_Retake
{
    public class Cocktail
    {
        private string name;
        private double price;

        public Cocktail(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public string Name
        {
            get { return name; }
            set { name = value.ToLower(); }
        }
        public double Price
        {
            get {  return price; }
            set {  price += value; }
        }

        public override string ToString()
        {
            return $"Cocktail {name} costs {price:F2} lv.";
        }

    }
}