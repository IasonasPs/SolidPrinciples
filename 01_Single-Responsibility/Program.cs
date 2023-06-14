using System;
using System.Diagnostics;
//using System.Security.Cryptography.X509Certificates;
using static System.Console;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

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
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            //return string.Join(", ", entries.ToArray());
            return string.Join(Environment.NewLine, entries);
        }
        #region Violates the 'Single Responsibility' Principle.We will make another Class instead
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

    public class Persistence
    {
        //Save File To Desktop...
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, filename);
                File.WriteAllText(filePath, journal.ToString());
            }

        }
    }
    internal class Program
    {
        public static void SearchItOnGoogle(string text)
        {
            var openEdge = new ProcessStartInfo
            {
                FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                Arguments = "http://google.com/search?q=" + text,
                WindowStyle = ProcessWindowStyle.Minimized,
                CreateNoWindow = false,
            };
            var x = Process.Start(openEdge);

        }
        static void Main(string[] args)
        {

            var os = Environment.OSVersion.ToString();
            WriteLine(os );

            #region Changing Working Directory
            //string newWorkingDirectory = @"C:\";
            //Directory.SetCurrentDirectory(newWorkingDirectory);
            //WriteLine($"This is the new Working Directory : '{Directory.GetCurrentDirectory()}'");

            #endregion
            SearchItOnGoogle("that+is+a+search");

            WriteLine("Journal :");
            var j = new Journal();

            j.AddEntry("Fucking awesome entry!!");
            j.AddEntry("entry at 10/06/23");
            j.AddEntry(" not so innovative entry0");
            j.AddEntry(" not so innovative entry1");
            j.AddEntry(" not so innovative entry2");
            j.AddEntry(" not so innovative entry3");
            j.AddEntry(" not so innovative entry4");
            j.AddEntry(" not so innovative entry5");
            j.AddEntry("entry at 13/06/23");
            j.AddEntry("entry at 14/06/23");

            WriteLine("--------------------------------");
            Persistence persistence = new Persistence();
            persistence.SaveToFile(j,"Journal.txt",false);
            WriteLine(j);

            ReadKey();

        }


    }
}