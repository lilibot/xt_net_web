using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    class GraphicsEditor
    {
        List<Figure> listFigures = new List<Figure> { };
        public void Menu()
        {
            int pickedElemMenu;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose menu element:");
                Console.WriteLine("1 - Print figures info");
                Console.WriteLine("2 - Create figures");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");

                while (!int.TryParse(Console.ReadLine(), out pickedElemMenu))
                {
                    Console.WriteLine("Incorrect value: valid values are 1 and 2");
                }

                switch (pickedElemMenu)
                {
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    case 1:
                        {
                            this.PrintFiguresInfo();
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            this.CreateFigures();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorrect value: valid values are 0, 1 and 2");
                            break;
                        }
                }

                Console.ReadKey();
            }
        }
        private void PrintFiguresInfo()
        {
            if (this.listFigures.Count == 0)
            {
                Console.WriteLine("There are no figures in the list");
            }

            foreach (var figure in this.listFigures)
            {
                Console.WriteLine(figure.ToString());
                figure.WriteInfo();
                Console.WriteLine();
            }
        }
        private void CreateFigures()
        {
            Console.WriteLine("Choose figure for create:");

            Console.WriteLine("1 - Line");
            Console.WriteLine("2 - Circle");
            Console.WriteLine("3 - Round");
            Console.WriteLine("4 - Ring");
            Console.WriteLine("5 - Rectangle");
            Console.WriteLine();
            Console.WriteLine("0 - Exit to previous menu");

            int pickedOption;
            while (!int.TryParse(Console.ReadLine(), out pickedOption))
            {
                Console.WriteLine("Incorrect value: valid values from 1 to 5");
            }

            switch (pickedOption)
            {
                case 0:
                    {
                        Menu();
                        break;
                    }
                case 1:
                    {
                        this.listFigures.Add(FigureCreator.CreateLine());
                        Console.WriteLine("Line created");
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            this.listFigures.Add(FigureCreator.CreateCircle());
                            Console.WriteLine("Circle created");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    }
                case 3:
                    {
                        try
                        {
                            this.listFigures.Add(FigureCreator.CreateRound());
                            Console.WriteLine("Round created");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }


                        break;
                    }
                case 4:
                    {
                        try
                        {
                            this.listFigures.Add(FigureCreator.CreateRing());
                            Console.WriteLine("Ring created");
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.ActualValue);
                        }
                        break;
                    }
                case 5:
                    {
                        this.listFigures.Add(FigureCreator.CreateRectangle());
                        Console.WriteLine("Rectangle created");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Incorrect value: valid values from 0 to 5");
                        break;
                    }
            }
        }
    }
}
