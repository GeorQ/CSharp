using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        private static bool isFirstPerson = true;
        private static byte typeOfGame;
        private static bool isFinished;
        private static int gameNumberMax;
        private static int gameNumberMin;
        private static int gameNumber;
        private static int gameRange;
        private static int userTry;
        static void Main(string[] args)
        { 
            Console.WriteLine("ВВедите - '1' для игры вдвоем");
            Console.WriteLine("Введите - '2' для игры с искусственным интеллектом с легким уровнем сложности");
            Console.Write("Ваш выбор: ");

            while (!byte.TryParse(Console.ReadLine(), out typeOfGame))
            {
                Console.WriteLine("Пожалуйста введите корректное число!");
                Console.Write("Ваш выбор: ");
            }
            Console.Clear();
            if (typeOfGame == 1) TwoPlayers();
            else AI();
        }

        private static void TwoPlayers()
        {
            Console.Write("Введите имя первого игрока: ");
            string firstPlayerName = Console.ReadLine();
            Console.Write("Введите имя воторого игрока: ");
            string secondPlayerName = Console.ReadLine();
            Console.WriteLine();
            CommonStuff();

            while (!isFinished)
            {
                isFinished = StepTwoPl(firstPlayerName, secondPlayerName);
            }

            if (isFirstPerson)
            {
                Console.WriteLine("Поздравляем {0} с победой!!!", firstPlayerName);
            }
            else
            {
                Console.WriteLine("Поздравляем {0} с победой!!!", secondPlayerName);
            }
            Console.ReadLine();

        }

        private static bool StepTwoPl(string fName, string sName)
        {
            if (isFirstPerson)
            {
                Console.WriteLine("Число - {0}", gameNumber);
                Console.WriteLine("{0} введите число, которое хотите отнять. Оно должно быть не большее {1} и не меньшее 1", fName, gameRange);
                Console.Write("Ваше число: ");
                while ((!int.TryParse(Console.ReadLine(), out userTry)) || (!CheckNumber(userTry)))
                {
                    Console.WriteLine("Пожалуйста введите корректное число!");
                    Console.Write("Ваш выбор: ");
                }
                gameNumber -= userTry;
                if (gameNumber == 0)
                {
                    return true;
                }
                isFirstPerson = !isFirstPerson;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Число - {0}", gameNumber);
                Console.WriteLine("{0} введите число, которое хотите отнять. Оно должно быть не большее {1} и не меньшее 1", sName, gameRange);
                Console.Write("Ваше число: ");
                while ((!int.TryParse(Console.ReadLine(), out userTry)) || (!CheckNumber(userTry)))
                {
                    Console.WriteLine("Пожалуйста введите корректное число!");
                    Console.Write("Ваш выбор: ");
                }
                gameNumber -= userTry;
                if (gameNumber == 0)
                {
                    return true;
                }
                isFirstPerson = !isFirstPerson;
                Console.Clear();
            }
            return isFinished;
        }
        
        private static bool CheckNumber(int tryNum)
        {
            if (gameNumber - tryNum < 0) return false;
            for (int i = 1; i <= gameRange; i++)
            {
                if (tryNum == i)
                {
                    return true;
                }
            }
            return false;
        }

        public static void AI()
        {
            Console.Write("Введите имя игрока: ");
            string firstPlayerName = Console.ReadLine();
            Console.WriteLine();
            CommonStuff();
            Random rand = new Random();
            while (!isFinished)
            {
                isFinished = StepAI(firstPlayerName, rand);
            }

            if (isFirstPerson)
            {
                Console.WriteLine("Поздравляем {0} с победой!!!", firstPlayerName);
            }
            else
            {
                Console.WriteLine("Поздравляем искусственный интелект с победой!!!");
            }
            Console.ReadLine();
        }


        private static bool StepAI(string name, Random random)
        {
            if (isFirstPerson)
            {
                Console.WriteLine("Число - {0}", gameNumber);
                Console.WriteLine("{0} введите число, которое хотите отнять. Оно должно быть не большее {1} и не меньшее 1", name, gameRange);
                Console.Write("Ваше число: ");
                while ((!int.TryParse(Console.ReadLine(), out userTry)) || (!CheckNumber(userTry)))
                {
                    Console.WriteLine("Пожалуйста введите корректное число!");
                    Console.Write("Ваш выбор: ");
                }
                gameNumber -= userTry;
                if (gameNumber == 0)
                {
                    return true;
                }
                isFirstPerson = !isFirstPerson;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Число - {0}", gameNumber);
                Console.WriteLine("Компьютер думает");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(300);
                    Console.Write(".");
                }
                Console.WriteLine();
                int aIMove = random.Next(1, gameRange + 1);
         
                while (!CheckNumber(aIMove))
                {
                    aIMove = random.Next(1, gameRange + 1);
                }
                Console.WriteLine("Компьютер выбрал число {0}", aIMove);
                gameNumber -= userTry;
                if (gameNumber == 0)
                {
                    return true;
                }
                isFirstPerson = !isFirstPerson;
                Console.WriteLine("Теперь число равно = {0}", gameNumber);
                Thread.Sleep(2000);
                Console.Clear();
            }
            return isFinished;
        }
        private static void CommonStuff()
        {
            Console.Write("Введите минимальное число: ");
            while (!int.TryParse(Console.ReadLine(), out gameNumberMin) || !(gameNumberMin > 0))
            {
                Console.WriteLine("Пожалуйста введите корректное число!");
                Console.Write("Ваш выбор: ");
            }
            Console.Write("Введите максимальное число: ");
            while (!int.TryParse(Console.ReadLine(), out gameNumberMax) || !(gameNumberMax > gameNumberMin))
            {
                Console.WriteLine("Пожалуйста введите корректное число!");
                Console.Write("Ваш выбор: ");
            }
            Console.Clear();

            Random random = new Random();
            gameNumber = random.Next(gameNumberMin, gameNumberMax + 1);
            Console.WriteLine("Компьютер загадал число {0}\n", gameNumber);

            Console.WriteLine("Теперь выберите число, которое будете отнимать. Числа, меньшие этого числа будут отниматся также");
            Console.WriteLine("Например, если вы введете число '5' то вы сможете отнимать числа: (5,4,3,2,1) ");
            Console.Write("Ваше число: ");
            while (!int.TryParse(Console.ReadLine(), out gameRange))
            {
                Console.WriteLine("Пожалуйста введите корректное число!");
                Console.Write("Ваш выбор: ");
            }
            Console.Clear();
        }
    }
}
