namespace _02_OpenClosedPrinciple.Interfaces
{
    //Proper way of adding functionality is via using Interfaces

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}