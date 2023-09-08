using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaderBoard
{
    internal class Program
    {
        static void Main()
        {
            Board board = new Board();
            ConsoleKey exitButton = ConsoleKey.Enter;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для начало работы нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
                board.CortPlayers();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Board
    {
        private List<Player> _players;

        public Board() 
        {
            _players = new List<Player>()
            {
                new Player("CoolChel ", 600,80),
                new Player( "Topor", 20,50),
                new Player( "Nepyt32", 35,75),
                new Player( "cqqda1",  233,20),
                new Player( "Tap", 5323,90),
                new Player( "TopChel", 10000,100),
                new Player( "Azetoy", 310,32),
                new Player( "Nicola", 270,85),
                new Player( "TamTam", 110,52),
                new Player( "ZetRash", 48,20),
            };
        }

        public void CortPlayers()
        {
            int numberTopPlayer = 3;
            Console.WriteLine("Топ игроков по уровню");
            var filterTopLevelPlayers = _players.OrderByDescending(patient => patient.Level).Take(numberTopPlayer);
            ShowInfo(filterTopLevelPlayers);
            Console.WriteLine("\nТоп игроков по силе");
            var filterTopPowerPlayers = _players.OrderByDescending(patient => patient.Power).Take(numberTopPlayer);
            ShowInfo(filterTopPowerPlayers);
        }

        private void ShowInfo(IEnumerable<Player> filteredPlayers)
        {
            foreach (var player in filteredPlayers)
            {
                Console.WriteLine($"Имя игрока {player.Name},Уровень - {player.Level},Сила - {player.Power}");
            }
        }
    }

    class Player
    {
        public Player(string name,int power, int level)
        {
            Name = name;
            Power = power;
            Level = level;
        } 

        public string Name { get; private set; }
        public int Power { get; private set; }
        public int Level { get; private set; }
    }
}
