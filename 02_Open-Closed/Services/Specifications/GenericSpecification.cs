using static System.Console;
using _02_OpenClosedPrinciple.Models;
using _02_OpenClosedPrinciple.Interfaces;

namespace _02_OpenClosedPrinciple.Services.Specifications
{
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
            foreach (var property in t.Properties())
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
    #endregion
}