namespace Models
{
    public class Document
    {
        public string name { get; set; }
        public Document(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"The name of this document is: {name}";
        }
    }
}