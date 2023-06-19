namespace Interfaces
{
    //or Higher level interface inherits many "lower level" interfaces
    public interface IMultiMachine : IPrinter, IScanner, IFax
    {

    }
}