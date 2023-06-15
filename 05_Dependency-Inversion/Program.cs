using System.Security.Cryptography.X509Certificates;
using static _05_Dependency_Inversion.Program;
using static System.Console;

namespace _05_Dependency_Inversion
{
    internal class Program
    {
        #region Basics
        public enum Relationship
        {
            Parent, Child, Sibling
        }
        public class Person
        {
            public string Name;
        }
        #endregion

        public interface IRelationshipBrowser
        {
            IEnumerable<Person> FindAllChildrenOf(string name);
        }
        //low level
        //public class Relationships
        //{
        //    //Why isnt this List static?????==>Because we want such a list for every Relationships instance that will be created!!
        //    private  List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
        //    public void AddParentAndChild(Person parent, Person child)
        //    {
        //        relations.Add((parent, Relationship.Parent, child));
        //        relations.Add((child, Relationship.Child, parent));

        //        WriteLine(parent.Name+"  is parent of "+child.Name);
        //    }

        //    public List<(Person, Relationship, Person)> Relations => relations;
        //}

        #region Following the Dependency-Inversion principle
        public class Relationships : IRelationshipBrowser
        {
            private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

            public void AddParentAndChild(Person parent, Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));
            }

            #region Cant use "yield return" in lamda expression or Anonymous function!!
            //relations.ForEach(x => {
            //    if (x.Item1.Name == name && x.Item2 == Relationship.Parent)
            //    {

            //        var child = x.Item3;
            //        yield return child;
            //    }
            //    yield return null;
            //}); 
            #endregion

            #region "FindAllChildrenOf()" first implementation : Level of elegance == 3
            //public IEnumerable<Person> FindAllChildrenOf(string name)
            //{
            //    bool hasChildren = true;
            //    foreach (var relation in relations)
            //    {
            //        if (relation.Item1.Name == name && relation.Item2 == Relationship.Parent)
            //        {
            //            yield return relation.Item3;
            //        }
            //        hasChildren = false;
            //    }
            //    if (!hasChildren)
            //    {
            //        yield return null;
            //    }
            //} 
            #endregion

            #region "FindAllChildrenOf()" second implementation : Level of elegance == 7
            //public IEnumerable<Person> FindAllChildrenOf(string name)
            //{
            //    foreach (var relation in relations.Where(r => r.Item1.Name == name && r.Item2 == Relationship.Parent))
            //    {
            //        yield return relation.Item3;
            //    }
            //} 
            #endregion

            #region "FindAllChildrenOf()" last implementation : Level of elegance == 9
            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return relations.
                    Where(r => r.Item1.Name.Equals(name) && r.Item2.Equals(Relationship.Parent))
                    .Select(r => r.Item3);
            }
            #endregion

        }
        #endregion



        public class Research
        {
            //public Research(Relationships relationships)
            //{
            //    var relations = relationships.Relations;
            //    //relations.ForEach(x =>   WriteLine(x));
            //    foreach (var rel in relations.Where(x => x.Item1.Name == "Jack" && x.Item2 == Relationship.Parent) )
            //    {
            //        WriteLine($"{rel.Item1.Name} has a child called {rel.Item3.Name}");
            //    }
            //}

            public Research(IRelationshipBrowser browser, string name)
            {
                foreach (var c in browser.FindAllChildrenOf(name))
                {
                    WriteLine($"{name} has a child called {c.Name}");
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
                new Research(relationships, "Jack");
            }
        }
    }
}


