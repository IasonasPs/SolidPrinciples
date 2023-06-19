//using System.Security.Cryptography.X509Certificates;

namespace models
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} : {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            //return string.Join(", ", entries.ToArray());
            return string.Join(Environment.NewLine, entries);
        }
        #region Violates the 'Single Responsibility' Principle.We will make another Class named "Persistence" to serve this functionality 
        //public void Save(string filename)
        //{
        //    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    string filePath = Path.Combine(desktopPath, filename);
        //    WriteLine(filePath);
        //    File.WriteAllText(filePath, this.ToString());
        //}
        //public static Journal Load(string filename)
        //{
        //    return null;
        //}
        //public void Load(Uri uri)
        //{

        //} 
        #endregion 
    }
}