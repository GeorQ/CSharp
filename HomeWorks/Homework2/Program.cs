using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static void Main(string[] args)
        {

            //FirstTask();
            SecondTask();
            //ThirdTask();
            Console.ReadLine();

  
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
                                                            
            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            //
            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  
            //
        }


        private static void FirstTask()
        {           
            Random rand = new Random();
            int[] income = new int[12];
            int[] costs = new int[12];
            int[] profit = new int[12];
            int[] minValueArr = new int[3];
            int[] profitBackUp = new int[12];
            int positiveOut = 0;
            for (int i = 0; i < income.Length; i++)
            {
                income[i] = rand.Next(60_000, 200_000);
                costs[i] = rand.Next(40_000, 120_000);
                profit[i] = income[i] - costs[i];
                profitBackUp[i] = profit[i];
                if (profit[i] > 0) positiveOut++;
                Console.WriteLine($"{i + 1, 2}   {income[i], 8:### ###}   {costs[i], 8:### ###}   {profit[i], 8:### ###}");
            }

            Array.Sort(profit);
            for (int i = 0; i < minValueArr.Length; i++)
            {
                minValueArr[i] = profit[i];
            }
            Console.Write("\nХудшая прибыль в месяцах: ");
            for (int i = 0; i < profitBackUp.Length; i++)
            {
                if (Array.IndexOf(minValueArr, profitBackUp[i]) != -1) Console.Write($"{i + 1} ");
            }
            Console.WriteLine($"\nМесяцев с положительной прибылью: {positiveOut}");
        }
        private static void SecondTask()
        {
            Random rand = new Random();
            Console.WriteLine("Введите число");
            byte.TryParse(Console.ReadLine(), out byte N);
            int[][] array = new int[N][];

            for (int i = 0; i < N; i++)
            {
                array[i] = new int[i + 1];
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if ((j == 0) || (i == j)) array[i][j] = 1;
                    else array[i][j] = array[i-1][j] + array[i-1][j-1];
                }
            }

            foreach (int[] part in array){
                Console.WriteLine();
                foreach (int item in part)
                {
                    Console.Write($"{item, 8}");
                }
            }
            Console.ReadLine();
            // 1 (0,0)
            // 1 (1,0) 1 (1,1)
            // 1 (2,0) 2 (2,1) 1 (2,2   ) 
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1



        }

        private static void ThirdTask()
        {
            bool isFinished = false;
            int option;
            while (!isFinished)
            {
                Console.WriteLine("1) - Для умножения матрицы на число\n2) - Для сложения или вычитания матрицы на другую матрицу\n3) - Для умножения матрицы на другую матрицу");
                Console.Write("Ваш выбор: ");
                String input = Console.ReadLine();
                while (!(((Int32.TryParse(input, out option)) && ((option > 0) && (option < 4))) || (input.ToLower().Equals("exit"))))
                {
                    Console.Clear();
                    Console.WriteLine("Пожалуйста введите корректные данные");
                    Console.WriteLine("1) - Для умножения матрицы на число\n2) - Для сложения или вычитания матрицы на другую матрицу\n3) - Для умножения матрицы на другую матрицу");
                    Console.Write("Ваш выбор: ");
                    input = Console.ReadLine();
                }
                Console.Clear();
                if (option == 1) ThirdTask_1();
                else if (option == 2) ThirdTask_2();
                else if (option == 3) ThirdTask_3();
                else break;

            }
        }

        private static void ThirdTask_1()
        {
            Console.Write("Введите количеств рядов: ");
            Int32.TryParse(Console.ReadLine(), out int numOfrows);
            Console.Write("Введите количеств столбцов: ");
            Int32.TryParse(Console.ReadLine(), out int numOfColumns);
            Console.Write("Введите множитель: ");
            Int32.TryParse(Console.ReadLine(), out int factor);

            Random rand = new Random();
            int[,] matrix = new int[numOfrows, numOfColumns];
            int numSpace = 10;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == matrix.GetLength(0) / 2)
                {
                    Console.Write($"    {factor} X" + new string(' ', numSpace - factor.ToString().Length - 6 ));
                }
                else Console.Write(new string(' ', numSpace));
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(1, 20);
                    Console.Write($"{matrix[i, j], 4}");
                }
                Console.Write(" |");

                if (i == matrix.GetLength(0) / 2)
                {
                    Console.Write($"    = " + new string(' ', numSpace - 6));
                }
                else Console.Write(new string(' ', numSpace));
                Console.Write("|");
 
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= factor;
                    Console.Write($"{matrix[i, j], 4}");
                }
                Console.WriteLine(" |");
            }
            Console.WriteLine("\n\n\n");
        }

        private static void ThirdTask_2()
        {
            int numOfRowsFirst;
            int numOfColumnsFirst;
            int numOfRowsSecond;
            int numOfColumnsSecond;
            do
            {
                Console.Write("Введите количеств рядов для первой матрицы: ");
                Int32.TryParse(Console.ReadLine(), out  numOfRowsFirst);

                Console.Write("Введите количеств столбцов для первой матрицы: ");
                Int32.TryParse(Console.ReadLine(), out  numOfColumnsFirst);

                Console.Write("Введите количеств рядов для второй матрицы: ");
                Int32.TryParse(Console.ReadLine(), out  numOfRowsSecond);

                Console.Write("Введите количеств столбцов для второй матрицы: ");
                Int32.TryParse(Console.ReadLine(), out  numOfColumnsSecond);
                Console.Clear();
            } while ((numOfRowsFirst != numOfRowsSecond) || (numOfColumnsFirst != numOfColumnsSecond));


           

            Random rand = new Random();
            Char[] array = new char[] { '+', '-' };
            String sign;
            while (true)
            {
                Console.WriteLine("Введите '+' или '-' ");
                sign = Console.ReadLine();
                if (Array.IndexOf(array, char.Parse(sign)) != -1)
                {
                    Console.WriteLine();
                    break;
                }
                Console.Clear();
                Console.WriteLine("Введите корректный символ");
            }
            int[,] firstMatrix = new int[numOfRowsFirst, numOfColumnsFirst];
            int[,] secondMatrix = new int[numOfRowsSecond, numOfColumnsSecond];
            int numSpace = 10;

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    firstMatrix[i, j] = rand.Next(1, 20);
                    Console.Write($"{firstMatrix[i, j],4}");
                }
                Console.Write(" |");
                if (i == firstMatrix.GetLength(0) / 2)
                {
                    Console.Write($"    {sign} " + new string(' ', numSpace - 6));
                }
                else Console.Write(new string(' ', numSpace));
                Console.Write("|");
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    secondMatrix[i, j] = rand.Next(1, 20);
                    Console.Write($"{secondMatrix[i, j],4}");
                }
                Console.Write(" |");
                if (i == firstMatrix.GetLength(0) / 2)
                {
                    Console.Write($"    = " + new string(' ', numSpace - 6));
                }
                else Console.Write(new string(' ', numSpace));
                Console.Write("|");
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    if (sign == "-") Console.Write($"{firstMatrix[i, j] - secondMatrix[i, j],4}");
                    else Console.Write($"{firstMatrix[i, j] + secondMatrix[i, j],4}");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("\n\n\n");
        }

        private static void ThirdTask_3()
        {
            Console.WriteLine("Сорри просто лень");
        }
    }
}
