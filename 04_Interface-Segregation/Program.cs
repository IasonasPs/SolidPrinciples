using static System.Console;

namespace ConsoleApp1
{
    public class Document
    {

    }
    #region Violating I-S Principle
    //A huge interface "To Rule them All"....
    //Thats not practical at all
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
    #endregion

    #region Following the I-S Principle
    //The main difference is that we create an interface
    //for each different function, we may want to implement in our classes.
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
    //or Higher level interface inherits many "lower level" interfaces
    public interface IMultiMachine : IPrinter,IScanner,IFax
    {

    }
    public class MultiDevice : IMultiMachine
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFax fax;

        public MultiDevice(IPrinter printer, IScanner scanner, IFax fax)
        {
            if(printer == null)     
            {
                throw new ArgumentNullException(paramName : nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            if (fax == null)
            {
                throw new ArgumentNullException(paramName: nameof(fax));
            }
            this.printer = printer;
            this.scanner = scanner;
            this.fax = fax;
        }

        public void Fax(Document d)
        {
            fax.Fax(d);
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }

        //public void Scan(Document d)
        //{
        //    //
        //}
        //public void Print(Document d)
        //{
        //   //
        //}
        //public void Fax(Document d)
        //{
        //   //
        //}
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