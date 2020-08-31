using System;

namespace HelloWorld
{
    class Game
    {
        private bool _endGame = false;
        private bool _playerIsSetup = false;

        private string _gameState = "Main Menu";
        private Player _player;

        //Run the game
        public void Run()
        {
            Start();
            while(!_endGame)
                Update();
            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            Console.SetWindowSize(100, 30);
        }

        //Repeated until the game ends
        public void Update()
        {
            if (_gameState == "Main Menu")
            {
                DisplayMainMenu();
            }
            else if (_gameState == "Setup")
            {
                DoSetup();
            }
            else if (_gameState == "Game")
            {
                Console.WriteLine("Long exposition about " + _player.name + " the " + _player.combatClass + " in which their many triumphs and shortcomings are described in gory detail...");
                Console.WriteLine("Describe the setting, giving specific detail to the most irrelevant parts of the scene...");

            }
        }

        //Performed once when the game ends
        public void End()
        {
            // Save Game automatically here
        }

        private void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine(@"
 ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗     
 ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗    
 ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║    
 ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║    
 ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝    
  ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝  
 
  ██░ ██ ▓█████  ██▓     ██▓     ▒█████      █     █░ ▒█████   ██▀███   ██▓    ▓█████▄ 
 ▓██░ ██▒▓█   ▀ ▓██▒    ▓██▒    ▒██▒  ██▒   ▓█░ █ ░█░▒██▒  ██▒▓██ ▒ ██▒▓██▒    ▒██▀ ██▌
 ▒██▀▀██░▒███   ▒██░    ▒██░    ▒██░  ██▒   ▒█░ █ ░█ ▒██░  ██▒▓██ ░▄█ ▒▒██░    ░██   █▌
 ░▓█ ░██ ▒▓█  ▄ ▒██░    ▒██░    ▒██   ██░   ░█░ █ ░█ ▒██   ██░▒██▀▀█▄  ▒██░    ░▓█▄   ▌
 ░▓█▒░██▓░▒████▒░██████▒░██████▒░ ████▓▒░   ░░██▒██▓ ░ ████▓▒░░██▓ ▒██▒░██████▒░▒████▓ 
  ▒ ░░▒░▒░░ ▒░ ░░ ▒░▓  ░░ ▒░▓  ░░ ▒░▒░▒░    ░ ▓░▒ ▒  ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░ ▒░▓  ░ ▒▒▓  ▒ 
  ▒ ░▒░ ░ ░ ░  ░░ ░ ▒  ░░ ░ ▒  ░  ░ ▒ ▒░      ▒ ░ ░    ░ ▒ ▒░   ░▒ ░ ▒░░ ░ ▒  ░ ░ ▒  ▒ 
  ░  ░░ ░   ░     ░ ░     ░ ░   ░ ░ ░ ▒       ░   ░  ░ ░ ░ ▒    ░░   ░   ░ ░    ░ ░  ░ 
  ░  ░  ░   ░  ░    ░  ░    ░  ░    ░ ░         ░        ░ ░     ░         ░  ░   ░    
                                                                                ░    
             ");

            PressAnyKeyToContinue();
            if (_playerIsSetup)
                _gameState = "Game";
            else
                _gameState = "Setup";
            Console.ReadKey();
        }
        
        private void DoSetup()
        {
            // Setup player
            Console.Clear();
            Console.WriteLine(@"
███████╗███████╗████████╗██╗   ██╗██████╗ 
██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗
███████╗█████╗     ██║   ██║   ██║██████╔╝
╚════██║██╔══╝     ██║   ██║   ██║██╔═══╝ 
███████║███████╗   ██║   ╚██████╔╝██║     
╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝     
                 ");

            Console.WriteLine("Name:");
            Console.Write(">");
            string name = Console.ReadLine();

            Console.WriteLine("Please choose a combat class:");
            Console.WriteLine("[1] Knight");
            Console.WriteLine("[2] Wizard");
            Console.Write(">");
            string[] validInputs = { "1", "2" };
            string input = GetStringInput(validInputs);
            float maxHealth = 0;
            float damage = 0;
            string combatClass = "none";

            if (input == "1")
            {
                combatClass = "Knight";
                maxHealth = 200;
                damage = 10;
            }
            else if (input == "2")
            {
                combatClass = "Wizard";
                maxHealth = 100;
                damage = 25;
            }

            _player = new Player(maxHealth, maxHealth, damage, 1, name, combatClass);
            _playerIsSetup = true;

            Console.WriteLine();
            _player.PrintStats();
            _gameState = "Game";
            Console.WriteLine();
            PressAnyKeyToContinue();
        }

        // Auto loops for correct input
        public string GetStringInput(string[] validInputs)
        {
            while(true)
            {
                string input = Console.ReadLine();
                foreach (string item in validInputs)
                {
                    if (input == item)
                    {
                        return input;
                    }
                }
                Console.WriteLine("Input not recognized.");
                Console.Write(">");
            }
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
