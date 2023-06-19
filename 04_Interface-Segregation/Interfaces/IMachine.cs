using Models;

namespace Interfaces
{
    //Violating I-S Principle
    //A huge interface "To Rule them All"....
    //Thats not practical at all
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
}