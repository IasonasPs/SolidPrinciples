using _02_OpenClosedPrinciple.Models;
using _02_OpenClosedPrinciple.Interfaces;

namespace _02_OpenClosedPrinciple
{
    //                                      /\
    //                                      ||
    //                                      ||
    //Thats the call i want to achieve :    
    //GenericSpecification genericSpec = new GenericSpecification(Color.Blue,Size.Small);
  


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
}