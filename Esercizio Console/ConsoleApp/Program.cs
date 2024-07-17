using System;
using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Data;
using System.Formats.Tar;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;


namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Invoker invoker = new Invoker();

            //Togliere il commento e commentare i comandi singoli per avere il menu dell'applicazione
            //Menu(invoker);

            invoker.Compute(0, 1);          //Pagina di prova
            invoker.Compute(0, 2);          //Pagina nuova
            invoker.Compute(0, 3);          //hello world
            invoker.Line(0, "Qwertyuiop");  //stringa a piacere
            invoker.Undo(1);                //cancella ultima azione
            invoker.Compute(0, 7);          //stampa
            invoker.Compute(0, 5);          //riga di testo con data
            invoker.Compute(0, 6);          //accendi/spegni stampante
            invoker.Compute(0, 7);          //stampa

            invoker.Compute(1, 1);          //Pagina di prova
            invoker.Compute(1, 2);          //Pagina nuova
            invoker.Compute(1, 3);          //hello world
            invoker.Line(1, "Qwertyuiop");  //stringa a piacere
            invoker.Undo(1);                //cancella ultima azione
            invoker.Compute(1, 7);          //stampa
            invoker.Compute(1, 5);          //riga di testo con data
            invoker.Compute(1, 6);          //accendi/spegni stampante
            invoker.Compute(1, 7);          //stampa



        }

        public static void Menu(Invoker invoker){
            int key;
            int printer;
            int np = invoker.getNumberPrinters();

            bool exit = false;

            while (!exit)
            {
                key = -1;
                printer = -1;
                while (printer == -1)
                {
                    Console.WriteLine($"Select printer (from {np - (np - 1)} to {np}) :");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out _))
                    {
                        int t = Convert.ToInt32(input);
                        if (t >= 0 && t <= np)
                        {
                            printer = t;
                        }
                    }
                }

                if (printer == 0)
                {
                    exit = true;
                }

                while (key != 0 && !exit)
                {
                    Console.WriteLine($"\n{invoker.getNamePrinter(printer-1)}");
                    Console.WriteLine("1-Sample Page \n2-White Page \n3-Hello World \n4-Line \n5-Date \n6-Switch on/off \n7-Print \n8-Undo \n0-Exit \nPress a key... ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out _))
                    {
                        key = Convert.ToInt32(input);
                        if (key == 4)
                        {
                            Console.WriteLine("Line to write : ");
                            string s = Console.ReadLine();
                            invoker.Line(printer - 1, s);
                        }
                        else if (key > 0 && key < 8)
                        {
                            invoker.Compute(printer - 1, key);
                        }
                        else if (key == 8)
                        {
                            invoker.Undo(1);
                        }
                    }
                }

            }
        }
    }

}
