using System;
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
            Begining();
        }
        static void Begining()
        {
            string input = "";
            while (input != "stop")
            {
                Console.WriteLine("\tЗдравствуйте");
                Console.WriteLine(" Как вы хотите ввести массив? " +
                    "\n 1. С клавиатуры " +
                    "\n 2. Из файла");

                input = Console.ReadLine();

                string textMatrix = "";

                if (input == "1")                      
                    textMatrix = KeyboardParse(input);
                else if (input == "2")
                    textMatrix = FileParse(input);

                ArrayHandler(ParseString(textMatrix));
            }
        }
        static void ArrayHandler(int[][] array)
        {
            Console.Clear();

            if (array.Length == 1)
            {
                new FunctionsOM(array);
                return;
            }

            for (int i = array.Length - 1; i > 0; i--)
                if (array[i].Length != array[i - 1].Length)
                {
                    new FunctionsSM(array);
                    return;
                }

            new FunctionsDM(array);
        }

        static string FileParse(string input)
        {
            Console.Clear();
            Console.WriteLine("Введите путь к файлу");

            input = Console.ReadLine();

            return File.ReadAllText(input);
        }

        static string KeyboardParse(string input)
        {
            Console.Clear();
            Console.WriteLine("Введите данные построчно");

            string array = "";

            input = Console.ReadLine();

            while (input != "")
            {
                array += input;
                input = Console.ReadLine();

                if (input != "")
                    array += "\r\n";
            }

            return array;
        }

        static int[][] ParseString(string matrix)
        {

            string[] arrayOfStrings = matrix.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            int[][] array = new int[arrayOfStrings.Length][];

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                string[] numbers = arrayOfStrings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    array[i][j] = int.Parse(numbers[j]);
                }
            }
            return array;
        }
    }


    class FunctionsOM
    {
        int[] array;
        public FunctionsOM(int[][] array)
        {
            this.array = array[0];
            Menu();
        }
        public void Menu()
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine(" 1. Вывести массив. " +
                "\n 2. Выполнить сортировку." +
                "\n 3. Выполнить обратную сортировку." +
                "\n 4. Заполнить новый массив четными данными из исходного" +
                "\n 5. Поиск минимального значения" +
                "\n 6. Поиск максимального значения");

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
                            Console.WriteLine("Сортировка - выполнена");
                            Sort();
                            break;
                        }
                    case "3":       //Обратная сортировка массива
                        {
                            Console.WriteLine("Обратная сортировка - выполнена");
                            ReverseSort();
                            break;
                        }
                    case "4":       //Создание нового ЧЕТНОГО массива и его вывод
                        {
                            Console.WriteLine("Создание нового четного массива - выполнено :");
                            XOR2();
                            break;
                        }
                    case "5":       //Поиск минимального значения
                        {
                            Console.WriteLine("Поиск минимального значения - выполнено :");
                            Min();
                            break;
                        }
                    case "6":       //Поиск максимального значения
                        {
                            Console.WriteLine("Поиск максимального значения - выполнено :");
                            Max();
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
        public void OutPut()
        {
            foreach (int x in array)
                Console.Write(x + " ");
        }
        public void Sort()
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
        public void ReverseSort()
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
        public void XOR2()
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
        public void Max()
        {
            int max = array[0];

            for (int i = 0; i < array.Length - 1; i++)
                if (max < array[i])
                    max = array[i];

            Console.WriteLine("Индекс: " + Array.IndexOf(array, max) + " Значение: " + max);
        }
        public void Min()
        {
            int min = array[0];

            for (int i = 0; i < array.Length - 1; i++)
                if (min > array[i])
                    min = array[i];

            Console.WriteLine("Индекс: " + Array.IndexOf(array, min) + " Значение: " + min);
        }
    }
    class FunctionsDM
    {
        int[,] array;
        public FunctionsDM(int[][] array)
        {
            this.array = new int[array.Length, array[0].Length];

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[0].Length; j++)
                    this.array[i, j] = array[i][j];

            Menu();
        }
        public void Menu()
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine(" 1. Вывести массив. " +
                "\n 2. Поиск минимального значения" +
                "\n 3. Поиск максимального значения");

            string input = "";

            while (input != "stop")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            OutPut();
                            break;
                        }
                    case "2":
                        {
                            Min();
                            break;
                        }
                    case "3":
                        {
                            Max();
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
        public void OutPut()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }
        }
        public void Max()
        {
            int r = 0;
            int c = 0;

            int max = array[0,0];

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

            Console.WriteLine($"Индекс {r} {c} Значение: {max}");
        }
        public void Min()
        {
            int r = 0;
            int c = 0;

            int min = array[0,0];

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
    class FunctionsSM
    {
        int[][] array;

        public FunctionsSM(int[][] array)
        {
            this.array = array;
            Menu();
        }

        public void Menu()
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine(" 1. Вывести массив. " +
                "\n 2. Поиск минимального значения" +
                "\n 3. Поиск максимального значения");

            string input = "";

            while (input != "stop")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Output();
                            break;
                        }
                    //case "2":
                    //    {
                    //        Min();
                    //        break;
                    //    }
                    //case "3":
                    //    {
                    //        Max();
                    //        break;
                    //    }
                }
            }
        }

        public void Output()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}
////////////////////////////////////////////////////////

//static void KeyboardParse(string input)
//{
//    public static string[] VvodArray()
//    {
//        string[] arr = new string[1];
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] != null)
//            {
//                Array.Resize(ref arr, arr.Length + 1);
//                arr[i] = Console.ReadLine();    // вводимое число
//            }
//            else
//                break;
//        }
//        return arr;
//    }

//    Console.WriteLine("Введите массив :");
//    string[] arr = VvodSKlav.VvodArray();

//    for (int i = 0; i < arr.Length; i++)
//        Console.WriteLine(arr[i]);
//}

/////////////////////////////////////////////////////

//class Functions
//{
//    public static void VivodArray(string[] arr)
//    {
//        foreach(var elofrow in arr)
//        {
//            foreach(var el in elofrow)
//            {
//                Console.WriteLine(arr[el]);
//            }
//        }
//    }
//    public static void VivodMax(string[] arr)
//    {
//        int max = 0;
//        foreach (var elofrow in arr)
//        {
//            foreach (var el in elofrow)
//            {
//                if (el > max)
//                    max = el;
//                else
//                    el++;

//            }
//        }
//        foreach (var elofrow in arr)
//        {
//            foreach (var el in elofrow)
//            {
//                Console.Write(el + " ");
//            }
//            Console.WriteLine();
//        }
//        Console.ReadKey();
//    }
//    public static void VivodMin(arr)
//    {
//        int min = 0;
//        foreach (var elofrow in arr)
//        {
//            foreach (var el in elofrow)
//            {
//                if (el < max)
//                    min = el;
//                else
//                    el++;

//            }
//        }
//        foreach (var elofrow in arr)
//        {
//            foreach (var el in elofrow)
//            {
//                Console.Write(el + " ");
//            }
//            Console.WriteLine();
//        }
//        Console.ReadKey();
//    }
//    public static void PSort