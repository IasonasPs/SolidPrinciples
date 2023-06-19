using Interfaces;
using Models;
using Services;
using static System.Console;

namespace ConsoleApp1
{

    #region Following the I-S Principle
    //Class implements many interfaces
    public class CopyMachine : IPrinter, IScanner,IFax
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            WriteLine(  $"Whats that document? \nIs it an {d.name}?");
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
            Document document = new Document("Id");
            CopyMachine copyMachine = new CopyMachine();
            MultiDevice multiDevice = new MultiDevice(copyMachine, copyMachine, copyMachine);

            multiDevice.Print(document);
        }
    }
}