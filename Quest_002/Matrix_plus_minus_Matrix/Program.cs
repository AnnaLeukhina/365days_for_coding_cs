using System;


//
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

namespace Matrix_plus_minus_Matrix
{
    class Program
    {
        static void Main()
        {


            Random random = new Random();                            //для автоматического заполнения матриц

            #region Матрица №1 
            Console.WriteLine("Введите кол-во строк в матрице №1: ");
            int lines_1 = Convert.ToInt32(Console.ReadLine());         //запрашиваем кол-во строк для матрицы №1

            Console.WriteLine("Введите кол-во столбцов в матрице №1: ");
            int columns_1 = Convert.ToInt32(Console.ReadLine());       //запрашиваем кол-во столбцов для матрицы №1

            Console.WriteLine("Матрица №1: ");
            int[,] matrix_1 = new int[lines_1, columns_1];
            for (int i = 0; i < lines_1; i++)
            {
                for (int j = 0; j < columns_1; j++)
                {
                    matrix_1[i, j] = random.Next(0, 11);                //заполняем матрицу №1
                    Console.Write($"{matrix_1[i, j],3} ");              //выводим матрицу №1
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            #endregion

            #region Матрица №2
            Console.WriteLine("Введите кол-во строк в матрице №2: ");
            int lines_2 = Convert.ToInt32(Console.ReadLine());         //запрашиваем кол-во строк для матрицы №2

            Console.WriteLine("Введите кол-во столбцов в матрице №2: ");
            int columns_2 = Convert.ToInt32(Console.ReadLine());       //запрашиваем кол-во столбцов для матрицы №2

            Console.WriteLine("Матрица №2: ");
            int[,] matrix_2 = new int[lines_2, columns_2];
            for (int i = 0; i < lines_2; i++)
            {
                for (int j = 0; j < columns_2; j++)
                {
                    matrix_2[i, j] = random.Next(0, 11);                //заполняем матрицу №2
                    Console.Write($"{matrix_2[i, j],3} ");              //выводим матрицу №2
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            #endregion

            #region Сложение матриц
            if (lines_1 == lines_2 && columns_1 == columns_2)
            {
                int[,] matrix_plus = new int[lines_1, columns_1];
                Console.WriteLine("Матрица №1 + Матрица №2: ");
                for (int i = 0; i < lines_1; i++)
                {
                    for (int j = 0; j < columns_1; j++)
                    {
                        matrix_plus[i, j] = matrix_1[i, j] + matrix_2[i, j];                   //складываем поэлементно матрицу №1 и матрицу №2
                        Console.Write($"{matrix_plus[i, j],3} ");              //выводим матрицу
                    }
                    Console.WriteLine();
                }

            }
            else Console.WriteLine("Не выполнено условие для сложения и вычитания матриц. \nКол-во строк и столбцов матрицы №1 не совпадает с кол-вом строк и столбцов матрицы №2.");
            #endregion

            #region Вычитание матриц
            if (lines_1 == lines_2 && columns_1 == columns_2)
            {
                int[,] matrix_minus = new int[lines_1, columns_1];
                Console.WriteLine("Матрица №1 - Матрица №2: ");
                for (int i = 0; i < lines_1; i++)
                {
                    for (int j = 0; j < columns_1; j++)
                    {
                        matrix_minus[i, j] = matrix_1[i, j] - matrix_2[i, j];                   //вычитаем поэлементно матрицу №1 и матрицу №2
                        Console.Write($"{matrix_minus[i, j],3} ");              //выводим матрицу
                    }
                    Console.WriteLine();
                }

            }
            else Console.WriteLine("Не выполнено условие для вычитания матриц. \nКол-во строк и столбцов матрицы №1 не совпадает с кол-вом строк и столбцов матрицы №2.");
            #endregion

            Console.ReadKey();
        }
    }
}
