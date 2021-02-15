using System;

namespace BotVSPlayer
{
    class Program
    {
        static void Main()
        {

            while (true) //Для повторного запуска игры без перезапуска программы
            {
                Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ! " +
                    "\nИгра рассчитана на 1 игрока. Ниже введи своё имя.");

                // При старте игры игрокам предлагается ввести свои никнеймы.
                Console.Write("Введи имя игрока: ");
                string Player = Console.ReadLine();


                Console.WriteLine("\nПРАВИЛА: выпадает случайное число от 12 до 120." +
                    "\nУ тебя есть право за ход вычитать из числа значения от 1 до 4. У бота, с которым ты играешь, тоже." +
                    "\nПервый получивший 0 в конце своего хода выигрывает." +
                    "\nУДАЧИ!");

                // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
                Random randomize = new Random();
                int gameNumber = randomize.Next(12, 121);
                Console.WriteLine($"\nВыпавшее число: {gameNumber}");

                byte userTry;
                byte userPlay; //Переменная для хода игрока
                if (gameNumber % 5 == 0) userPlay = 2; //для случая, чтобы у бота не было первоначально выигрышной позиции
                else userPlay = 1; //для случая, чтобы у игрока не было первоначально выигрышной позиции

                while (gameNumber > 0)
                {
                    switch (userPlay)  //Выбор хода игрока
                    {
                        case 1:
                            Console.Write($"\nХод игрока {Player}");   //Сообщается, который игрок ходит
                            do
                            {
                                Console.Write($"\n{Player}, введите число от 1 до 4, не превышающее оставшееся знаение выпавшего числа: ");
                                userTry = Convert.ToByte(Console.ReadLine());
                            } while (userTry > 4 || gameNumber - userTry < 0);   //если набранное число не удовлетворяет правилам игры, число запрашивается повторно
                            gameNumber -= userTry;                                           // введенное число вычитается из gameNumber
                            Console.WriteLine($"Значение числа после хода: {gameNumber}");   // Новое значение gameNumber показывается игрокам на экране.
                            if (gameNumber > 0) userPlay = 2;                                // Смена хода игрока
                            break;

                        case 2:
                            Console.Write($"\nХод бота.");   //Сообщается, что ходит бот

                            if (gameNumber % 5 == 0) userTry = Convert.ToByte(randomize.Next(1, 5));
                            else
                            {
                                userTry = Convert.ToByte(gameNumber % 5);
                            }
                            Console.WriteLine($"Выбранное число: {userTry}");
                            gameNumber -= userTry;                                           // введенное число вычитается из gameNumber
                            Console.WriteLine($"Значение числа после хода: {gameNumber}");   // Новое значение gameNumber показывается игрокам на экране.
                            if (gameNumber > 0) userPlay = 1;                                // Смена хода игрока
                            break;
                    }
                }

                switch (userPlay) //Поздравление победителя
                {
                    case 1:
                        Console.WriteLine($"Поздравляю с победой, {Player}");
                        break;
                    case 2:
                        Console.WriteLine($"Прости, но выиграл бот.");
                        break;
                }

                Console.WriteLine("\nИгра закончилась. Хочешь сыграть еще раз?" +
                    "\n1. Закрыть программу" +
                    "\n2. Хочу реванш");     // Игра предлагает сыграть реванш
                byte gameChoice = Convert.ToByte(Console.ReadLine());
                if (gameChoice == 1) break;
            }
        }
    }
}