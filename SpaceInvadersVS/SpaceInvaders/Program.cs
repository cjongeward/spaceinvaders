using System;
using System.IO;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Directory.SetCurrentDirectory(dir + @"\Resources");

            Game engine = new Game();
            engine.Run();


        }
    }
}
