using System;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("Input.txt");
            //remove blank lines
            lines = Array.FindAll(lines, (s) => !string.IsNullOrWhiteSpace(s));
            //remove lines that start with Monkey
            lines = Array.FindAll(lines, (s) => !s.StartsWith("Monkey"));
            Console.WriteLine("Number of monkeys: " + lines.Count());;
            //group every 5 lines together into a string array, clearing whitespace while doing so
            string[][] line = lines.Select((s, i) => i % 5 == 0 ? lines.Skip(i).Take(5).ToArray() : null).Where(x => x != null).ToArray();
            //for each line, create a monkey
            Monkey[] monkeys = new Monkey[line.Count()];
            for (int i = 0; i < line.Count(); i++)
            {
                monkeys[i] = new Monkey(line[i],i.ToString());
            }
            for (int i = 0; i < line.Count(); i++)
            {
                monkeys[i].SetTrueThrow(monkeys[int.Parse(line[i][3].Split(new string[] { "If true: throw to monkey " }, StringSplitOptions.None)[1])]);
                monkeys[i].SetFalseThrow(monkeys[int.Parse(line[i][4].Split(new string[] { "If false: throw to monkey " }, StringSplitOptions.None)[1])]);
            }
            
            int lcm = 1;
            foreach (Monkey monkey in monkeys)
            {
                lcm = monkey.calculateLCM(lcm, monkey.getTestValue());
            }
            foreach (Monkey monkey in monkeys)
            {
                monkey.setMaxValue(lcm);
            }
            for(int i = 0; i < 10000 ; i++)
            {
                foreach(Monkey monkey in monkeys)
                {
                    //Console.WriteLine("Monkey "+monkey.GetName());
                    monkey.inspectAllItems();
                }
            }
            //sort the monkeys based on the inspectcount
            Array.Sort(monkeys, delegate(Monkey x, Monkey y)
            {
                return x.GetInspectCount().CompareTo(y.GetInspectCount());
            });
            //write the maximum two monkeys inspection count multipled together
            Console.WriteLine(monkeys[monkeys.Count() - 1].GetInspectCount() * monkeys[monkeys.Count() - 2].GetInspectCount());
            Console.WriteLine(monkeys[monkeys.Count() - 1].GetInspectCount() + " " + monkeys[monkeys.Count() - 2].GetInspectCount());
        }
    }

}