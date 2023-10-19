using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FrameLab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string s, s1;
            int v = -1;
            while (v != 0)
            {
                Console.Clear();
                Console.WriteLine("1) Консольное приложение \n2) Windows Forms \n\n0) Выход \n\nВведите номер метода : ");
                s = Console.ReadLine();
                v = Convert.ToInt32(s);
                switch (v)
                {
                    case 1:
                        {
                            Console.Clear();
                            int v1 = -1;
                            string sn;
                            string name = @"D:\Users\drall\source\repos\FrameLab9\binary";
                            int a;
                            Random random = new Random();
                            Console.WriteLine("Сколько чисел записать в файл?");
                            s1 = Console.ReadLine();
                            a = Convert.ToInt32(s1);
                            BinaryWriter fs1 = new BinaryWriter(File.Open(name, FileMode.OpenOrCreate));
                            for (int i = 0; i < a; i++)
                            {
                                fs1.Write(random.Next(0, 99));
                            }
                            fs1.Close();
                            while (v1 != 0)
                                {
                                Console.Clear();
                                BinaryReader fs2 = new BinaryReader(File.Open(name, FileMode.OpenOrCreate));
                                while (fs2.PeekChar() > -1)
                                {
                                    Console.Write(fs2.ReadInt32() + " ");
                                }
                                Console.WriteLine("\n");
                                fs2.Close();
                                Console.WriteLine("1) Найти наименьшее и наибольшее значение в файле\n2) Задание 2\n3) Задание 3 \n\n0) Выход \n\nВведите номер метода : ");
                                    sn = Console.ReadLine();
                                    v1 = Convert.ToInt32(sn);
                                    switch (v1)
                                    {
                                        case 1:
                                            {
                                            Console.Clear();
                                            int min = 99, max = 0, d; 
                                            fs2 = new BinaryReader(File.Open(name, FileMode.OpenOrCreate));
                                            while (fs2.PeekChar() > -1)
                                            {
                                                Console.Write(fs2.ReadInt32() + " ");
                                            }
                                            Console.WriteLine("\n");

                                            while (fs2.PeekChar() > -1)
                                            {
                                                d = fs2.ReadInt32();
                                                if (d < min) { min = d; }
                                                if (d > max) { max = d; }
                                            }
                                            fs2.Close();
                                            Console.Write(min + " " + max + "\n");

                                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                                s1 = Console.ReadLine();
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Clear();

                                                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                                s1 = Console.ReadLine();
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.Clear();

                                                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                                s1 = Console.ReadLine();
                                                break;

                                            }
                                        case 0:
                                            {
                                            fs1.Close();
                                            Console.Clear();
                                                break;
                                            }

                                        default:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Введено невернрое значение!");
                                                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                                s = Console.ReadLine();
                                                break;
                                            }
                                    }
                                }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Application.Run(new Form1());
                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                            s = Console.ReadLine();
                            break;
                        }

                    case 0:
                        {
                            Console.Clear();
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Введено невернрое значение!");
                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                            s = Console.ReadLine();
                            break;
                        }

                }
            }
        }
    }
}
