using System.IO;
using System;
using System.Collections.Generic;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = 0;
            string[] lines = File.ReadAllLines("Input.txt");
            foreach(string line in lines)
            {
                //split line on commas  
                string[] splitLine = line.Split(',');
                //split splitLine on dashes 
                string[] splitLine1 = splitLine[0].Split('-');
                string[] splitLine2 = splitLine[1].Split('-');
                //if both of splitLine1 are in between the two in splitLine2
                if (int.Parse(splitLine1[0]) >= int.Parse(splitLine2[0]) && int.Parse(splitLine1[0]) <= int.Parse(splitLine2[1]) && int.Parse(splitLine1[1]) >= int.Parse(splitLine2[0]) && int.Parse(splitLine1[1]) <= int.Parse(splitLine2[1]))
                {
                    score++;
                 
                }
                //if both of splitLine2 are in between the two in splitLine1
                else if (int.Parse(splitLine2[0]) >= int.Parse(splitLine1[0]) && int.Parse(splitLine2[0]) <= int.Parse(splitLine1[1]) && int.Parse(splitLine2[1]) >= int.Parse(splitLine1[0]) && int.Parse(splitLine2[1]) <= int.Parse(splitLine1[1]))
                {
                    score++;
                }
            }
            Console.WriteLine("score for task 1: " + score);

            score = 0;
            foreach(string line in lines)
            {
                //split line on commas  
                string[] splitLine = line.Split(',');
                //split splitLine on dashes 
                string[] splitLine1 = splitLine[0].Split('-');
                string[] splitLine2 = splitLine[1].Split('-');
                //if either of splitline 1 is bwetweeb the two in splitline 2      
                if (int.Parse(splitLine1[0]) >= int.Parse(splitLine2[0]) && int.Parse(splitLine1[0]) <= int.Parse(splitLine2[1]) || int.Parse(splitLine1[1]) >= int.Parse(splitLine2[0]) && int.Parse(splitLine1[1]) <= int.Parse(splitLine2[1]))
                {
                    score++;
                }
                //else if either of splitline 1 is bwetweeb the two in splitline 2    
                else if (int.Parse(splitLine2[0]) >= int.Parse(splitLine1[0]) && int.Parse(splitLine2[0]) <= int.Parse(splitLine1[1]) || int.Parse(splitLine2[1]) >= int.Parse(splitLine1[0]) && int.Parse(splitLine2[1]) <= int.Parse(splitLine1[1]))
                {
                    score++;
                }
                
            }
            Console.WriteLine("score for task 2: " + score);
        }
    }
}