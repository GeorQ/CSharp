using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_01
{
    class Program
    {
        static void Main(string[] args)
        {
            MainQuests();
        }
        /// <summary>
        /// Return info about student 
        /// </summary>
        private static void MainQuests()
        {
            /*  Setting up 
            *  all vars
            */
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Console.Write("Возвраст: ");
            short age =  Int16.Parse(Console.ReadLine());
            Console.Write("Рост: ");
            short height =  Int16.Parse(Console.ReadLine());
            byte[] marks = new byte[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Оценка: ");
                marks[i] = Convert.ToByte(Console.ReadLine());
            }
            Console.WriteLine("\n\n\n");
            float avarage = (float)(marks[0] + marks[1] + marks[2]) / marks.Length; //Getting an avarage mark

            #region Обычный вывод
            Console.WriteLine("Имя: " + name + "\nВозвраст: " + age + "\nРост: " + height + "\nСредняя оценка: " + avarage + "\n\n\n"); //Оычный вывод
            #endregion

            #region Форматированный вывод
            Console.WriteLine("Имя: {0}\nВозвраст: {1}\nРост: {2}\nСредняя оценка: {3}", name, age, height, avarage + "\n\n\n"); //Форматированный вывод
            #endregion

            #region Использование интерполяции
            Console.WriteLine($"Имя: {name}\nВозвраст: {age}\nРост: {height}\nСредняя оценка: {avarage}"); //использование интерполяции
            #endregion

            Console.WriteLine("\n\n\n");

            Console.SetCursorPosition((Console.WindowWidth - name.Length) / 2, Console.CursorTop);
            Console.WriteLine(name);

            Console.SetCursorPosition((Console.WindowWidth - age.ToString().Length) / 2, Console.CursorTop);
            Console.WriteLine(age);

            Console.SetCursorPosition((Console.WindowWidth - height.ToString().Length) / 2, Console.CursorTop);
            Console.WriteLine(height);

            Console.SetCursorPosition((Console.WindowWidth - avarage.ToString().Length) / 2, Console.CursorTop);
            Console.WriteLine(avarage);

            Console.ReadKey();
        }
        /// <summary>
        /// Return info about student at the middle of screen
        /// </summary>
       
    }
}
