using System.IO;
using System;
using System.Collections.Generic;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            Stack<string> stack = new Stack<string>();
            Directory root = new Directory("root");
            root.AddSubDir("/");
            Directory current = root;

            foreach(string line in lines)
            {
                //starts with $
                if(line[0] == '$')
                {   
                    if(line[2] == 'c' )
                    {
                        if(line.Substring(5)== "..")
                        {
                            current = current.parent;
                        }
                        else
                        {
                            current = current.GetSubDir(line.Substring(5));
                        }
                    }
                    else if(line[2] == 'l')
                    {
                        //do nothing? feels weird man
                    }
                }
                else if(line[0]=='d')
                {
                    current.AddSubDir(line.Substring(4));
                }
                else
                {
                    current.AddFileSize(int.Parse(line.Split(' ')[0]));
                }
            }
            Console.WriteLine(root.GetSubDir("/").Size);
            Console.WriteLine(root.test(root));
            Console.WriteLine(root.getSumOfSize());
            List<int> list = new List<int>();
            list = root.getSmallestToDelete(list,30000000-(70000000-root.GetSubDir("/").Size));
            list.Sort();
            //print max value of list
            Console.WriteLine(list[0]);
            
        }
    }
}