using System;

namespace PlayerVSPlayer
{
    class Program
    {
        static void Main()
        {

            while (true) //Для повторного запуска игры без перезапуска программы
            {
                Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ! " +
                    "\nИгра рассчитана на 2-х игроков. Ниже введите ваши имена.");

                // При старте игры игрокам предлагается ввести свои никнеймы.
                Console.Write("Введите имя игрока №1: ");
                string Player_1 = Console.ReadLine();
                Console.Write("Введите имя игрока №2: ");
                string Player_2 = Console.ReadLine();

                Console.WriteLine("\nПРАВИЛА: выпадает случайное число от 12 до 120." +
                    "\nУ игроков есть право за ход вычитать из числа значения от 1 до 4" +
                    "\nИгрок, получивший 0 в конце воего хода, выигрывает." +
                    "\nУДАЧИ!");

                // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
                Random randomize = new Random();
                int gameNumber = randomize.Next(12, 121);
                Console.WriteLine($"\nВыпавшее число: {gameNumber}");

                byte userTry;
                byte userPlay = Convert.ToByte(randomize.Next(1, 3)); //Переменная для хода игрока
                while (gameNumber > 0)
                {
                    switch (userPlay)  //Выбор хода игрока
                    {
                        case 1:
                            Console.Write($"\nХод игрока {Player_1}");   //Сообщается, который игрок ходит
                            do
                            {
                                Console.Write($"\n{Player_1}, введите число от 1 до 4, не превышающее оставшееся знаение выпавшего числа:");
                                userTry = Convert.ToByte(Console.ReadLine());
                            } while (userTry < 1 || userTry > 4 || gameNumber - userTry < 0);   //если набранное число не удовлетворяет правилам игры, число запрашивается повторно
                            gameNumber -= userTry;                                           // введенное число вычитается из gameNumber
                            Console.WriteLine($"Значение числа после хода: {gameNumber}");   // Новое значение gameNumber показывается игрокам на экране.
                            if (gameNumber > 0) userPlay = 2;                                // Смена хода игрока
                            break;

                        case 2:
                            Console.Write($"\nХод игрока {Player_2}");   //Сообщается, который игрок ходит
                            do
                            {
                                Console.Write($"\n{Player_2}, введите число от 1 до 4, не превышающее оставшееся знаение выпавшего числа:");
                                userTry = Convert.ToByte(Console.ReadLine());
                            } while (userTry < 1 || userTry > 4 || gameNumber - userTry < 0);   //если набранное число не удовлетворяет правилам игры, число запрашивается повторно
                            gameNumber -= userTry;                                           // введенное число вычитается из gameNumber
                            Console.WriteLine($"Значение числа после хода: {gameNumber}");   // Новое значение gameNumber показывается игрокам на экране.
                            if (gameNumber > 0) userPlay = 1;                                // Смена хода игрока
                            break;
                    }
                }

                switch (userPlay) //Поздравление победителя
                {
                    case 1:
                        Console.WriteLine($"\nПоздравляю с победой, {Player_1}");
                        break;
                    case 2:
                        Console.WriteLine($"\nПоздравляю с победой, {Player_2}");
                        break;
                }

                Console.WriteLine("\nИгра закончилась. Хотите сыграть еще раз?" +
                    "\n1. Закрыть программу" +
                    "\n2. Хочу реванш");     // Игра предлагает сыграть реванш
                byte gameChoice = Convert.ToByte(Console.ReadLine());
                if (gameChoice == 1) break;
            }
        }
    }
}
