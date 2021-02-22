using System;

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

namespace Triangle_of_Pascal_edit
{
    class Program
    {
        static void Main()
        {
            //переменные для проверки ввода-вывода
            bool error;
            int up = 1;

            //запрос кол-ва строк у пользователя и проверка на неправильный ввод
            byte lines_count;
            Console.Write("Введите кол-во строк в треугольнике Паскаля (менее 25): ");
            do
            {
                error = Byte.TryParse(Console.ReadLine(), out lines_count);
                if (!error || lines_count < 1 || lines_count >= 25) { Console.Write("Некорректный ввод. Повторите: "); }
                up += 1;
            } while (lines_count < 1 || lines_count >= 25);

            //создание пирамиды + заполнение краев пирамиды
            //
            int[][] triangle = new int[lines_count][];
            for (int i = 0; i < triangle.Length; i++)
            {
                triangle[i] = new int[i + 1];
                triangle[i][0] = 1;
                triangle[i][i] = 1;
            }


            //заполнение пирамиды
            //
            for (int i = 2; i < triangle.Length; i++)
            {
                for (int j = 1; j < triangle[i].Length - 1; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }


            //вывод результата с последней строки
            //
            for (int i = triangle.Length - 1; i >= 0; i--)
            {
                string pyramid = string.Empty;
                for (int j = 0; j < Triangle[i].Length; j++)
                {
                    pyramid += $"{Triangle[i][j],10}";
                }
                //установить ширину окна консоли по ширине последней строки, если нужно
                //
                if (Console.BufferWidth < pyramid.Length) { Console.BufferWidth = pyramid.Length; }

                //обозначить центр для отцентрованного вывода
                //
                int center = Console.BufferWidth / 2;
                int left = center - pyramid.Length / 2;
                Console.SetCursorPosition(left, up + i + 2);
                Console.Write(pyramid);
            }


            Console.ReadKey();
        }
    }
}
