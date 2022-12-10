using System;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("Input.txt");;

            CPU cpu = new CPU();
            foreach (string line in lines)
            {
                cpu.Execute(line);
            }
            Console.WriteLine("Sum: " + cpu.GetSum());
        }
    }
}

public class CPU
{
    private int register;
    private int cycleNumber;
    private int sum;
    public CPU()
    {
        register = 1;
        cycleNumber = 0;
        sum = 0;
    }
    public void Execute(string instruction)
    {
        string[] words = instruction.Split(' ');
                switch(words[0])
                {
                    case "noop":
                        DoCycleNoAdd();
                        break;
                    case "addx":
                        DoCycleNoAdd();
                        DoCycleAdd(int.Parse(words[1]));
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
    }

    public void DoCycleNoAdd()
    {
        cycleNumber++;
        if(cycleNumber==20||((cycleNumber+20)%40==0&&cycleNumber!=0))
        {
            Console.WriteLine("Cycle:" + cycleNumber+ " Register:"+register + " Add:" + register*(cycleNumber)+ " Sum:" + sum);
            sum += register*(cycleNumber);
        }
    }
    public void DoCycleAdd(int add)
    {
        cycleNumber++;
        if(cycleNumber==20||((cycleNumber+20)%40==0&&cycleNumber!=0))
        {
            Console.WriteLine("Cycle:" + cycleNumber+ " Register:"+register + " Add:" + register*(cycleNumber)+ " Sum:" + sum);
            sum += register*(cycleNumber);
        }
        register += add;
    }
    public int GetSum()
    {
        return sum;
    }
}