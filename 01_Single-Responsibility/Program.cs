using System;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace SingleResponsibilityPrinciple
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
        public void RemoveEntry(int  index) 
        {
            entries.RemoveAt(index);
        }
        public override string ToString() 
        {
            //return string.Join(", ", entries.ToArray());
            return string.Join(Environment.NewLine, entries);
        }

        public void Save(string filename)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, filename);
            WriteLine(filePath);
            File.WriteAllText(filePath, this.ToString());
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Journal :");
            var j = new Journal();

            j.AddEntry("Fucking awesome entry");
            j.AddEntry("Beatiful fucking entry");
            j.AddEntry(" not so innovative entry0");
            j.AddEntry(" not so innovative entry1");
            j.AddEntry(" not so innovative entry2"); 
            j.AddEntry(" not so innovative entry3");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry4");
            WriteLine(j);
            j.Save("test.txt");
            ReadLine();
        }
    }
}