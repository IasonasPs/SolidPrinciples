using _02_OpenClosedPrinciple.Models;

namespace _02_OpenClosedPrinciple.Services
{
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
        //**************************************************************************************************
        //The next method was added after the class was created,when the need for double filtering emerged.
        //At this point occured the VIOLATION of the O-C principle as we had to modify the code of the
        //ProductFilter class directly, AFTER it was created.
        //**************************************************************************************************
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
}