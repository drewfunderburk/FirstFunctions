using Microsoft.VisualBasic;
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
            Console.SetWindowSize(100, 50);
            
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
                Console.Clear();
                Console.WriteLine("Long exposition about " + _player.name + " the " + _player.combatClass + " in which their many triumphs and shortcomings are described in gory detail...");
                Console.WriteLine("Describe the setting, giving specific detail to the most irrelevant parts of the scene...");
                Console.WriteLine();
                OldManEncounter();

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

        #region HELPERS
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

        // Self explanatory
        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        #endregion

        void OldManEncounter()
        {
            Console.WriteLine("An old man steps out of the shadows before you and bars your path.");
            Console.WriteLine();
            Console.WriteLine("Old Man: \"Greetings, traveler!\" he says in a shrill voice, \"Whereabouts is the bathroom?\"");
            Console.WriteLine(" [1] \"Back in the trees old man.\"");
            Console.WriteLine(" [2] \"Fight be because this is a video game and logic is irrelevant.\"");
            Console.Write(">");
            string[] validInputs = { "1", "2" };
            string input = GetStringInput(validInputs);
            if (input == "1")
            {
                Console.WriteLine();
                Console.WriteLine("Old Man: \"Ah yes! Thank you young'n. My eyes aren't what they used t'be ye know.");
                Console.WriteLine();
                PressAnyKeyToContinue();
            }
            else if (input == "2")
            {
                // Fight
                Console.WriteLine("It's a Fight!");
                PressAnyKeyToContinue();
                Player enemy = new Player(100, 100, 10, 1, "Gindulf", "Wizard");
                _endGame = DoBattle(ref _player, ref enemy);
            }
        }
    
        bool DoBattle(ref Player player, ref Player enemy)
        {
            while (player.health > 0 && enemy.health > 0)
            {
                Console.Clear();
                player.PrintStats();
                Console.WriteLine();
                enemy.PrintStats();
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine(" [1] Attack!");
                Console.WriteLine(" [2] Defend!");
                Console.Write(">");
                string[] battleOptions = { "1", "2" };
                string input = GetStringInput(battleOptions);

                // Do player turn
                if (input == "1")
                {
                    Console.WriteLine("You attack " + enemy.name + " and deal " + player.damage + " damage!");
                    enemy.health -= player.damage;
                    PressAnyKeyToContinue();
                }
                else if (input == "2")
                {
                    Console.WriteLine("You defend yourself from all damage!");
                    PressAnyKeyToContinue();
                    Console.WriteLine();
                    continue;
                }

                // Do enemy attack
                Console.WriteLine(enemy.name + " attacks you and deals " + enemy.damage + " damage!");
                player.health -= enemy.damage;
                PressAnyKeyToContinue();
                Console.WriteLine();
            }
            return player.health > 0;
        }
    }
}
