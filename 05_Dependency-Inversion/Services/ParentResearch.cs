using static System.Console;

namespace _05_Dependency_Inversion.Services
{
    public class ParentResearch
    {
        public ParentResearch(IRelationshipBrowser browser, Person person)
        {
            foreach (var c in browser.FindParentsOf(person.Name))
            {
                WriteLine($"{person.Name} has a parent called {c.Name}");
            }
        }

    }


}


