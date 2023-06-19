using _02_OpenClosedPrinciple.Models;
using _02_OpenClosedPrinciple.Interfaces;

namespace _02_OpenClosedPrinciple.Services.Specifications
{
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
}