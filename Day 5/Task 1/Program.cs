using System.IO;
using System;
using System.Collections.Generic;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //creat an array of lists char
            List<char>[] list = new List<char>[9];
            string[] lines = File.ReadAllLines("Input.txt");
            // each list is a column in the first 8 lines 
            for (int i = 1; i < 36; i+=4)
            {
                Console.WriteLine(i);
                list[(int)i/4] = new List<char>();
                for (int j = 0; j < 8; j++)
                {
                    if(lines[j][i] != ' ')
                    {
                        list[(int)i/4].Add(lines[j][i]);
                    }
                }
            }
            //reverse each list
            for (int i = 0; i < 9; i++)
            {
                list[i].Reverse();
            }
            //print out all the values in the lists
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j]);
                }
                Console.WriteLine();
            }
            //remove first 10 rows from lines
            lines = lines[10..];
            foreach(string line in lines)
            {
                //split line by spaces
                string[] split = line.Split(" ");
                int AmmountToMove = int.Parse(split[1]);
                int origin = int.Parse(split[3])-1;
                int target = int.Parse(split[5])-1;
                //move amount to move from origin to a temporary list
                List<char> temp = new List<char>();
                for (int i = 0; i < AmmountToMove; i++)
                {
                    temp.Add(list[origin][list[origin].Count - 1]);
                    list[origin].RemoveAt(list[origin].Count - 1);
                }
                temp.Reverse();
                //add temp to target
                list[target].AddRange(temp);

                //this was for task 1
                // for(int i = 0; i< AmmountToMove; i++)
                // {
                //     list[target].Add(list[origin][list[origin].Count-1]);
                //     list[origin].RemoveAt(list[origin].Count-1);
                // }
            }
            //print out the last value in each list
            for (int i = 0; i <= 8; i++)
            {
                Console.Write(list[i][list[i].Count-1]);
            }
            
        }
    }
}