using System;

namespace BuscaMinas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Tipos de width en el mapa:");
            byte width = 0; 
            try
            {
              width = byte.Parse(Console.ReadLine());
            }
            catch
            {
              width = 0;
            }
            if (width < 10) {width = 10;}
            Console.WriteLine("Tipos de height en el mapa:");
            byte height; 
            try
            {
              height = byte.Parse(Console.ReadLine());
            }
            catch
            {
              height = 0;
            }
            if (height < 10) { height = 10; }
            Console.WriteLine("How manny mines do you want?");
            byte mines;
            try
            {
               mines = byte.Parse(Console.ReadLine());
            }
            catch
            {
                mines = 0;
            }
            if (height < 1) { height = 1; }
            Mapa mapa = new Mapa(width,height,mines);


            mapa.Draw();
            bool run = true;
            while (run) 
            {
             //inputs
             Tuple<byte, byte> coords = Inputs(mapa.Width, mapa.Heigth);
             //Logica
             mapa.Visibilizar(coords.Item1 , coords.Item2 );
                //dibujado
                Console.Clear();
             mapa.Draw();
            }                    
            
        }

        static Tuple<byte,byte> Inputs(byte width ,byte height)
        {     
            Console.WriteLine("CoordX:");
            byte X = 0;
            try
            {
                X = byte.Parse(Console.ReadLine());
            }
            catch
            {
                X = 0;
            }
            if (X < width) { X = (byte)(width-1); }
            Console.WriteLine("CoordY:");
            byte Y;
            try
            {
                Y = byte.Parse(Console.ReadLine());
            }
            catch
            {
                Y = 0;
            }
            if (Y > height) { Y = (byte)(height- 1); ; }
            return new Tuple<byte, byte>(X, Y);
        }

    }
}
