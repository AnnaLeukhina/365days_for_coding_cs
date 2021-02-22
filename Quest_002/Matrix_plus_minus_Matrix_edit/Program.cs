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

namespace Matrix_plus_minus_Matrix_edit
{
    class Program
    {
        static void Main()
        {
            //генерацция псевдослучайного числа
            Random random = new Random();

            //данные для создания матрицы №1 с проверкой условий ввода
            Console.Write("Введите кол-во строк в матрице №1 (<= 100): ");
            byte lines_1;
            do
            {
                Byte.TryParse(Console.ReadLine(), out lines_1);
            } while (lines_1 < 1 || lines_1 > 100);

            Console.Write("Введите кол-во столбцов в матрице №1 (<= 100): ");
            byte columns_1;
            do
            {
                Byte.TryParse(Console.ReadLine(), out columns_1);
            } while (columns_1 < 1 || columns_1 > 100);

            Console.WriteLine();


            //данные для создания матрицы №2
            Console.Write("Введите кол-во строк в матрице №2 (<= 100): ");
            byte lines_2;
            do
            {
                Byte.TryParse(Console.ReadLine(), out lines_2);
            } while (lines_2 < 1 || lines_2 > 100);

            Console.Write("Введите кол-во столбцов в матрице №2 (<= 100): ");
            byte columns_2;
            do
            {
                Byte.TryParse(Console.ReadLine(), out columns_2);
            } while (columns_2 < 1 || columns_2 > 100);

            Console.WriteLine();


            //проверка на возможность сложения/вычитания матриц
            if (lines_1 != lines_2 || columns_1 != columns_2)
            {
                Console.WriteLine("Невозможно сложить/вычесть матрицы." +
                    "\nКол-во строк и столбцов матрицы №1 не совпадает с кол-вом строк и столбцов матрицы №2.");
            }
            else
            {
                //получение положения курсора и вспомогательныx переменных
                int need_BufferWidth = columns_1 * 11;
                if (Console.BufferWidth < need_BufferWidth) { Console.BufferWidth = need_BufferWidth; }
                int up = Console.CursorTop;
                int left = Console.CursorLeft;
                int up_center = up + lines_1 / 2;
                int up_update;
                int left_update;



                //вывод матрицы №1 для "+" и "-"
                int[,] matrix_1 = new int[lines_1, columns_1];
                for (int i = 0; i < lines_1; i++)
                {
                    left_update = left;
                    up_update = up + i;
                    for (int j = 0; j < columns_1; j++)
                    {
                        matrix_1[i, j] = random.Next(0, 11);

                        Console.SetCursorPosition(left_update, up_update);
                        Console.Write($"{matrix_1[i, j]} ");

                        Console.SetCursorPosition(left_update, up_update + lines_1 + 1);
                        Console.Write($"{matrix_1[i, j]} ");

                        left_update += 3;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                left += columns_1 * 3 + 1;


                //вывод знака "+" и "-", отцентрированно высоты матрицы
                Console.SetCursorPosition(left, up_center);
                Console.Write('+');

                Console.SetCursorPosition(left, up_center + lines_1 + 1);
                Console.Write('-');

                left += 3;


                //вывод матрицы №2 для "+" и "-"
                int[,] matrix_2 = new int[lines_2, columns_2];
                for (int i = 0; i < lines_2; i++)
                {
                    left_update = left;
                    up_update = up + i;
                    for (int j = 0; j < columns_2; j++)
                    {
                        matrix_2[i, j] = random.Next(0, 11);

                        Console.SetCursorPosition(left_update, up_update);
                        Console.Write($"{matrix_2[i, j]} ");

                        Console.SetCursorPosition(left_update, up_update + lines_2 + 1);
                        Console.Write($"{matrix_2[i, j]} ");

                        left_update += 3;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                left += columns_2 * 3 + 1;


                //вывод знака "=", отцентрированно высоты матрицы
                Console.SetCursorPosition(left, up_center);
                Console.Write('=');

                Console.SetCursorPosition(left, up_center + lines_2 + 1);
                Console.Write('=');

                left += 3;


                //вывод матрицы сложения и вычитания
                int[,] matrix_plus = new int[lines_2, columns_2];
                int[,] matrix_minus = new int[lines_2, columns_2];
                for (int i = 0; i < lines_2; i++)
                {
                    left_update = left;
                    up_update = up + i;
                    for (int j = 0; j < columns_2; j++)
                    {
                        matrix_plus[i, j] = matrix_1[i, j] + matrix_2[i, j];
                        matrix_minus[i, j] = matrix_1[i, j] - matrix_2[i, j];

                        Console.SetCursorPosition(left_update, up_update);
                        Console.Write($"{matrix_plus[i, j]} ");

                        //красивый вывод для отрицательных чисел
                        if (matrix_minus[i, j] >= 0)
                        {
                            Console.SetCursorPosition(left_update + 1, up_update + lines_2 + 1);
                            Console.Write($"{matrix_minus[i, j]} ");
                        }
                        else
                        {
                            Console.SetCursorPosition(left_update, up_update + lines_2 + 1);
                            Console.Write($"{matrix_minus[i, j]} ");
                        }

                        left_update += 4;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            //задержка консоли
            Console.ReadKey();
        }
    }
}
