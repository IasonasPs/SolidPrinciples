﻿using System.Security.Cryptography.X509Certificates;
using _03_Liskov_Substitution.Models;
using static System.Console;

namespace _03_Liskov_Substitution
{
    internal class Program
    {
        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            #region  

            Rectangle rc = new Rectangle(12, 33);
            WriteLine($"{rc} has area {Area(rc)} ");
            //When we use the square class everything works as expected
            WriteLine("Square Class");
            Square sq0 = new Square();
            sq0.Width = 4;
            WriteLine($"{sq0} has area {Area(sq0)} ");
            //But when we instead use the 'base' class to define our sq1 instance 
            //the height remains unset.Why??
            //because we used the "new" instead of the virtual operator to set the properties of the Square class
            //and we didnt make the properties of the base class virtual..
            WriteLine("Rectangle(Base) Class");
            Rectangle sq1 = new Square();
            sq1.Width = 4;
            WriteLine($"{sq1} has area {Area(sq1)} ");
            #endregion
        }
    }
}