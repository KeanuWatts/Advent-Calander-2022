using System;
using System.IO;

namespace Task_1
{
    class Program
    {      
        static void Main(string[] args)
        {
            int[] callories = new int[1000];//should be a list instead.... hindsight
            int arrcount = 0;
            // Read a text file line by line.  
            string[] lines = File.ReadAllLines("Input.txt");

            foreach (string line in lines) 
            {
                if(line == " ")//yeaaaaah this null checking was not working, tried a few and couldnt get it working, so used try catch down under instead
                {
                    arrcount ++;
                }
                else
                {
                    try{//this just catches the null lines and moves to the next value in array, bad practice but does the job
                        callories[arrcount] += Convert.ToInt32(line);
                    }
                    catch
                    {
                        arrcount ++;
                    }
                }
            }
            Array.Sort(callories);
            Console.WriteLine("First Solution: most valuable Elf");
            Console.WriteLine(callories[999]);
            
            Console.WriteLine("Second Solution: Tax the rich");
            Console.WriteLine(callories[999]+callories[998]+callories[997]);
        }
    }
}
