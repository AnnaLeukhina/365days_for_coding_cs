using System;

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

namespace Matrix_x_Matrix_edit
{
    class Program
    {
        static void Main()
        {

            //генерацция псевдослучайного числа
            Random random = new Random();


            //получение данных для матрицы A
            Console.Write("Введите кол-во строк в матрице A (<= 100): ");
            byte lines_A;
            do
            {
                Byte.TryParse(Console.ReadLine(), out lines_A);
            } while (lines_A < 1 || lines_A > 100);

            Console.Write("Введите кол-во столбцов в матрице A (<= 100): ");
            byte columns_A;
            do
            {
                Byte.TryParse(Console.ReadLine(), out columns_A);
            } while (columns_A < 1 || columns_A > 100);

            Console.WriteLine();


            //получение данных для матрицы B
            Console.Write("Введите кол-во строк в матрице B (<= 100): ");
            byte lines_B;
            do
            {
                Byte.TryParse(Console.ReadLine(), out lines_B);
            } while (lines_B < 1 || lines_B > 100);

            Console.Write("Введите кол-во столбцов в матрице B (<= 100): ");
            byte columns_B;
            do
            {
                Byte.TryParse(Console.ReadLine(), out columns_B);
            } while (columns_B < 1 || columns_B > 100);

            Console.WriteLine();


            //проверка на создание матриц A и B
            if (columns_A != lines_B && columns_B != lines_A)
            {
                Console.WriteLine("Не выполнено условие для умножения матриц." +
                    "\nКол-во столбцов матрицы A не совпадает с кол-вом строк матрицы B." +
                    "\nКол-во столбцов матрицы B не совпадает с кол-вом строк матрицы A.");
            }
            else
            {
                //заполнение матриц A
                int[,] matrix_A = new int[lines_A, columns_A];
                for (int i = 0; i < lines_A; i++)
                {
                    for (int j = 0; j < columns_A; j++)
                    {
                        matrix_A[i, j] = random.Next(0, 11);
                    }
                }

                //заполнение матриц B
                int[,] matrix_B = new int[lines_B, columns_B];
                for (int i = 0; i < lines_B; i++)
                {
                    for (int j = 0; j < columns_B; j++)
                    {
                        matrix_B[i, j] = random.Next(0, 11);
                    }
                }


                //получение положения курсора и вспомогательныx переменных
                int need_BufferWidth = Math.Max(columns_A, columns_B) * (8 + Math.Max(columns_A, columns_B) / 10);
                if (Console.BufferWidth < need_BufferWidth) { Console.BufferWidth = need_BufferWidth; }
                int up = Console.CursorTop;
                int left = Console.CursorLeft;
                int up_center_matrix;
                int up_center_sign;
                int up_update;
                int left_update;


                //проверка на возможность перемножения AB
                if (columns_A != lines_B)
                {
                    Console.WriteLine("Не выполнено условие для умножения матриц." +
                    "\nКол-во столбцов матрицы A не совпадает с кол-вом строк матрицы B.");

                    up += 4;
                    Console.SetCursorPosition(left, up);
                }
                else
                {
                    up_center_matrix = up + (Math.Max(lines_B, lines_A) - Math.Min(lines_B, lines_A)) / 2;
                    up_center_sign = up + Math.Max(lines_B, lines_A) / 2;


                    //вывод матрицы A
                    for (int i = 0; i < lines_A; i++)
                    {
                        left_update = left;
                        if (lines_A == Math.Max(lines_B, lines_A)) { up_update = up + i; }
                        else { up_update = up_center_matrix + i; }

                        for (int j = 0; j < columns_A; j++)
                        {
                            Console.SetCursorPosition(left_update, up_update);
                            Console.Write($"{matrix_A[i, j]} ");

                            left_update += 3;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    left += columns_A * 3 + 1;


                    //вывод знака "Х"
                    Console.SetCursorPosition(left, up_center_sign);
                    Console.Write('X');
                    left += 3;


                    //вывод матрицы B
                    for (int i = 0; i < lines_B; i++)
                    {
                        left_update = left;
                        if (lines_B == Math.Max(lines_B, lines_A)) { up_update = up + i; }
                        else { up_update = up_center_matrix + i; }

                        for (int j = 0; j < columns_B; j++)
                        {
                            Console.SetCursorPosition(left_update, up_update);
                            Console.Write($"{matrix_B[i, j]} ");

                            left_update += 3;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    left += columns_B * 3 + 1;


                    //вывод знака "="
                    Console.SetCursorPosition(left, up_center_sign);
                    Console.Write('=');
                    left += 3;


                    //вывод матрицы AB
                    int[,] matrix_AB = new int[lines_A, columns_B];
                    for (int i = 0; i < lines_A; i++)
                    {
                        left_update = left;
                        if (lines_A == Math.Max(lines_B, lines_A)) { up_update = up + i; }
                        else { up_update = up_center_matrix + i; }

                        for (int j = 0; j < columns_B; j++)
                        {
                            for (int k = 0; k < lines_B; k++)
                            {
                                matrix_AB[i, j] = matrix_A[i, k] + matrix_B[k, j];
                            }
                            Console.SetCursorPosition(left_update, up_update);
                            Console.Write($"{ matrix_AB[i, j] } ");

                            left_update += 4;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    left += columns_A * 3 + 1;


                    //отступ для вывода следующего блока
                    left = 0;
                    up += Math.Max(lines_B, lines_A) + 2;
                    Console.SetCursorPosition(left, up);
                }



                //проверка на возможность перемножения BA
                if (columns_B != lines_A)
                {
                    Console.WriteLine("Не выполнено условие для умножения матриц." +
                    "\nКол-во столбцов матрицы B не совпадает с кол-вом строк матрицы A.");
                }
                else
                {
                    up_center_matrix = up + (Math.Max(lines_B, lines_A) - Math.Min(lines_B, lines_A)) / 2;
                    up_center_sign = up + Math.Max(lines_B, lines_A) / 2;


                    //вывод матрицы B
                    for (int i = 0; i < lines_B; i++)
                    {
                        left_update = left;
                        if (lines_B == Math.Max(lines_B, lines_A)) { up_update = up + i; }
                        else { up_update = up_center_matrix + i; }

                        for (int j = 0; j < columns_B; j++)
                        {
                            Console.SetCursorPosition(left_update, up_update);
                            Console.Write($"{matrix_B[i, j]} ");

                            left_update += 3;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    left += columns_B * 3 + 1;


                    //вывод знака "Х"
                    Console.SetCursorPosition(left, up_center_sign);
                    Console.Write('X');
                    left += 3;


                    //вывод матрицы A
                    for (int i = 0; i < lines_A; i++)
                    {
                        left_update = left;
                        if (lines_A == Math.Max(lines_B, lines_A)) { up_update = up + i; }
                        else { up_update = up_center_matrix + i; }

                        for (int j = 0; j < columns_A; j++)
                        {
                            Console.SetCursorPosition(left_update, up_update);
                            Console.Write($"{matrix_A[i, j]} ");

                            left_update += 3;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    left += columns_A * 3 + 1;

                    //вывод знака "="
                    Console.SetCursorPosition(left, up_center_sign);
                    Console.Write('=');
                    left += 3;


                    //вывод матрицы BA
                    int[,] matrix_BA = new int[lines_B, columns_A];
                    for (int i = 0; i < lines_B; i++)
                    {
                        left_update = left;
                        if (lines_B == Math.Max(lines_B, lines_A)) { up_update = up + i; }
                        else { up_update = up_center_matrix + i; }

                        for (int j = 0; j < columns_A; j++)
                        {
                            for (int k = 0; k < lines_A; k++)
                            {
                                matrix_BA[i, j] = matrix_B[i, k] + matrix_A[k, j];
                            }
                            Console.SetCursorPosition(left_update, up_update);
                            Console.Write($"{ matrix_BA[i, j] } ");

                            left_update += 4;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    left += columns_A * 3 + 1;
                }
            }

            //задержка консоли
            Console.ReadKey();
        }
    }
}
