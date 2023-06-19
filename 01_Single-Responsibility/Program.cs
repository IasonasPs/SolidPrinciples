using System;
using System.Diagnostics;
//using System.Security.Cryptography.X509Certificates;
using static System.Console;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using models;
using Services;

namespace SingleResponsibilityPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Changing Working Directory
                        //string newWorkingDirectory = @"C:\";
                        //Directory.SetCurrentDirectory(newWorkingDirectory);
                        //WriteLine($"This is the new Working Directory : '{Directory.GetCurrentDirectory()}'");
            #endregion

            //Just a google search...
            Google.Search("Chet+Baker");

            WriteLine("Journal :");
            var j = new Journal();

            j.AddEntry(" awesome entry!!");
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