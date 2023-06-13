using System;
using static System.Console;
using System.Diagnostics;

namespace _02_OpenClosedPrinciple
{
    #region Basic Entities
    public enum Color 
    {
        red, green, blue, white, black
    }
    public enum Size
    {
        small, medium, large, huge
    }
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
        public override string ToString()
        {
            return $" {Color}------>{Size}------>{Name}";
        }
    }
    #endregion
    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (Product product in products)
            {
                if (product.Size == size)
                {
                    yield return product;
                }
            }
        }
        public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Color == color)
                {
                    yield return product;
                }
            }
        }
        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Color == color && product.Size == size)
                {
                    yield return product;
                }
            }
        }
    }
    //Proper way of adding functionality is via using Interfaces
    #region Interfaces
    public interface ISpecification<T>
    {
       bool IsSatisfied(T t);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items,ISpecification<T> spec);
    }
    #endregion
    public class ColorSpec :ISpecification<Product>
    {
        private Color color;

        public ColorSpec(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }
    public class SizeSpec : ISpecification<Product>
    {
        private Size size;

        public SizeSpec(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size.Equals(size);
        }
    }

    #region --->GenericSpecification Challenge!!!<---
    //public class GenericSpecification<T> : ISpecification<Product> 
    //{
    //    private string Property;

    //    public GenericSpecification(T s )
    //    {
    //        Property = s.GetType().Name;
    //    }
    //    public bool IsSatisfied(Product t)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    #endregion

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(Product product in items)
            {
                if(spec.IsSatisfied(product))
                {
                    yield return product;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Products
            var apple = new Product("apple", Color.red, Size.small);
            var tree = new Product("Tree", Color.red, Size.large);
            var house = new Product("House", Color.blue, Size.large);
            var camperVan = new Product("CamperVan", Color.blue, Size.small); 
            #endregion
            Product[] products = { apple, tree, house, camperVan };
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
            WriteLine("Blue products : ");
            BetterFilter bF = new BetterFilter();
            ColorSpec redSpec = new ColorSpec(Color.red);
            SizeSpec largeSpec = new SizeSpec(Size.large);
            var outcome03 = bF.Filter(products, redSpec);
            outcome03.ToList().ForEach(product => { WriteLine(product);});
            WriteLine("Large Products :");
            var outcome04 = bF.Filter(products, largeSpec);
            outcome04.ToList().ForEach(product => {WriteLine(product);});
            #endregion
        }
    }
}