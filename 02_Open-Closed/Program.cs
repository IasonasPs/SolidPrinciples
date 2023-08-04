using System;
using static System.Console;
using System.Diagnostics;
using _02_OpenClosedPrinciple.Models;
using _02_OpenClosedPrinciple.Services;
using _02_OpenClosedPrinciple.Services.Specifications;

namespace _02_OpenClosedPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Products
            var apple = new Product("apple", Color.red, Size.small);
            var tree = new Product("Tree", Color.red, Size.large);
            var house = new Product("House", Color.blue, Size.large);
            var camperVan = new Product("CamperVan", Color.blue, Size.small);
            var bicycle = new Product("Bicycle", Color.blue, Size.small);
            var rock = new Product("blue rock", Color.blue, Size.small);
            var tomato = new Product("Tomato", Color.red, Size.small);
            var potato = new Product("Potato", Color.green, Size.medium);

            Product[] products = { apple, tree, house, camperVan, bicycle, rock, tomato };
            #endregion

            WriteLine("Violating the Open-Closed Principle");
            #region
            WriteLine("-----------------------------------");
            WriteLine("Large products :");
            var outcome00 = ProductFilter.FilterBySize(products, Size.large);
            outcome00.ToList().ForEach(product => { WriteLine(product); });
            WriteLine("Red products :");
            var outcome01 = ProductFilter.FilterByColor(products, Color.red);
            outcome01.ToList().ForEach(product => { WriteLine(product); });
            WriteLine("Red and large products :");
            var outcome02 = ProductFilter.FilterBySizeAndColor(products, Size.large, Color.red);
            outcome02.ToList().ForEach(product => { WriteLine(product); });
            #endregion
            WriteLine("=================================================================");
            WriteLine("Following the Open-Closed Principle");
            #region
            WriteLine("-----------------------------------");
            BetterFilter bF = new BetterFilter();
            ColorSpec redSpec = new ColorSpec(Color.red);
            ColorSpec blueSpec = new ColorSpec(Color.blue);
            SizeSpec largeSpec = new SizeSpec(Size.large);
            SizeSpec smallSpec = new SizeSpec(Size.small);
            WriteLine("Blue products : ");
            var outcome03 = bF.Filter(products, redSpec);
            outcome03.ToList().ForEach(product => { WriteLine(product); });
            WriteLine("Large Products :");
            var outcome04 = bF.Filter(products, largeSpec);
            outcome04.ToList().ForEach(product => { WriteLine(product); });
            WriteLine("Blue and small products");
            AndSpecification<Product> blueAndSmall = new AndSpecification<Product>(blueSpec, smallSpec);
            var outcome05 = bF.Filter(products, blueAndSmall);
            outcome05.ToList().ForEach(WriteLine);
            #endregion
            WriteLine("=================================================================");

            var generic0 = new GenericSpecification<Color, Size>(Color.blue, Size.small);
            var outcome06 = bF.Filter(products, generic0); //it doesnt call the bf.Filter() method here!!!WHY????
            outcome06.ToList().ForEach(WriteLine);//instead it calls it here!
            WriteLine("* * * * * * * * * * *");
            var generic1 = new GenericSpecification<Size, Color>(Size.small, Color.red);
            var outcome07 = bF.Filter(products, generic1);
            outcome07.ToList().ForEach(WriteLine);

        }
    }
}