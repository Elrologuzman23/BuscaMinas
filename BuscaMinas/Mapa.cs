using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaMinas
{
    internal class Mapa
    {
        public byte Width;
        public byte Heigth;
        public byte Mines;
        public List<List<casillas>> mapa = new List<List<casillas>>();

        public class casillas 
        {
          public bool mine;
          public int distance;
          public bool visible;
        
          public casillas(bool mine)
          { 
           mine = mine;
          }

        }
        public Mapa(byte Width, byte Heigth, byte Mines)
        {
            Width = Width;
            Heigth = Heigth;
            Mines = Mines;

            for (int i = 0; i <Heigth ; i++)
            {
                mapa.Add(new List<casillas>());
                    for (int j = 0; j <Width ; j++)
                    {
                      mapa[i].Add(new casillas(false)); 
                    }
            }

            Random rand = new Random(); 

            for (int j = 0; j < Mines; j++)
            {
                int x = rand.Next(0,Width);
                int y = rand.Next(0,Heigth);
                mapa[y][x].mine = true;
            }
            for (int y = 0; y < Heigth; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                   
                    try 
                    {
                        if(mapa[y][x + 1].mine)
                        {
                            mapa[y][x].distance++;
                        }
                    }
                    catch { }
                    try 
                    {
                      if (mapa[y][x - 1].mine)
                      {
                       mapa[y][x].distance++;
                      }  
                    } 
                    catch { }
                try
                {

                    if  (mapa[y + 1][x].mine) 
                    {
                     mapa[y][x].distance++;   
                    }
                    }
                    catch { }
                    try
                    {
                        if  (mapa[y - 1][x].mine) 
                    {
                      mapa[y][x].distance++;
                    }
                    }
                    catch { }
                    try
                    {
                        if  (mapa[y + 1][x + 1].mine) 
                    {
                       mapa[y][x].distance++;
                    }
                    }
                    catch { }
                    try
                    {
                        if  (mapa[y - 1][x - 1].mine)
                    {
                       mapa[y][x].distance++;
                    }
                    }
                    catch { }
                    try
                    {
                        if  (mapa[y + 1][x - 1].mine)
                    {
                       mapa[y][x].distance++;
                    }
                    }
                    catch { }
                    try
                    {
                        if  (mapa[y - 1][x + 1].mine) 
                    {
                      mapa[y][x].distance++;
                    }
                    }
                    catch { }               
                    {
                    }
                }
            }
        }


        public void Draw() 
        {

            for (int y = 0; y < Heigth; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (mapa[y][x].visible) 
                    {
                        if (mapa[y][x].mine)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('X');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            if (mapa[y][x].distance == 0)
                            {
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write(mapa[y][x].distance);
                            }

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(' ');
                        
                    }
                    
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }        
        
        }

        public void Visibilizar(byte X, byte Y)
        {
         mapa[Y][X].visible = true;
            if (mapa[X][Y].mine) 
            {

            }
            else 
            {
                if (mapa[Y][X].distance == 0)
                {
                    try { Visibilizar((byte)(Y - 1), (byte)(X)); } catch { }
                    try { Visibilizar((byte)(Y + 1), (byte)(X)); } catch { }
                    try { Visibilizar((byte)(Y), (byte)(X + 1)); } catch { }
                    try { Visibilizar((byte)(X), (byte)(X - 1)); } catch { }
                    try { Visibilizar((byte)(Y - 1), (byte)(X + 1)); } catch { }
                    try { Visibilizar((byte)(Y - 1), (byte)(X - 1)); } catch { }
                    try { Visibilizar((byte)(Y + 1), (byte)(X + 1)); } catch { }
                    try { Visibilizar((byte)(Y + 1), (byte)(X + 1)); } catch { }


                }
            }

           

        }
        

    }
        
}
   
