using System;
using System.IO;

namespace Task1
{
    class Program
    {      
        static void Main(string[] args)
        {
            int score = 0;
            string[] lines = File.ReadAllLines("Input.txt");

            foreach (string line in lines) 
            {
                //  r   p   s
                //  X   Y   Z
                //  A   B   C
                //  1   2   3
                switch(line)
                {
                    case "A X": score += 4;
                        break;
                    case "A Y": score += 8;
                        break;
                    case "A Z": score += 3;
                        break;
                    case "B X": score += 1;
                        break;
                    case "B Y": score += 5;
                        break;
                    case "B Z": score += 9;
                        break;
                    case "C X": score += 7;
                        break;
                    case "C Y": score += 2;
                        break;
                    case "C Z": score += 6;
                        break;
                    default: Console.WriteLine("OOPS");
                        break;
                }
            }
            Console.WriteLine("First Solution: do as it says, score:");
            Console.WriteLine(score);

            //part two lets just go again
            score = 0;
            lines = File.ReadAllLines("Input.txt");

            foreach (string line in lines) 
            {
                //  r   p   s
                //  X   Y   Z
                //  A   B   C
                //  1   2   3
                //  L   D   W
                switch(line)
                {
                    case "A X": score += 3;
                        break;
                    case "A Y": score += 4;
                        break;
                    case "A Z": score += 8;
                        break;
                    case "B X": score += 1;
                        break;
                    case "B Y": score += 5;
                        break;
                    case "B Z": score += 9;
                        break;
                    case "C X": score += 2;
                        break;
                    case "C Y": score += 6;
                        break;
                    case "C Z": score += 7;
                        break;
                    default: Console.WriteLine("OOPS");
                        break;
                }
            }
            Console.WriteLine("Second Solution: Thanks for almost ruining it, score:");
            Console.WriteLine(score);
        }   
    }
}
