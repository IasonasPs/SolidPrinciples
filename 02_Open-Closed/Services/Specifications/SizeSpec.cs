using _02_OpenClosedPrinciple.Models;
using _02_OpenClosedPrinciple.Interfaces;

namespace _02_OpenClosedPrinciple.Services.Specifications
{
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
}