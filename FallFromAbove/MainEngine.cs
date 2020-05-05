using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FallFromAbove
{
    class MainEngine
    {
        public int user_choice;
        public int total_moves;
        public List<Body> bodies;

        public void DisplayMenu()
        {
            while (true)
            {
                ClearScreen();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\n\n\t\t\t\t FALL FROM ABOVE \n\n\n\n");
                Console.Write("\t\t\t\t1.Play");
                Console.Write("\t\t\t\t2.Exit");
                Console.Write("\n\n\n\n\tEnter your choice:");
                Console.WindowWidth = 100;
                Console.WindowHeight = 50;

                try
                {
                    user_choice = int.Parse(Console.ReadLine());
                }
                catch { }

                ParseUserChoice();
            }

        }

        public void drawObject(Body obj)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(obj.x, obj.y);
            Console.Write(obj.rep);
        }

        public void drawUser(User obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(obj.x, obj.y);
            Console.Write(obj.rep);
        }

        private void User_exit()
        {
            Environment.Exit(0);
        }

        public void GameOver(User user)
        {
            ClearScreen();
            Console.WriteLine("\n\n\n\n\n\t\t\tGAME OVER!!!!\n\n\n\n\t\t\t YOUR SCORE: {0} \n\n\n\n\t\t\tPress Enter key to go back to menu: ", user.score);
            while (true)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                if (consoleKey == ConsoleKey.Enter)
                    break;
            }

            DisplayMenu();
        }

        private void PlayGame()
        {
            var r = new Random();
            bodies = new List<Body>();
            var user = new User();

            while (true)
            {
                var obj = new Body(r);
                bodies.Add(obj);
                ClearScreen();

                for (int j = 0; j < bodies.Count(); j++)
                {
                    drawObject(bodies[j]);

                    if (bodies[j].x == user.x && bodies[j].y == user.y)
                    {
                        GameOver(user);
                    }

                    bodies[j].y++;

                    if (bodies[j].y == 50)
                    {
                        user.score++;
                        bodies.RemoveAt(j);
                    }

                }

                drawUser(user);
                ConsoleKey keyinfo;
                Thread.Sleep(50);

                if (Console.KeyAvailable)
                {
                    keyinfo = Console.ReadKey(true).Key;

                    if (keyinfo == ConsoleKey.LeftArrow)
                        user.x--;
                    else if (keyinfo == ConsoleKey.RightArrow)
                        user.x++;
                }
                if (user.x > 99 || user.x < 1)
                    GameOver(user);

                drawUser(user);
            }
        }

        private void ClearScreen()
        {
            Console.Clear();
        }

        public void ParseUserChoice()
        {
            if (user_choice == 2)
                User_exit();
            else if (user_choice == 1)
            {
                total_moves = 0;
                ClearScreen();
                PlayGame();
            }
            else
            {
                ClearScreen();
                Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t INVALID CHOICE!");
                Console.WriteLine("\n\n\n\t\t\t\t\t\t Press any key to go back to the MENU!");
                Console.ReadKey();
            }
        }
    }
}
