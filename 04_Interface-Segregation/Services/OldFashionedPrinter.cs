using Interfaces;
using Models;

namespace Services
{
    // Violating I-S Principle

    //The oldFashionedPrinter only Prints!
    //But we only have one interface for all functionalities...
    //so we have to implement 2 extra methods, that in this exact class are completely redundant...
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            //implementation of print method

        }
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
}