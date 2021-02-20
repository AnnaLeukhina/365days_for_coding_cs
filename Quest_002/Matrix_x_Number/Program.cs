using System;

// 
// * Задание 3.1
// Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
// Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
// Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
// Добавить возможность ввода количество строк и столцов матрицы и число,
// на которое будет производиться умножение.
// Матрицы заполняются автоматически. 
// Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
//
// Пример
//
//      |  1  3  5  |   |  5  15  25  |
//  5 х |  4  5  7  | = | 20  25  35  |
//      |  5  3  1  |   | 25  15   5  |
//

namespace Matrix_x_Number
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();                            //для автоматического заполнения матрицы

            Console.WriteLine("Введите кол-во строк в матрице: ");
            int lines = Convert.ToInt32(Console.ReadLine());         //запрашиваем кол-во строк для матрицы

            Console.WriteLine("Введите кол-во столбцов в матрице: ");
            int columns = Convert.ToInt32(Console.ReadLine());       //запрашиваем кол-во столбцов для матрицы

            Console.WriteLine("Первоначальная матрица: ");
            int[,] matrix = new int[lines,columns];
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(0,11);                //заполняем матрицу
                    Console.Write($"{matrix[i, j], 3} ");               //выводим первоначальную матрицу
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();

            Console.WriteLine("Введите целое число, на которое вы хотите умножить матрицу: ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Перемноженная матрица: ");
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] *= N;               //перемножаем поэлементно матрицу на число
                    Console.Write($"{matrix[i, j], 3} ");               //выводим первоначальную матрицу
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
