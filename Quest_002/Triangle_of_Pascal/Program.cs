﻿using System;

// * Задание 2
// Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
// 
// При N = 8. Треугольник выглядит следующим образом:
//                                 1
//                             1       1
//                         1       2       1
//                     1       3       3       1
//                 1       4       6       4       1
//             1       5      10      10       5       1
//         1       6      15      20      15       6       1
//     1       7      21      35      35       21      7       1
//                                                              
//                                                              
// Простое решение:                                                             
// 1
// 1       1
// 1       2       1
// 1       3       3       1
// 1       4       6       4       1
// 1       5      10      10       5       1
// 1       6      15      20      15       6       1
// 1       7      21      35      35       21      7       1
// 
// Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля

namespace Triangle_of_Pascal
{
    class Program
    {
        static void Main()
        {
            #region запрос кол-ва строк у пользователя
            int N; //объявить переменную для ввода пользователя
            do
            {
                N = Convert.ToInt32(Console.ReadLine());      //считать переменную с консоли
            } while (N < 1 || N > 24);   //N целое неотрицательное число <25
            #endregion

            #region создание пирамиды + заполнение краев пирамиды
            int[][] triangle = new int[N][];                      //объявляем массив массивов с кол-вом вложенных циклов равным кол-ву нужных строк
            for (int i = 0; i < triangle.Length; i++)             //проходим по каждой строчке пирамиды
            {
                triangle[i] = new int[i + 1];                     //в зависимости от строки выделяем места для нужного кол-ва элементов
                triangle[i][0] = 1;                               //первый элемент строки равен 1
                triangle[i][i] = 1;                               //последний элемент строки равен 1
            }
            #endregion

            #region заполнение пирамиды

            for (int i = 2; i < triangle.Length; i++)      //проходим по каждой строчке пирамиды, начиная с 3-ей
            {
                for (int j = 1; j < triangle[i].Length-1; j++)         //проходим по элементам каждой строки, начиная со 2-ого и до предпоследнего элемента строки
                {
                    triangle[i][j] = triangle[i-1][j-1] + triangle[i-1][j];  //высчитываем сумму вышестоящих в пирамиде элементов
                }
            }
            #endregion

            #region вывод результата
            string pyramid;                                         //объявление строки, в которую будут записываться данные

            for (int i = 0; i < triangle.Length; i++)
            {
                pyramid = " ";                                      //очищение строки + начальный пробел для симметричности записи в начале каждой строки
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    pyramid += triangle[i][j].ToString();           //записываем в строку значение элемента
                    pyramid += " ";
                }

                int center = Console.WindowWidth / 2;              //находим центр консоли
                int left = center - pyramid.Length / 2;            //находим левый край, учитывая длину выводимой строки
                Console.SetCursorPosition(left,i+1);               //ставим курсор на нужное место
                Console.WriteLine(pyramid);                        //выводим строку
            }
            #endregion

            Console.ReadKey();
        }
    }
}
