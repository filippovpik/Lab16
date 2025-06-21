namespace Task16_1
{
    internal class Program
    {
        static int[] GenerateArray(int size)
        {
            Console.WriteLine("Генерация массива");
            var random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 10);
                Console.Write($"{array[i]}");
            }

            Thread.Sleep(1000);
            Console.WriteLine("\nМассив сгенерирован");
            return array;
        }

        static double CalculateArithmeticMean(int[] array)
        {
            //Вычисление среднего арифметического
            double sum = 0;
            double armean = 0;

            foreach (int num in array)
            {
                sum += num;
            }

            Thread.Sleep(1000);
            Console.WriteLine($"Сумма равна {sum}");
            Console.WriteLine("Среднее арифметическое:");

            return armean = sum / array.Length;
        }

        static async Task<int[]> GenerateArrayAsync()
        {
            Console.WriteLine("Метод GenerateArrayAsync запущен");
            int[] array = await Task.Run(() => GenerateArray(10));
            Console.WriteLine("Метод GenerateArrayAsync завершен");
            return array;
        }

        static async Task<double> CalculateArithmeticMeanAsync(int[] array)
        {
            Console.WriteLine("Метод CalculateArithmeticMeanAsync запущен");
            double result = await Task.Run(() => CalculateArithmeticMean(array));
            Console.WriteLine("Метод CalculateArithmeticMeanAsync завершен");
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main запущен");

            Console.WriteLine("Демонстрация задача продолжения");
            Task<int[]> task1 = Task.Run(() => GenerateArray(10));
            Task<double> task2 = task1.ContinueWith(t =>
            {
                int[] array = t.Result;
                return CalculateArithmeticMean(array);
            });
            Console.WriteLine(task2.Result);


            Console.WriteLine("Демонстрация async await");
            int[] arrayAsync = GenerateArrayAsync().Result;

            var r = CalculateArithmeticMeanAsync(arrayAsync).Result;
            Console.WriteLine(r);

            Console.WriteLine("Main завершен");
            Console.ReadKey();


        }
    }
}
