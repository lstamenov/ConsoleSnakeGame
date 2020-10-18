using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SnakeByMEC
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Vars
            //cursorSnake
            int[] xPosition = new int[50];
               xPosition[0] = 35;
            int[] yPosition = new int[50]; 
               yPosition[0] = 20;
           decimal gamespeed = 150m;
            int appleDimX = 10;
            int appleDimY = 10;
            int applesEaten = 0;
            string userAction = "";
            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;
            bool isStayinMenu = true;
         




            

                
            

            Random random = new Random();

            Console.CursorVisible = false;
            #endregion

            do
            {
                showMenu(out userAction);
           

            


            switch(userAction)
            {
                case "1":
                case "d":
                case "directions":
                    
                    Console.Clear();
                    buildWall();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("1) Resize the console window so you can see all");
                    Console.SetCursorPosition(5, 6);
                    Console.WriteLine("    4 sides of playing field boarder");
                    Console.SetCursorPosition(5, 7);
                    Console.WriteLine("2) Use the arrowkeys to move the snake ");
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("3) The snake will die if it hits the wall");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("4) You gain points by eating the apple");
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine("But your snake is also go faster and get longer");
                    Console.SetCursorPosition(5, 12);
                    Console.WriteLine("Press enter to return tho the main menu");
                    Console.ReadLine();
                    Console.Clear();
                    showMenu(out userAction);

                    break;

                case "2":
                case "p":
                #region CasePlay
                case "play":
                        Console.Clear();
                    #region GameSetup
                    Console.SetCursorPosition(xPosition[0], yPosition[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write((char)214);

                    setApplePosition(random, out appleDimX, out appleDimY);
                    paintApple(appleDimX, appleDimY);

                    //Boundary
                    buildWall();

                    ConsoleKey command = Console.ReadKey().Key;






                    //Move

                    #endregion
                    #region directions
                    do
                    {
                        switch (command)
                        {
                            case ConsoleKey.LeftArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                xPosition[0]--;

                                break;

                            case ConsoleKey.UpArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                yPosition[0]--;

                                break;

                            case ConsoleKey.RightArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                xPosition[0]++;

                                break;

                            case ConsoleKey.DownArrow:

                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                yPosition[0]++;

                                break;
                        }
                        #endregion
                        
                        //detect when Snake hits boundary
                        paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);


                        isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);

                        if (isWallHit)
                        {
                            isGameOn = false;
                            Console.SetCursorPosition(28, 20);
                            Console.WriteLine("The snake hit the wall and died.");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(12, 21);
                            Console.Write("Your score is" + applesEaten * 100 + "!");
                            Console.SetCursorPosition(15, 22);
                            Console.WriteLine("Press Enter to comtinue");
                            applesEaten = 0;
                            Console.ReadLine();
                            Console.Clear();

                            showMenu(out userAction);

                        }


                        isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleDimX, appleDimY);


                        if (isAppleEaten)
                        {
                            setApplePosition(random, out appleDimX, out appleDimY);
                            paintApple(appleDimX, appleDimY);
                            applesEaten++;
                            gamespeed *= .925m;

                        }

                        if (Console.KeyAvailable) command = Console.ReadKey().Key;
                        System.Threading.Thread.Sleep(Convert.ToInt32(gamespeed));
                        #endregion
                    } while (isGameOn);



                    break;

                case "3":
                case "e":
                case "exit":
                    isStayinMenu = false;
                    Console.Clear();
                    break;





                default:
                    Console.WriteLine("Your input was not understood, please press enter and try again");
                    Console.ReadLine();
                    Console.Clear();
                    showMenu(out userAction);
                    break;
                    

            }

            } while (isStayinMenu);






        }
        #region MENUU
        private static void showMenu(out string userAction)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string menu1 = "1) Directions \n 2) Play \n 3) Exit \n\n\n" + @"
          
      ``.--.`                                                         
  `:osyooyyyys /.
  `-:/ ++osyyhhhh /
           .:ohddo`        `-oyyyyys:`            ./ ooo +:.`             
              ./ ydh + -.`.. / yyo: :--::os /.`      `-os +///oo/`           
                     -+dmmdhdmdo /:`      `-ohyssos shy / -` ```` `-/ so -`        
                 :ydmmhs / +          `:oyhhhy +.`          `./ sys +:::/ +.
     
                        .:/://-`                                    `.-/osys+-`                                                                    
                                                                      ";






            string menu2 = "1) Directions \n 2) Play \n 3) Exit \n\n\n" + @"          
      ``.--.`                                                         
  `:osyooyyyys /.
  `-:/ ++osyyhhhh /
           .:ohddo`        `-oyyyyys:`            ./ ooo +:.`             
              ./ ydh + -.`.. / yyo: :--::os /.`      `-os +///oo/`           
                     -+dmmdhdmdo /:`      `-ohyssos shy / -` ```` `-/ so -`        
                 :ydmmhs / +          `:oyhhhy +.`          `./ sys +:::/ +.
     
                        .:/://-`                                    `.-/osys+-`                                                                    
                                                                      ";
            string menu3 = "1) Directions \n 2) Play \n 3) Exit \n\n\n" + @"          
      ``.--.`                                                         
  `:osyooyyyys /.
  `-:/ ++osyyhhhh /
           .:ohddo`        `-oyyyyys:`            ./ ooo +:.`             
              ./ ydh + -.`.. / yyo: :--::os /.`      `-os +///oo/`           
                     -+dmmdhdmdo /:`      `-ohyssos shy / -` ```` `-/ so -`        
                 :ydmmhs / +          `:oyhhhy +.`          `./ sys +:::/ +.
     
                        .:/://-`                                    `.-/osys+-`                                                                    
                                                                      ";
            string menu4 = "1) Directions \n 2) Play \n 3) Exit \n\n\n" + @"          
      ``.--.`                                                         
  `:osyooyyyys /.
  `-:/ ++osyyhhhh /
           .:ohddo`        `-oyyyyys:`            ./ ooo +:.`             
              ./ ydh + -.`.. / yyo: :--::os /.`      `-os +///oo/`           
                     -+dmmdhdmdo /:`      `-ohyssos shy / -` ```` `-/ so -`        
                 :ydmmhs / +          `:oyhhhy +.`          `./ sys +:::/ +.
     
                        .:/://-`                                    `.-/osys+-`                                                                    
                                                                      ";
            string menu5 = "1) Directions \n 2) Play \n 3) Exit \n\n\n" + @"          
      ``.--.`                                                         
  `:osyooyyyys /.
  `-:/ ++osyyhhhh /
           .:ohddo`        `-oyyyyys:`            ./ ooo +:.`             
              ./ ydh + -.`.. / yyo: :--::os /.`      `-os +///oo/`           
                     -+dmmdhdmdo /:`      `-ohyssos shy / -` ```` `-/ so -`        
                 :ydmmhs / +          `:oyhhhy +.`          `./ sys +:::/ +.
     
                        .:/://-`                                    `.-/osys+-`                                                                    
                                                                      ";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(menu1);
            System.Threading.Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine(menu2);
            System.Threading.Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine(menu3);
            System.Threading.Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine(menu4);
            System.Threading.Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine(menu5);
            System.Threading.Thread.Sleep(100);

            SpeechSynthesizer toSpeak = new SpeechSynthesizer();
            toSpeak.Speak("The snake game");

            userAction = Console.ReadLine().ToLower();
        }
       
        #endregion













        //Build Welcome screen

        //Give player option to read directions
        //Show score
        //Give player option to replay the game



        #region Menu

        #endregion
        #region Meth
        private static void paintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);

            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }


        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40)
                return true;
            return false;
        }


        private static void buildWall()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70, i);
                Console.Write("#");

            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");
            }
        }

        private static void setApplePosition(Random random, out int appleDimX, out int appleDimY)
        {
            appleDimX = random.Next(0 + 2, 70 - 2);
            appleDimY = random.Next(0 + 2, 40 - 2);
        }

        private static void paintApple(int appleDimX, int appleDimY)
        {
            Console.SetCursorPosition(appleDimX, appleDimY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleDimX, int appleDimY)
        {
            if (xPosition == appleDimX && yPosition == appleDimY)
                return true;
                return false;
         }
        #endregion











    }
}
