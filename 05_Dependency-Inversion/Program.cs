using _05_Dependency_Inversion.Services;
using System.Security.Cryptography.X509Certificates;
using static _05_Dependency_Inversion.Program;
using static System.Console;

namespace _05_Dependency_Inversion
{


    public class Program
    {
        static void Main(string[] args)
        {
            var parent = new Person { Name = "Jack" };
            var child0 = new Person { Name = "Anna" };
            var child1 = new Person { Name = "Stefanos" };
            var grand_Child = new Person { Name = "Nikos" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child0);
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(child0, grand_Child);
            WriteLine("---------------------------");
            new Research(relationships, "Jack");
            WriteLine("---------------------------");
            new Research(relationships, child0);
            WriteLine("---------------------------");
            new ParentResearch(relationships, child0);
            new ParentResearch(relationships, grand_Child);
        }
    }


}


