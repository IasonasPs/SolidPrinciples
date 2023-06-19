using Interfaces;

namespace ConsoleApp1
{
    //or Higher level interface inherits many "lower level" interfaces
    public interface IMultiMachine : IPrinter,IScanner,IFax
    {

    }
}