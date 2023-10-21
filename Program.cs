using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;

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
                            string name = @"D:\Users\drall\source\repos\FrameLab9\binary", namecopy = @"D:\Users\drall\source\repos\FrameLab9\binarycopy";
                            int a;
                            Random random = new Random();
                            Console.WriteLine("Сколько чисел записать в файл?");
                            s1 = Console.ReadLine();
                            a = Convert.ToInt32(s1);

                            FileStream f = new FileStream(name, FileMode.OpenOrCreate);
                            f.SetLength(0);

                            for (int i = 0; i < a; i++)
                            {
                                f.WriteByte((byte)(random.Next(0, 99)));
                            }
                            f.Close();

                            while (v1 != 0)
                                {
                                Console.Clear();
                                f = new FileStream(name, FileMode.OpenOrCreate);
                                f.Seek(0, SeekOrigin.Begin);
                                for (long i = 0; i < f.Length; i++ )
                                {
                                    Console.Write((int)f.ReadByte() + " ");
                                }
                                f.Close();

                                Console.WriteLine("\n");
                                Console.WriteLine("1) Найти сумму наименьшего и наибольшего значения в файле\n2) Добавить число на случаенную позицию\n3) Скопировать файл\n4) Получить информацию о файле\n\n0) Выход \n\nВведите номер метода : ");
                                    sn = Console.ReadLine(); 
                                    v1 = Convert.ToInt32(sn);
                                    switch (v1)
                                    {
                                        case 1:
                                            {
                                            Console.Clear();
                                            int min = 99, max = 0, d;

                                            f = new FileStream(name, FileMode.OpenOrCreate);
                                            f.Seek(0, SeekOrigin.Begin);
                                            for (long i = 0; i < f.Length; i++)
                                            {
                                                Console.Write((int)f.ReadByte() + " ");
                                            }
                                            Console.WriteLine("\n");
                                            f.Seek(0, SeekOrigin.Begin);
                                            for (long i = 0; i < f.Length; i++)
                                            {
                                                d = (int)f.ReadByte();
                                                if (d < min) { min = d; }
                                                if (d > max) { max = d; }
                                            }
                                            f.Close();

                                            Console.WriteLine("Cумма наибольшего и наименьшего: " + (max + min));

                                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                            s1 = Console.ReadLine();
                                            break;
                                            }
                                        case 2:
                                            {
                                            Console.Clear();
                                            Console.WriteLine("Какое значение вы хотите добавить в ряд?");
                                            s1 = Console.ReadLine();
                                            int x = Convert.ToInt32(s1);
                                            int number = random.Next(0, a);

                                            f = new FileStream(name, FileMode.OpenOrCreate);
                                            f.Seek(number, SeekOrigin.Begin);
                                            f.WriteByte((byte)(x));
                                            f.Close();
                                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                            s1 = Console.ReadLine();
                                            break;
                                            }
                                        case 3:
                                            {
                                            Console.Clear();
                                            f = new FileStream(name, FileMode.OpenOrCreate);
                                            FileStream f2 = new FileStream(namecopy, FileMode.OpenOrCreate);
                                            f2.SetLength(0);

                                            f.CopyTo(f2);
                                            f2.Seek(0, SeekOrigin.Begin);
                                            Console.WriteLine("Содержание файла-копии:");
                                            for (long i = 0; i < f2.Length; i++)
                                            {
                                                Console.Write((int)f2.ReadByte() + " ");
                                            }
                                            Console.WriteLine("\n");
                                            f.Close();
                                            f2.Close();
                                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                            s1 = Console.ReadLine();
                                            break;
                                            }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Время создания файла: " + File.GetCreationTime(name));
                                            Console.WriteLine("Время последней записи в файл: " + File.GetLastWriteTime(name));
                                            Console.WriteLine("Время последнего доступа к файлу: " + File.GetLastAccessTime(name));
                                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                                            s1 = Console.ReadLine();
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
