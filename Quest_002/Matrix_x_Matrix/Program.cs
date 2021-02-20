using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace Matrix_x_Matrix
{
    class Program
    {
        static void Main()
        {

            Random random = new Random();                            //для автоматического заполнения матриц

            #region Матрица A
            Console.WriteLine("Введите кол-во строк в матрице A: ");
            int lines_A = Convert.ToInt32(Console.ReadLine());         //запрашиваем кол-во строк для матрицы A

            Console.WriteLine("Введите кол-во столбцов в матрице A: ");
            int columns_A = Convert.ToInt32(Console.ReadLine());       //запрашиваем кол-во столбцов для матрицы A

            Console.WriteLine();
            Console.WriteLine("Матрица A: ");
            int[,] matrix_A = new int[lines_A, columns_A];
            for (int i = 0; i < lines_A; i++)
            {
                for (int j = 0; j < columns_A; j++)
                {
                    matrix_A[i, j] = random.Next(0, 11);                //заполняем матрицу A
                    Console.Write($"{matrix_A[i, j],3} ");              //выводим матрицу A
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Матрица B
            Console.WriteLine("Введите кол-во строк в матрице B: ");
            int lines_B = Convert.ToInt32(Console.ReadLine());         //запрашиваем кол-во строк для матрицы B

            Console.WriteLine("Введите кол-во столбцов в матрице B: ");
            int columns_B = Convert.ToInt32(Console.ReadLine());       //запрашиваем кол-во столбцов для матрицы B

            Console.WriteLine();
            Console.WriteLine("Матрица B: ");
            int[,] matrix_B = new int[lines_B, columns_B];
            for (int i = 0; i < lines_B; i++)
            {
                for (int j = 0; j < columns_B; j++)
                {
                    matrix_B[i, j] = random.Next(0, 11);                //заполняем матрицу B
                    Console.Write($"{matrix_B[i, j],3} ");              //выводим матрицу B
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 
            Console.WriteLine();
            Console.WriteLine("Матрица A * Матрица B: ");
            int[,] matrix_AB = new int[lines_A, columns_B];
            if (columns_A == lines_B)
            {
                for (int i = 0; i < lines_A; i++)
                {
                    for (int j = 0; j < columns_B; j++)
                    {
                        for (int k = 0; k < columns_A; k++)
                        {
                            matrix_AB[i, j] += matrix_A[i,k]* matrix_B[k, j];//по формуле умножения матриц
                        }
                        Console.Write($"{matrix_AB[i, j],3} ");              //выводим матрицу AB
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Не выполнено условие для умножения матриц. \nКол-во столбцов матрицы A не совпадает с кол-вом строк матрицы B.");
            #endregion

            #region Умножение матриц B*A
            Console.WriteLine();
            Console.WriteLine("Матрица B * Матрица A: ");
            int[,] matrix_BA = new int[lines_B, columns_A];
            if (lines_A == columns_B)
            {
                for (int i = 0; i < lines_B; i++)
                {
                    for (int j = 0; j < columns_A; j++)
                    {
                        for (int k = 0; k < lines_A; k++)
                        {
                            matrix_BA[i, j] += matrix_B[i, k] * matrix_A[k, j];   //по формуле умножения матриц
                        }
                        Console.Write($"{matrix_BA[i, j],3} ");              //выводим матрицу BA
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Не выполнено условие для умножения матриц. \nКол-во столбцов матрицы B не совпадает с кол-вом строк матрицы A.");
            #endregion
            
            Console.ReadKey();
        }
    }
}
