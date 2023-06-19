namespace _02_OpenClosedPrinciple.Models
{
    
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        #region Necessary for GenericSpecification!!
        public Dictionary<string, string> Properties()
        {
            var name = Name.ToString();
            var color = Color.ToString();
            var size = Size.ToString();

            var properties = new Dictionary<string, string>
            {
                //{"Name",name },
                {"Color",color},
                {"Size",size }
            };
            return properties;
        }
        #endregion

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
        public override string ToString()
        {
            return $" {Color}------>{Size}------>{Name}";
        }
    }
}