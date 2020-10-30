using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_005
{
    class Program
    {

        //task1
        /// <summary>
        /// multiplication matrix by number
        /// </summary>
        /// <param name="a">"a" is matrix while "number" is a factor</param>
        /// <param name="number">matrix</param>
        static int[,] MatrixByNumber(int[,] a, int number)
        {
            int[,] newMatrix = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    newMatrix[i, j] = a[i,j] * number;
                }
            }
            return newMatrix;
        }
        /// <summary>
        /// method which is created matrices and fill them with random numbers
        /// </summary>
        /// <param name="a">first dimension</param>
        /// <param name="b">second dimension</param>
        /// <param name="rand">randomizer</param>
        /// <returns>matrix</returns>
        static int[,] CreateAndFillMatrix(int a, int b, Random rand)
        {
            int[,] matrix = new int[a,b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix[i,j] = rand.Next(1, 4);
                }
            }
            return matrix;
        }
        /// <summary>
        /// print the matrix
        /// </summary>
        /// <param name="a">matrix</param>
        static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j], 4} ");
                }
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// add two matrices
        /// </summary>
        /// <param name="a">is the first matrix</param>
        /// <param name="b">is the second matrix</param>
        /// <returns>return the sum of the matrices</returns>
        static int[,] SumOfMatrices(int[,] a, int[,] b)
        {
            int[,] newMatrix = new int[a.GetLength(0), a.GetLength(1)]; 

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    newMatrix[i, j] = a[i, j] + b[i, j];
                }
            }
            return newMatrix;
        }
        /// <summary>
        /// multiplication of two matrices
        /// </summary>
        /// <param name="a">the first matrix</param>
        /// <param name="b">the second matrix</param>
        /// <returns>return the product of these two matrices</returns>
        static int[,] ProductOfMatrces(int[,] a, int[,] b)
        {
            int[,] newMatrix = new int[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {           
                        newMatrix[i, j] += a[i, k] * b[k, j]; 
                    }
                }               
            }
            return newMatrix;   
        }

        // task 2 
        /// <summary>
        /// this function can find smallest word in a string
        /// </summary>
        /// <param name="str">str - input string</param>
        /// <returns>return smallest word</returns>
        static String smallestWord(String str)
        {
            String[] text = str.Split();
            String smallest = text[0];
            for (int i = 1; i < text.Length; i++)
            {        
                if (text[i].Length < smallest.Length)
                {
                    smallest = text[i];
                }
            }
            return smallest;
        }
        /// <summary>
        /// function finds biggest word in the string
        /// </summary>
        /// <param name="str">str is a string</param>
        /// <returns>return the list of longest words in the string</returns>
        static List<string> longestWords(string str)
        {
            char[] separators = new char[] { ' ', '.', ','};
            string[] arrText = str.Split(separators);
            List<string> outString = new List<string>();
            String biggest = arrText[0];
            for (int i = 1; i < arrText.Length; i++)
            {
                if (arrText[i].Length > biggest.Length)
                {
                    biggest = arrText[i];
                    outString.Clear();
                    outString.Add(arrText[i]);
                }
                else if (arrText[i].Length == biggest.Length)
                {
                    outString.Add(arrText[i]);
                }
            }
            //foreach (var item in arrText)
            //{
            //    if (item.Length == biggest.Length)
            //    {
            //        outString.Add(item);
            //    }
            //}
            return outString;
        }
        /// <summary>
        /// print the list of longest words
        /// </summary>
        /// <param name="a">list of words</param>
        static void Question2B(List<string> a)
        {
            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
        }

        // task 3
        /// <summary>
        /// function deletes the sequences of same characters
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>return altered string without sequences of the same characters </returns>
        static string DeleteSame(string str)
        {
            List<char> array = new List<char>();
            char compared = str[0];
            array.Add(compared);
            for (int i = 1; i < str.Length; i++)
            {
                if (!(compared.ToString().Equals(str[i].ToString(), StringComparison.CurrentCultureIgnoreCase)))
                {                  
                    compared = str[i];
                    array.Add(compared);
                }
            }
            string result = new string(array.ToArray());
            return result;
        }

        // task 4
        /// <summary>
        /// function determines is sequence in progression or no
        /// </summary>
        /// <param name="a">sequences of numbers</param>
        /// <returns>return either true or false</returns>
        static bool IsItProggression(params double[] a)
        {
            float e = 0.000001f;
            bool result = true;
            double difference;
            difference = a[1] / a[0];
            for (int i = 1; i < a.Length - 1; i++)
            {
                if ((Math.Abs(((a[i + 1] / a[i]) - (difference))) > e))
                {
                    result = false;
                    break;
                }
            }
            if (result) return true;
            difference = a[1] - a[0];
            for (int i = 1; i < a.Length - 1; i++)
            {
                if (!((a[i + 1] - a[i]) == difference))
                {
                    return false;
                }
            }
            return true;
        }

        // task 5
        /// <summary>
        /// have no idea
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static double AckermannFunction(double n, double m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if (m == 0 || n > 0)
            {
                return AckermannFunction(n - 1, 1);
            }
            else
            {
                return AckermannFunction(n - 1, AckermannFunction(n, m - 1));
            }

        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] firstMatrix = CreateAndFillMatrix(3, 3, rand);
            int[,] secondMatrix = CreateAndFillMatrix(3, 3, rand);
            //Quest1
            //PrintMatrix(MatrixByNumber(firstMatrix, 4)); //A
            //PrintMatrix(SumOfMatrices(firstMatrix, secondMatrix)); //B
            //PrintMatrix(ProductOfMatrces(firstMatrix, secondMatrix)); //C

            //Quest2

            //Console.WriteLine(smallestWord("slw fw fdkfd kdfkdk fff fkkfkf weqwd ccx")); //Quest2A
            //Question2B(longestWords("slw, fw ,fdkfd ,kdfkdk, f.fkkfkf .weqwd ccx kdfkfk")); //Quest2B

            //Quest3
            //Console.Write(DeleteSame("ХхХхХххоооорррооошшшиий деееннннь")); //Quest3

            //Quest4
            Console.WriteLine(IsItProggression(3, 9, 27, 81) ? "Proggression" : "Not Proggression");

            //Quest5
            //Console.WriteLine(AckermannFunction(2, 5));
            Console.ReadLine();
        }
    }
}
