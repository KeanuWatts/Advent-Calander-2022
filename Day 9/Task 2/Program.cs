using System;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            //read inputProgram.cs
            string[] lines = File.ReadAllLines("Input.txt");
            Knot head = new Knot(0, 0,'H');
            Knot tail1 = new Knot(0, 0,'1');
            Knot tail2 = new Knot(0, 0,'2');
            Knot tail3 = new Knot(0, 0,'3');
            Knot tail4 = new Knot(0, 0,'4');
            Knot tail5 = new Knot(0, 0,'5');
            Knot tail6 = new Knot(0, 0,'6');
            Knot tail7 = new Knot(0, 0,'7');
            Knot tail8 = new Knot(0, 0,'8');
            Knot tail9 = new Knot(0, 0,'9');
            Knot tail10 = new Knot(0, 0,'9');
            head.setTail(tail1);
            tail1.setTail(tail2);
            tail2.setTail(tail3);
            tail3.setTail(tail4);
            tail4.setTail(tail5);
            tail5.setTail(tail6);
            tail6.setTail(tail7);
            tail7.setTail(tail8);
            tail8.setTail(tail9);
            tail9.setTail(tail10);
            int count = 0;
            foreach (string line in lines)
            {
                string[] command = line.Split(' ');
                string Dir = command[0];
                int Dist = int.Parse(command[1]);
                count += Dist;
                head.Move(Dir, Dist);
                Console.WriteLine(line);
            }
            head.printPath();
            Console.WriteLine("Distinct Points for tail: "+tail9.getDistinctPointsOnPath());
            Console.WriteLine("Total Distance: "+count);
        }
    }
}