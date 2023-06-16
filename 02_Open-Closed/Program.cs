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
        #region Necessary for GenericSpecification!!
        public Dictionary<string, string> Properties()
        {
            var name = Name.ToString();
            var color = Color.ToString();
            var size = Size.ToString();

            var properties = new Dictionary<string, string>
            {
                //{"Name",name },
                {"Color",color},
                {"Size",size }
            };
            return properties;
        } 
        #endregion

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
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    #endregion
    public class ColorSpec : ISpecification<Product>
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
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    #region --->GenericSpecification Challenge!!!<---
    public class GenericSpecification<T, K> : ISpecification<Product>
    {
        private string Property00;
        private string Property01;
        private string value00;
        private string value01;
        public GenericSpecification(T s, K k) //e.g. <Color,Size>
        {
            Property00 = s.GetType().Name;
            value00 = s.ToString();
            Property01 = k.GetType().Name;
            value01 = k.ToString();
            WriteLine($"Generic Specification for [{Property00}] and [{Property01}] in this exact order");
            WriteLine(Property00 + ":" + value00);
            WriteLine(Property01 + ":" + value01);
            WriteLine("---------------------------");
        }

        public bool IsSatisfied(Product t)
        {
            bool control0 = false;
            bool control1 = false;
            foreach(var property in t.Properties()) 
            {
                if (property.Key == Property00 && property.Value == value00)
                {
                        control0 = true;
                }
                else if (property.Key == Property01 && property.Value == value01)
                {
                    control1 = true;
                }
            }
            return control0 && control1;
        }
    }
    //                                      /\
    //                                      ||
    //                                      ||
    //Thats the call i want to achieve :    
    //GenericSpecification genericSpec = new GenericSpecification(Color.Blue,Size.Small);
    #endregion


    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (Product product in items)
            {
                if (spec.IsSatisfied(product))
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
            var bicycle = new Product("Bicycle", Color.blue, Size.small);
            var rock = new Product("blue rock", Color.blue, Size.small);
            var tomato = new Product("Tomato", Color.red, Size.small);
            var potato = new Product("Potato", Color.green, Size.medium);

            #endregion
            Product[] products = { apple, tree, house, camperVan, bicycle, rock,tomato };
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
            AndSpecification<Product> and = new AndSpecification<Product>(blueSpec, smallSpec);
            var outcome05 = bF.Filter(products, and);
            outcome05.ToList().ForEach(WriteLine);
            #endregion
            WriteLine("=================================================================");
            var generic0 = new GenericSpecification<Color, Size>(Color.blue, Size.small);
            var outcome06 = bF.Filter(products, generic0); //it doesnt call the bf.Filter() method here!!!WHY????
            outcome06.ToList().ForEach(WriteLine);//indtead it calls it here

            var generic1 = new GenericSpecification<Size,Color>(Size.small, Color.red);
            var outcome07 = bF.Filter(products, generic1);
            outcome07.ToList().ForEach(WriteLine);

        }
    }
}