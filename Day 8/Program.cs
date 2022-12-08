using System;
using System.Collections.Generic;


namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int MaxScore=0;
            int MaxScoreX;
            int MaxScoreY;
            //read the input from file
            string[] lines = System.IO.File.ReadAllLines("input.txt");
            //create a 2D array to store the input
            int[][] input = new int[lines.Length][];
            
            for(int i = 0; i < lines.Length; i++)
            {
                input[i] = new int[lines.Length];
                for(int j = 0; j < lines.Length; j++)
                {
                    input[i][j] = Int32.Parse(lines[i][j].ToString());
                }
            }
            int count = 0;
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < input.Length; j++)
                {
                    if(MaxScore<ViewScore(input, j, i))
                    {
                        MaxScore = ViewScore(input, j, i);
                        MaxScoreX = j;
                        MaxScoreY = i;
                    }
                }
            }
            //count += (lines.Length*4)-4;
            Console.WriteLine(MaxScore);
        }

        private static int ViewScore(int[][] array, int Col, int Row)
        {
            int above = 0;
            int below = 0;
            int left = 0;
            int right = 0;
            for(int i = Row; i >= 0; i--)
            {
                above = (Math.Abs(i-Row));
                if(array[i][Col] >= array[Row][Col] && i != Row)
                {
                    break;
                }
            }
            //check the value below
            for(int i = Row; i < array.Length; i++)
            {
                below = (Math.Abs(i-Row));
                if(array[i][Col] >= array[Row][Col] && i != Row)
                {
                    break;
                }
            }
            //check the value to the left
            for(int i = Col; i >= 0; i--)
            {
                left = (Math.Abs(i-Col));
                if(array[Row][i] >= array[Row][Col] && i != Col)
                {
                    break;
                }
            }
            //check the value to the right
            for(int i = Col; i < array.Length; i++)
            {
                right = (Math.Abs(i-Col));
                if(array[Row][i] >= array[Row][Col]&& i != Col)
                {
                    break;
                }
            }
            Console.WriteLine("Value: " + array[Row][Col] + " Col: " + Col + " Row: " + Row + " Above: " + above + " Below: " + below + " Left: " + left + " Right: " + right);
            return above * below * left * right;
        }

        public void distanceToNextEqualOrHigherValueRight(int[][] array, int Row, int Col)
        {
            int distance = 0;
            for(int i = Row; i < array.Length; i++)
            {
                if(array[Col][i] >= array[Col][Row])
                {
                    distance = Math.Abs(i-Row);
                }
            }
        }
    }
}