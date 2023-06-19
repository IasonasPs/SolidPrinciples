using static System.Console;

namespace _05_Dependency_Inversion.Services
{
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
        public Research(IRelationshipBrowser browser, Person person)
        {
            foreach (var c in browser.FindAllChildrenOf(person.Name))
            {
                WriteLine($"{person.Name} has a child called {c.Name}");
            }
        }
    }


}


