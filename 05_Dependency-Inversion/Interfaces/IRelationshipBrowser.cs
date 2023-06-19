namespace _05_Dependency_Inversion
{
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
        IEnumerable<Person> FindParentsOf(string name);
    }
}


