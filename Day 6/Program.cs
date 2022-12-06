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
            string line = lines[0];
            line.Append('.');
            line.Append('.');
            line.Append('.');
            int count = 0;
            char[] chars = new char[14];
            foreach(char c in line)
            {
                //if c appears in chars and chars does not have duplicates
                if(chars.Contains(c) && !ContainsDuplicates(chars))
                {
                    //if chars is not empty
                    if(chars[0] != '\0')
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    count++;
                    chars = moveleft(chars);
                    chars[13] = c;
                }
            }
            Console.WriteLine(count);
        }

        private static Boolean ContainsDuplicates(char[] chars)
        {
            for(int i = 0; i < chars.Length; i++)
            {
                for(int j = i + 1; j < chars.Length; j++)
                {
                    if(chars[i] == chars[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static char[] moveleft(char[] chars)
        {
            char[] newchars = new char[14];
            for(int i = 0; i < chars.Length - 1; i++)
            {
                newchars[i] = chars[i + 1];
            }
            return newchars;
        }
    }
}