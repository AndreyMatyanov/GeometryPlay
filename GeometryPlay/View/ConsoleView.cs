using GeometryPlay.Models;
using GeometryPlay.View.Interface;
using System;

namespace GeometryPlay.View
{
    class ConsoleView : IView
    {
        public void NotificationEnteringCoorditaneOfStepHight()
        {
            Console.WriteLine("Введите координату по высоте:");
        }

        public void NotificationEnteringCoorditaneOfStepWidth()
        {
            Console.WriteLine("Введите координату по ширине:");
        }

        public void NotificationEnteringCountOfSteps(int minCountOfSteps)
        {
            Console.WriteLine($"Введите количество ходов для одного игрока. Минимальное количество для данного поля - {minCountOfSteps}");
        }

        public void NotificationEnteringFieldHeight()
        {
            Console.WriteLine("Введите высоту поля:");
        }

        public void NotificationEnteringFieldHWidth()
        {
            Console.WriteLine("Введите ширину поля:");
        }

        public void NotificationEnteringFirstPlayerNickname()
        {
            Console.Clear();
            Console.WriteLine("Введите nickname игрока 1:");
        }

        public void NotificationEnteringSecondPlayerNickname()
        {
            Console.Clear();
            Console.WriteLine("Введите nickname игрока 2:");
        }

        public void NotificationEnterintCoordinateOfStepWidth()
        {
            Console.WriteLine("Введите координату по ширине:");
        }

        public void NotificationEnterintCoordinateOfStepHeight()
        {
            Console.WriteLine("Введите координату по высоте:");
        }

        public void SayHello()
        {
            Console.WriteLine("\t\tДобро пожаловать в игру GEOMETRY.\n\n" +
                "Игра предназначена для игры вдвоём\n\n" +
                "Нажмите любую клавишу, чтобы продолжить.\n\n");
            Console.ReadKey();
        }

        public void ShowErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowField(char[][] field)
        {
            Console.Write(" \t   ");
            for (int i = 0; i < field[0].Length; i++)
            {
                Console.Write($"{i + 1}   ");
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < field.Length; i++)
            {
                Console.Write($"{i + 1}\t");
                for (var j = 0; j < field[0].Length; j++)
                {
                    if (j > 9)
                    {
                        Console.Write("    " + field[i][j]);
                    }
                    else
                    {
                        Console.Write("   " + field[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public void ShowPlayerTurn(string name)
        {
            Console.WriteLine($"Ход игрока {name}");
        }

        public void ShowRoll(int height, int width)
        {
            Console.WriteLine("Итоги броска кубика.");
            Console.WriteLine($"Высота: {width}. Ширина: {height}");
        }

        public void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила игры:\n" +
                "Минимальный размер: 20 на 30.\n" +
                "Минимальное количество ходов зависит от размера поля.");
            Console.ReadKey();
        }

        public void NotificationNoPlace(bool isRerolled)
        {
            if (!isRerolled)
            {
                Console.WriteLine("Места не хватает. Производится перебросок кубика.\n" +
                    "Нажмите любую кнопку для повторного броска.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Не повезло. Места нет. Пропуск хода!");
            }
        }

        public void ShowWinner(string name)
        {
            Console.WriteLine($"Победитель: {name}");
        }

        public void ShowRecord(Player playerOne, Player playerTwo)
        {
            Console.Clear();
            Console.WriteLine($"Площадь фигур игрока {playerOne.Nickname}: {playerOne.Record}");
            Console.WriteLine($"Площадь фигур игрока {playerTwo.Nickname}: {playerTwo.Record}");
        }

        public void ShowDeadHeat()
        {
            Console.WriteLine("Вышла ничья.");
        }

        public void NotificationRestartGame()
        {
            Console.WriteLine("Игра завершена. Играть снова?\n"
                + "1. Да.\n"
                + "2. Нет");
        }

        public void NotificationMadeStep()
        {
            Console.WriteLine("Ход сделан.");
        }

        public void NotificationNoPlace()
        {
            Console.WriteLine("Место на поле закончилось.");
        }
    }
}
