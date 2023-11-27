using System;

class Program
{
    static void Main(string[] args)
    {
        string a = "1 2 3 4 5";
        string b = "6 7 8 9 10";

        // Вызываем метод и получаем максимальный элемент
        int maxElement = FindAndSwapMaxElements(ref a, ref b);

        // Вывод результатов
        Console.WriteLine("a: " + a);
        Console.WriteLine("b: " + b);
        Console.WriteLine("Max element: " + maxElement);
    }

    // Метод для поиска и обмена максимальных элементов в строках a и b
    static int FindAndSwapMaxElements(ref string a, ref string b)
    {
        // Находим максимальные элементы в каждой строке
        int maxA = FindMaxElement(a);
        int maxB = FindMaxElement(b);

        // Обмениваем элементы между строками, если максимальный элемент в строке a больше
        if (maxA > maxB)
        {
            SwapMaxElement(ref a, ref b, maxA);
            return maxA; // Возвращаем максимальный элемент
        }
        // Иначе обмениваем элементы в строке b
        else
        {
            SwapMaxElement(ref b, ref a, maxB);
            return maxB; // Возвращаем максимальный элемент
        }
    }

    // Метод для нахождения максимального элемента в строке
    static int FindMaxElement(string str)
    {
        string[] numbers = str.Split(' ');
        int max = int.MinValue;

        // Проходим по числам в строке и находим максимальный элемент
        foreach (string number in numbers)
        {
            if (int.TryParse(number, out int current))
            {
                if (current > max)
                {
                    max = current;
                }
            }
        }

        return max;
    }

    // Метод для обмена максимального элемента в исходной строке с соответствующим элементом в целевой строке
    static void SwapMaxElement(ref string source, ref string target, int max)
    {
        string[] sourceNumbers = source.Split(' ');
        string[] targetNumbers = target.Split(' ');

        // Проходим по числам в исходной строке и обмениваем максимальный элемент
        for (int i = 0; i < sourceNumbers.Length; i++)
        {
            if (int.TryParse(sourceNumbers[i], out int current) && current == max)
            {
                int temp = int.Parse(targetNumbers[i]);
                targetNumbers[i] = sourceNumbers[i];
                sourceNumbers[i] = temp.ToString();
                break;
            }
        }

        // Обновляем исходную и целевую строки после обмена
        source = string.Join(" ", sourceNumbers);
        target = string.Join(" ", targetNumbers);
    }
}