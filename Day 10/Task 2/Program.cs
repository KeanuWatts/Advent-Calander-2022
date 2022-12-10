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
            cpu.PrintDisplay();
        }
    }
}

public class CPU
{
    private int register;
    private int cycleNumber;
    private int sum;
    private List<char> Display;
    private int SpritePos;
    public CPU()
    {
        register = 1;
        SpritePos = 1;
        cycleNumber = 0;
        sum = 0;
        Display = new List<char>();
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
        this.AddSprite();
        if(cycleNumber==20||((cycleNumber+20)%40==0&&cycleNumber!=0))
        {
            Console.WriteLine("Cycle:" + cycleNumber+ " Register:"+register + " Add:" + register*(cycleNumber)+ " Sum:" + sum);
            sum += register*(cycleNumber);
        }
    }
    public void DoCycleAdd(int add)
    {
        cycleNumber++;
        this.AddSprite();
        if(cycleNumber==20||((cycleNumber+20)%40==0&&cycleNumber!=0))
        {
            Console.WriteLine("Cycle:" + cycleNumber+ " Register:"+register + " Add:" + register*(cycleNumber)+ " Sum:" + sum);
            sum += register*(cycleNumber);
        }
        register += add;
    }

    public void AddSprite()
    {
        int DrawPos = (cycleNumber-1) % 40;
        SpritePos = register;
        if(DrawPos == SpritePos - 1 || DrawPos == SpritePos || DrawPos == SpritePos + 1)
        {
            Console.WriteLine("DrawPos: " + DrawPos + " Spritepos: " + SpritePos + "Draw");
            Display.Add('#');
        }
        else
        {
        Console.WriteLine("DrawPos: " + DrawPos + " Spritepos: " + SpritePos + "Dont");
            Display.Add(' ');
        }
        if(DrawPos == 39)
        {
            Display.Add('\n');
        }
    }
    public int GetSum()
    {
        return sum;
    }

    public void PrintDisplay()
    {
        Console.WriteLine("Display: ");
        Console.WriteLine(string.Join("", Display));
    }
}