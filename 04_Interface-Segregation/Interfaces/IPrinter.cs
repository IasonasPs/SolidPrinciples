using Models;

namespace Interfaces
{
    #region Violating I-S Principle
    #endregion

    #region Following the I-S Principle
    //The main difference is that we create an interface
    //for each different function, we may want to implement in our classes.
    public interface IPrinter
    {
        void Print(Document d);
    }
}