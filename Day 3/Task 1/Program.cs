using System.IO;
using System;
using System.Collections.Generic;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            string[] lines = File.ReadAllLines("Input.txt");
            Dictionary<string, int> CharScore = new Dictionary<string, int>();
            foreach(string line in lines)
            {
                score += ScoreOfLine(line);
            }
            Console.WriteLine("score for task 1: " + score);
            score = 0;
            int linenum = 0;
            string[] newLines = new string[3];
            foreach(string line in lines)
            {
                newLines[linenum] = line;
                linenum++;
                if(linenum==3)
                {
                    linenum = 0;
                    score += ScoreOfLines(newLines);

                }
            }
            Console.WriteLine("score for task 2: " + score);
        }

        private static int ScoreOfLine(string line)
        {
            for (int i = 0; i < (line.Length/2); i++)
            {
                for (int y = line.Length/2; y < line.Length; y++)
                {
                    if (line[i] == line[y])
                    {   
                        int score = (int)line[i] - 96;
                        if(score < 0)
                        {
                            score +=58;
                        }
                        return score;
                    }
                }
            }
            return 0;
        }

         private static int ScoreOfLines(string[] lines)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines[1].Length; y++)
                {
                    if(lines[0][x] == lines[1][y])
                    {
                        for (int z = 0; z < lines[2].Length; z++)
                        {
                            if(lines[2][z] == lines[1][y])
                            {
                                int score = (int)lines[0][x] - 96;
                                if(score < 0)
                                {
                                    score +=58;
                                }
                                return score;
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
