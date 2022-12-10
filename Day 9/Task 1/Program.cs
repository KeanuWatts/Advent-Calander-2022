using System;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            //read inputProgram.cs
            string[] lines = File.ReadAllLines("Input.txt");
            Knot head = new Knot(0, 0);
            Knot tail = new Knot(0, 0);
            head.setTail(tail);
            foreach (string line in lines)
            {
                string[] command = line.Split(' ');
                string Dir = command[0];
                int Dist = int.Parse(command[1]);
                head.Move(Dir, Dist);
            }
            head.printPath();
            Console.WriteLine("Distinct Points for tail: "+tail.getDistinctPointsOnPath());
        }
    }
}