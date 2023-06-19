using Interfaces;
using Models;

namespace Services
{
    // Violating I-S Principle

    public class MultiFunctionalPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
}