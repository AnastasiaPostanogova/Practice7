using System;
using System.Collections.Generic;
using System.Linq;

namespace Задача_7
{
    class Program
    {
        private static List<string> words;

        static bool Check(int[] lengths)//проверка длин кодовых слов по неравенству Макмиллана
        {
            double sum = 0;
            foreach (int number in lengths)
                sum += 1 / Math.Pow(2, number);

            if (sum <= 1)
                return true;
            return false;
        }

        public static int[] Input()
        {
            Console.WriteLine("Введите колличество длин слов");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длины слов");
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        static void GenerateWord(int length, int currentLength, string word)
        {
            if (currentLength == length)
                words.Add(word);
            else
            {
                if (!words.Contains(word + '0'))
                    GenerateWord(length, currentLength + 1, word + '0');
                else if (!words.Contains(word + '1'))
                    GenerateWord(length, currentLength + 1, word + '1');
            }
        }

        static void Main(string[] args)
        {
            bool ok;
            int[] wordlength;
            do
            {
                wordlength = Input();
                ok = Check(wordlength);
                if (!ok)
                    Console.WriteLine("Ошибка! Введенные длины кодовых слов не прошли проверку по неравенству Макмиллана. Повторите ввод.");
            } while (!ok);

            wordlength = wordlength.OrderBy(num => num).ToArray();

            words = new List<string>(wordlength.Length);
            foreach (int length in wordlength)
                GenerateWord(length, 0, "");

            Console.Write("Полученный префиксный код: ");
            foreach (string word in words)
                Console.Write("{0} ", word);
            Console.ReadLine();
        }
    }
}