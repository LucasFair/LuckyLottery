using System;
using System.Threading;

namespace LuckAndLottery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("WELCOME TO LUCKY LOTTERY!\nWill you get the joker, or is your life nothing but a pathetic joke, " +
                    "just like mine?\nPress ENTER to try your luck!\nPress ESCAPE to quit the game. Enjoy!\n");  // Text to console.
                while (true)  // Allows for replaying of the game by pressing Enter (and quitting with Escape), while excluding repetition of the text.
                {
                    var keyPress = Console.ReadKey(false).Key;
                    switch (keyPress)
                    {
                        case ConsoleKey.Escape:  // By pressing Escape, you can quit the game.
                            Environment.Exit(0);
                            return;

                        case ConsoleKey.Enter: // Initializes the game-part of the code upon the Enter key being pressed.
                            var rnd = new Random();  // Shortens Random to rnd
                            List<int> listNum = new List<int>();  // Making a list that will contain the numbers.
                            int rndNum;
                            string pad = " ";
                            int maxDrws = 4;  // Default is 7. This sets the amount of numbers that will be drawn.
                            int maxRng = 36;  // Default is 36. This sets the highest number of the game.
                                              //int rndNum = rnd.Next(1, 36);
                            int jokerNum = rnd.Next(1, maxDrws);
                            int jokerCnt = 0;
                            const int second = 1000; // 1000 ms to 1 second
                            int timer = 1 * second;
                            Console.ResetColor();  // Resets the console color

                            for (int cnt = 0; cnt < maxDrws; cnt++)  // This draws the numbers up to the max drwas amount, incrementing by 1
                            {
                                do
                                {
                                    rndNum = rnd.Next(1, maxRng);  // Generates the random number within the range
                                } while (listNum.Contains(rndNum));  // This prevents duplicate numbers, and will redo the random number
                                                                     // until the max draw amount has been reached
                                                                     //Console.WriteLine(listNum);
                                listNum.Add(rndNum);  // Adds the generated numbers to the list
                                listNum.Sort();  // Sorts the numbers from small to large
                            }
                            foreach (int elmnt in listNum)  // This prints out the elements 
                            {
                                Console.ResetColor();
                                //string listToStr = elmnt.ToString();
                                //string numSpace = string.Format("{0,-4}", itr);
                                //Console.Write(pad + elmnt + pad);
                                //Console.Write(listToStr.PadRight(4, ' '));
                                Thread.Sleep(timer);  // Slows down the execution of the current thread. In this case, it is for suspense
                                //Console.Read();
                                if (elmnt == jokerNum && jokerCnt == 0)  // This ensures that the joker can only be drawn once,
                                                                         // and colors it accordingly while also adding a winner message
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;  // Colors the text red
                                    Console.Write(pad + elmnt + pad);  // Adds padding between the numbers
                                    jokerCnt++;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;  // Colors the text white, the default
                                    Console.ResetColor();  // Resets the color, just in case
                                    Console.Write(pad + elmnt + pad);
                                }
                            }
                            if (jokerCnt == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // Makes the message blue
                                Console.Write("\nYou got the joker! Congratulations!");
                            }
                            Console.WriteLine(string.Empty);  // Adds some line breaks for aesthetics' sake
                            Console.WriteLine(string.Empty);
                            //Console.WriteLine(listNum.Count);
                            //Console.WriteLine(rndNum);
                            //Console.WriteLine(jokerNum);
                            break;

                        default:
                            return;
                    }

                }
            }
        }


    }
}
