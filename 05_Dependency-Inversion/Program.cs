using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace _05_Dependency_Inversion
{
    internal class Program
    {
        public enum Relationship
        {
            Parent, Child, Sibling
        }
        public class Person
        {
            public string Name;

        }
        //low level
        public class Relationships
        {
            //Why isnt this List static?????
            private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
            public void AddParentAndChild(Person parent, Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));

                WriteLine(parent.Name+"  is parent of "+child.Name);
            }

            public List<(Person, Relationship, Person)> Relations => relations;
        }
        public class Research
        {
            public Research(Relationships relationships)
            {
                var relations = relationships.Relations;
                //relations.ForEach(x =>   WriteLine(x));
                foreach (var rel in relations.Where(x => x.Item1.Name == "Jack" && x.Item2 == Relationship.Parent) )
                {
                    WriteLine($"{rel.Item1.Name} has a child called {rel.Item3.Name}");
                }
            }
            static void Main(string[] args)
            {
                var parent = new Person { Name = "Jack" };
                var child0 = new Person { Name = "Anna" };
                var child1 = new Person { Name = "Stefanos" };
                var grand_Child = new Person { Name = "nikos" };

                var relationships = new Relationships();
                relationships.AddParentAndChild(parent, child0);
                relationships.AddParentAndChild(parent, child1);
                relationships.AddParentAndChild(child0, grand_Child);
                WriteLine("---------------------------");
                 new Research(relationships);

            }
        }
    }
}