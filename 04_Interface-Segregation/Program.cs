using Interfaces;
using Models;
using static System.Console;

namespace ConsoleApp1
{

    #region Following the I-S Principle
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