using Models;

namespace Interfaces
{
    

    // Following the I-S Principle
    //The main difference is that we create an interface
    //for each different function, we may want to implement in our classes.
    public interface IPrinter
    {
        void Print(Document d);
    }
}