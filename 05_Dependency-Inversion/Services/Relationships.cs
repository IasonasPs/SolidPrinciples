namespace _05_Dependency_Inversion.Services
{
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

    // Following the Dependency-Inversion principle

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

        public IEnumerable<Person> FindParentsOf(string name)
        {
            return relations.
                Where(r => r.Item3.Name.Equals(name) && r.Item2.Equals(Relationship.Parent))
                .Select(r => r.Item1);
        }
        #endregion
    }
}


