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

namespace Matrix_x_Number_edit
{
    class Program
    {
        static void Main()
        {
            //для получения псевдослучайного числа
            Random random = new Random();


            //создание матрицы с проверкой условий ввода
            Console.Write("Введите кол-во строк в матрице (<= 100): ");
            byte lines;
            do
            {
                Byte.TryParse(Console.ReadLine(), out lines);
            } while (lines < 1 || lines > 100);

            Console.Write("Введите кол-во столбцов в матрице (<= 100): ");
            byte columns;
            do
            {
                Byte.TryParse(Console.ReadLine(), out columns);
            } while (columns < 1 || columns > 100);



            //ввод числа для умножения матрицы
            Console.Write("Введите целое число, на которое вы хотите умножить матрицу (<= 1000): ");
            int number;
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
            } while (number < 1 || number > 1000);
            Console.WriteLine();


            //получение положения курсора и вспомогательныx переменных
            int need_BufferWidth = number.ToString().Length + columns * (number.ToString().Length + 7);
            if (Console.BufferWidth < need_BufferWidth) { Console.BufferWidth = need_BufferWidth; }
            int up = Console.CursorTop;
            int left = Console.CursorLeft;
            int up_center;
            int up_update;
            int left_update;
            int matrix_space = 0;


            //вывод числа, отцентрированно высоты матрицы
            up_center = up + lines / 2;
            Console.SetCursorPosition(left, up_center);
            Console.Write(number);
            left += number.ToString().Length + 2;


            //вывод знака "Х", отцентрированно высоты матрицы
            Console.SetCursorPosition(left, up_center);
            Console.Write('X');
            left += 3;


            //вывод первоначальной матрицы
            int[,] matrix = new int[lines, columns];
            for (int i = 0; i < lines; i++)
            {
                left_update = left;
                up_update = up + i;
                for (int j = 0; j < columns; j++)
                {
                    Console.SetCursorPosition(left_update, up_update);
                    matrix[i, j] = random.Next(0, 11);
                    Console.Write($"{matrix[i, j]} ");
                    left_update += 3;
                    if ((matrix[i, j] * number).ToString().Length > matrix_space) { matrix_space = (matrix[i, j] * number).ToString().Length; }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            left += columns * 3 + 1;


            //вывод знака "=", отцентрированно высоты матрицы
            Console.SetCursorPosition(left, up_center);
            Console.Write('=');
            left += 3;


            //вывод перемноженной матрицы
            for (int i = 0; i < lines; i++)
            {
                left_update = left;
                up_update = up + i;
                for (int j = 0; j < columns; j++)
                {
                    Console.SetCursorPosition(left_update, up_update);
                    matrix[i, j] *= number;
                    Console.Write($"{matrix[i, j],3} ");
                    left_update += matrix_space + 1;
                }
                Console.WriteLine();
            }


            //задержка консоли
            Console.ReadKey();
        }
    }
}
