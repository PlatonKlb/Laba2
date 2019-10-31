﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Begining();         //Одна строчка в фунции Main как вы любите
        }
        static void Begining()
        {
            string input = "";
            while (input != "stop")
            {
                Console.WriteLine("\tЗдравствуйте");
                Console.WriteLine(" Как вы хотите ввести массив? " +
                    "\n 1. С клавиатуры." +
                    "\n 2. Из файла.");
                input = Console.ReadLine();
                string textMatrix = "";
                if (input == "1")
                    textMatrix = KeyboardParse(input);
                else if (input == "2")
                    textMatrix = FileParse(input);
                ArrayHandler(ParseString(textMatrix));
            }
        }
        static void ArrayHandler(int[][] array)         //Функция определяющая массив
        {
            Console.Clear();
            if (array.Length == 1)
            {
                new FunctionsOM(array);         //OM - одномерный массив
                return;
            }
            for (int i = array.Length - 1; i > 0; i--)
                if (array[i].Length != array[i - 1].Length)
                {
                    new FunctionsSM(array);         //DM - двумерный массив
                    return;
                }
            new FunctionsDM(array);         //SM - ступенчатый массив
        }
        static string FileParse(string input)           //Данная функция отвечает за: ввод массива с файла
        {
            Console.Clear();
            Console.WriteLine(" Введите путь к файлу или перетащите нужный файл в данное окно.");
            input = Console.ReadLine();
            return File.ReadAllText(input);
        }
        static string KeyboardParse(string input)           //Данная функция отвечает за: ввод массива с клавиатуры
        {
            Console.Clear();
            Console.WriteLine("Введите данные построчно :" +
                "\n 1. Используйте пробел для разделения элементов массива" +
                "\n 2. Используйте Enter для разделения строк." +
                "\n 3. Используйте stop на новой строке для завершения ввода массива.");
            string array = "";
            input = Console.ReadLine();
            while (input != "stop")
            {
                array += input;
                input = Console.ReadLine();
                if (input != "")
                    array += "\r\n";
            }
            return array;
        }
        static int[][] ParseString(string matrix)           //Делю полученные строчки по пробелам и переносу строки
        {
            string[] arrayOfStrings = matrix.Split(new string[] { "\r\n" }, StringSplitOptions.None);           //Программа определяет перенос строки (Обязательно прокомментировать \r\n)
            int[][] array = new int[arrayOfStrings.Length][];
            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                string[] numbers = arrayOfStrings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);          //Делю по признаку ПРОБЕЛ
                array[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    array[i][j] = int.Parse(numbers[j]);
                }
            }
            return array;
        }
    }
    class FunctionsOM           //Класс отвечающий за функции и меню одномерного массива
    {
        int[] array;
        public FunctionsOM(int[][] array)
        {
            this.array = array[0];          //Присваиваю длинну массива
            Menu();
        }
        public void Menu()          //Данная функция отвечает за: меню одномерного массива
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine(" 1. Вывести массив. " +
                "\n 2. Выполнить сортировку." +
                "\n 3. Выполнить обратную сортировку." +
                "\n 4. Заполнить новый массив четными данными из исходного." +
                "\n 5. Поиск минимального значения." +
                "\n 6. Поиск максимального значения.");
            string input = "";
            while (input != "stop")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":       //Вывод массива
                        {
                            Console.WriteLine("Ваш массив :");
                            OutPut();
                            break;
                        }
                    case "2":       //Прямая сортировка массива
                        {
                            Sort();
                            Console.WriteLine("Сортировка - выполнена.");
                            break;
                        }
                    case "3":       //Обратная сортировка массива
                        {
                            ReverseSort();
                            Console.WriteLine("Обратная сортировка - выполнена");
                            break;
                        }
                    case "4":       //Создание нового ЧЕТНОГО массива и его вывод
                        {
                            XOR2();
                            Console.WriteLine("Создание нового четного массива - выполнено :");
                            break;
                        }
                    case "5":       //Поиск минимального значения
                        {
                            Min();
                            Console.WriteLine("Поиск минимального значения - выполнено :");
                            break;
                        }
                    case "6":       //Поиск максимального значения
                        {
                            Max();
                            Console.WriteLine("Поиск максимального значения - выполнено :");
                            break;
                        }
                    default:        //Проверка на дурака
                        {
                            Console.WriteLine("Выбран не существующий пункт!");
                            break;
                        }
                }
            }
        }
        public void OutPut()            //Данная функция отвечает за: вывод одномерного массива
        {
            foreach (int x in array)
                Console.Write(x + " ");
        }
        public void Sort()          //Данная функция отвечает за: сортировку массива
        {
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = 0; j < array.Length - 1; j++)
                        if (array[j] > array[j + 1])
                        {
                            int t = array[j + 1];
                            array[j + 1] = array[j];
                            array[j] = t;
                        }
            }
        }
        public void ReverseSort()           //Данная функция отвечает за: обратную сортировку массива
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] < array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }
        public void XOR2()          //Данная функция отвечает за: создания нового четного массива (XOR2 - деление на 2 с остатком)
        {
            int[] tempArray = new int[array.Length];
            int n = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 == 0)
                {
                    tempArray[n] = array[i];
                    n++;
                }
            Array.Resize(ref tempArray, n);
            array = tempArray;
        }
        public void Max()           //Данная функция отвечает за: поиск максимального значения
        {
            int max = array[0];
            for (int i = 0; i < array.Length - 1; i++)
                if (max < array[i])
                    max = array[i];
            Console.WriteLine("Индекс: " + Array.IndexOf(array, max) + " Значение: " + max);
        }
        public void Min()           //Данная функция отвечает за: поиск минимального значения
        {
            int min = array[0];
            for (int i = 0; i < array.Length - 1; i++)
                if (min > array[i])
                    min = array[i];
            Console.WriteLine("Индекс: " + Array.IndexOf(array, min) + " Значение: " + min);
        }
    }
    class FunctionsDM           //Класс отвечающий за функции и меню двумерного массива
    {
        int[,] array;
        public FunctionsDM(int[][] array)
        {
            this.array = new int[array.Length, array[0].Length];
            for (int i = 0; i < array.Length; i++)          //Иду по строкам
                for (int j = 0; j < array[0].Length; j++)           //Иду по столбцам
                    this.array[i, j] = array[i][j];
            Menu();
        }
        public void Menu()          //Данная функция отвечает за: меню двумерного массива
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine(" 1. Вывести массив. " +
                "\n 2. Поиск минимального значения." +
                "\n 3. Поиск максимального значения." +
                "\n 4. Поиск суммы/разности/произведения двух массивов.");
            string input = "";
            while (input != "stop")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":           //Вывод массива
                        {
                            OutPut();
                            break;
                        }
                    case "2":           //Поиск минимального значения
                        {
                            Min();
                            break;
                        }
                    case "3":           //Поиск максимального значения
                        {
                            Max();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("\tДобрый день, Ульви." +
                                "\n Я прошу прощения за отсутствие данной функции." +
                                "\n Если без неё вы не примите лабу," +
                                "\n то назовите пожалуйста сроки в которые я могу её сдать.")
                            break;
                        }
                    default:        //Проверка на дурака
                        {
                            Console.WriteLine("Выбран не существующий пункт!");
                            break;
                        }
                }
            }
        }
        public void OutPut()            //Данная функция отвечает за: вывод массива
        {
            for (int i = 0; i < array.GetLength(0); i++)            //Использую GetLength(0) для подсчета количества строк
            {
                for (int j = 0; j < array.GetLength(1); j++)            //Использую GetLength(1) для подсчета количества столбцов
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }
        }
        public void Max()           //Данная функция отвечает за: поиск максимального элемента и его вывод
        {
            int r = 0;
            int c = 0;
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max < array[i, j])
                    {
                        max = array[i, j];
                        r = i;
                        c = j;
                    }
                }
            }
            Console.WriteLine($"Индекс {r} {c} Значение: {max}");           //Использую знак $ для сокращения кода вставкой {переменная} в текст
        }
        public void Min()           //Данная функция отвечает за: поиск минимального элемента и его вывод
        {
            int r = 0;
            int c = 0;
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)            
            {
                for (int j = 0; j < array.GetLength(1); j++)        
                {
                    if (min > array[i, j])
                    {
                        min = array[i, j];
                        r = i;
                        c = j;
                    }
                }
            }
            Console.WriteLine($"Индекс {r} {c} Значение: {min}");
        }
    }
    class FunctionsSM           //Класс отвечающий за функции и меню ступенчатого массива
    {
        int[][] array;
        public FunctionsSM(int[][] array)
        {
            this.array = array;
            Menu();
        }
        public void Menu()          //Данная функция отвечает за: меню ступенчатого массива
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine(" 1. Вывести массив. " +
                "\n 2. Поиск минимального значения." +
                "\n 3. Поиск максимального значения." +
                "\n 4. Измнить элемент массива.");
            string input = "";
            while (input != "stop")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":           //Вывод массива
                        {
                            Output();
                            break;
                        }
                    case "2":           //Поиск минимального элемента
                        {
                            Min();
                            break;
                        }
                    case "3":           //Поиск максимального элемента
                        {
                            Max();
                            break;
                        }
                    case "4":           //Изменение элемента
                        {
                            ChangeElements();
                            break;
                        }
                    default:        //Проверка на дурака
                        {
                            Console.WriteLine("Выбран не существующий пункт!");
                            break;
                        }
                }
            }
        }
        public void Output()            //Данная функция отвечает за: вывод массива
        {
            for (int i = 0; i < array.Length; i++)          //Ищу длинну массива (array.Length)
            {
                for (int j = 0; j < array[i].Length; j++)           //Ищу длину каждой строки массива (array.Length[i][j])
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
        }
        public void Max()           //Данная функция отвечает за: поиск максимального элемента
        {
            int r = 0;
            int c = 0;

            int max = array[0][0];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (max < array[i][j])
                    {
                        max = array[i][j];
                        r = i;
                        c = j;
                    }
                }
            }

            Console.WriteLine($"Индекс {r} {c} Значение: {max}");
        }

        public void Min()           //Данная функция отвечает за: поиск минимального элемента
        {
            int r = 0;
            int c = 0;

            int min = array[0][0];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (min > array[i][j])
                    {
                        min = array[i][j];
                        r = i;
                        c = j;
                    }
                }
            }
            Console.WriteLine($"Индекс {r} {c} Значение: {min}");
        }

        public void ChangeElements()            //Данная функция отвечает за: изменение элемента
        {
            string input = "";

            Console.WriteLine("Введите индексы через пробел");
            input = Console.ReadLine();

            int i = int.Parse(input.Split(' ')[0]);         //Делю строку и беру первый элемент (индекс = 0)
            int j = int.Parse(input.Split(' ')[1]);         //Делю строку и беру второй элемент (индекс = 1)

            if (i > array.Length || i < 0)          //Проверка на дурака
                Console.WriteLine("Ошибка ввода индекса");
            else if (j > array[i].Length || j < 0)          //Проверка на дурака
                Console.WriteLine("Ошибка ввода индекса");
            else
            {
                Console.WriteLine($"Элемент найден! Значение: {array[i][j]}. Введите новое значение");
                array[i][j] = int.Parse(Console.ReadLine());            //Изменение элемента
            }
        }
    }
}