using static System.Console;

namespace ConsoleApp1
{
    public class Document
    {

    }
    #region Violating I-S Principle
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

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

    //The oldFashionedPrinter only Prints!
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
           //
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
    #endregion

    #region Following the I-S Principle
    //The main difference is that we create an interface
    //for each different function we may want to implement in our classes
    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IFax
    {
        void Fax(Document d);
    }
    //Class implements many interfaces
    public class CopyMachine : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
           //
        }
    }
    //Higher level interface 
    public interface IMultiMachine : IPrinter,IScanner,IFax
    {

    }
    public class MultiDevice : IMultiMachine
    {
        public void Fax(Document d)
        {
           //
        }
        public void Print(Document d)
        {
           //
        }
        public void Scan(Document d)
        {
            //
        }
    }
    #endregion



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}