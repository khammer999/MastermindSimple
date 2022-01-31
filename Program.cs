using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables declare

            int numOfTurns = 10;
            bool winnerStatus = false;

            //create arrays

            int[] randArray = new int[4];
            int[] comboArray = new int[4];
            bool[] containsNumber = new bool[4];
            bool[] notInPosition = new bool[4];
            bool[] isInPosition = new bool[4];
            bool[] winCheck = new bool[4];

            // intro and rules

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----Welcome To Simple Mastermind-----");
            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine();
            Console.Write(" A Four Digit Random Number has been generated. " +
                "\n" + " The player \"you\" will be prompted to enter a 4 digit guess(1 digit at a time, and press Enter after each digit) " +
                "\n" +" All Digits should be between 1 and 6. " +
                "\n" +" A '+' sign will be printed for each digit that is both'correct' and in the correct position in the 4 digit sequence.\n" +
                " A '-' sign will be printed for each digit that is 'correct' but in the wrong position in the 4 digit sequence. \n" +
                " Nothing will be printed for incorrect digits \n" +
                " You have 10 chances to get a correct answer.");
            Console.WriteLine();
            Console.WriteLine();

            // end intro and rules

            //generate 4 digit random number each digit between 1 and 6, and read into array
            for (int i = 0; i < 4; i++)
            {
                Random r = new Random();
                int genRand = r.Next(1, 7);
                // Console.WriteLine("Random Number = " + genRand);
                randArray[i] = genRand;
            }
            // end generate 4 digit random number

            // # of Turn Control Loop begin
            while (numOfTurns > 0)
            {
                // get 4 digit user input and read into combo array;

                Console.WriteLine();
                Console.WriteLine("Please Enter a 4 digit combination (1 digit at a time, press enter), each digit must be between 1 and6");
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("Please enter digit " + (i + 1) + " : ");
                    int inputEntered = int.Parse(Console.ReadLine());
                    comboArray[i] = inputEntered;
                }
                // end - get 4 digit user input and read into combo array;
                //set bool arrays (aka the truth table)
                //contains number array
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (comboArray[j] == randArray[k])
                        {
                            containsNumber[j] = true;
                        }
                    }
                }
                //notInPostionArray and isInPositionArray
                for (int i = 0; i < 4; i++)
                {
                    if (randArray[i] != comboArray[i])
                    {
                        notInPosition[i] = true;
                    }
                    if (randArray[i] == comboArray[i])
                    {
                        isInPosition[i] = true;
                    }
                }
                //end set bool arrays
                // print output + - and " "
                for (int i = 0; i < 4; i++)
                {
                    if (containsNumber[i] == true && isInPosition[i] == true)
                    {
                        Console.Write("+");
                        //winCheck[i] = true;
                    }
                    if (containsNumber[i] == true && notInPosition[i] == true)
                    {
                        Console.Write("-");
                    }
                    if (containsNumber[i] == false)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
                //end print output + - and " "


                //check for winner

                //test winCheck for winner
                for (int i = 0; i < 4; i++)
                {
                    if (containsNumber[i] == true && notInPosition[i] == false
                    && isInPosition[i] == true)
                    {
                        winCheck[i] = true;
                    }
                }
                if (winCheck[0] == true && winCheck[1] == true && winCheck[2]
                == true && winCheck[3] == true)
                {
                    winnerStatus = true;
                }
                if (winnerStatus == true)
                {
                    numOfTurns = 0;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write(" YOU ARE A WINNER ");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
                //end check for winner
                //reset truth tables and decrement for next loop itteration
                for (int i = 0; i < containsNumber.Length; i++)
                {
                    containsNumber[i] = false;
                }
                for (int i = 0; i < notInPosition.Length; i++)
                {
                    notInPosition[i] = false;
                }
                for (int i = 0; i < isInPosition.Length; i++)
                {
                    isInPosition[i] = false;
                }
                for (int i = 0; i < winCheck.Length; i++)
                {
                    winCheck[i] = false;
                }
                //decrement number of turns fo next itteration
                numOfTurns--;
                Console.WriteLine();
                Console.WriteLine("You Have : " + numOfTurns + " Turn(s)Remaining");
                // end reset truth tables and decrement for next loopitteration

             }//end # of turns control while loop


            // print "You Have Lost" message

            if (winnerStatus == false && numOfTurns == 0)
            {
                Console.WriteLine();
                Console.WriteLine("YOU HAVE LOST");
                Console.WriteLine();
            }

            }//end Main
        }//end class Program
}//end namespace
