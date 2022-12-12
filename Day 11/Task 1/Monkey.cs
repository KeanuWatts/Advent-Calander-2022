using System;
using System.Collections.Generic;

namespace MyNamespace
{
    class Monkey
    { 
        String name;
        List<long> Startingitems;
        
        char operand;
        string operandValue;
        string testValue;
        Monkey trueThrow;
        Monkey falseThrow;
        Boolean oldFlag;
        Boolean DebugThrows = false;
        long inspectcount = 0;
        int maxValue;
        public Monkey()
        {
            Startingitems = new List<long>();
        }

        public Monkey(string[] inputlist,string name)
        {
            this.name = name;
            //first value in the array will contain the starting items after the text "Starting items: " split with ", "
            string[] startingItems = inputlist[0].Split(new string[] { "Starting items: " }, StringSplitOptions.None)[1].Split(new string[] { ", " }, StringSplitOptions.None);
            this.Startingitems = new List<long>();
            foreach (string item in startingItems)
            {
                this.Startingitems.Add(long.Parse(item));
            }
            //second value in the array will contain the opperand after the text "Operation: new = old "
            this.operand = inputlist[1].Split(new string[] { "Operation: new = old " }, StringSplitOptions.None)[1][0];
            //the second value in the array will contain the opperand value after the text "Operation: new = old {opperand} "
            this.operandValue = inputlist[1].Split(new string[] { "Operation: new = old " + operand + " " }, StringSplitOptions.None)[1];
            //the third value in the array will contain the test value after the text "Test: divisible by "
            this.testValue = inputlist[2].Split(new string[] { "Test: divisible by " }, StringSplitOptions.None)[1];
            if(operandValue == "old")
                oldFlag = true;
            else
                oldFlag = false;
        }
        public void SetTrueThrow(Monkey monkey)
        {
            trueThrow = monkey;
        }
        public void SetFalseThrow(Monkey monkey)
        {
            falseThrow = monkey;
        }
        public void setValues(string[] inputlist)
        {
            //first value in the array will contain the starting items after the text "Starting items: " split with ", "
            string[] startingItems = inputlist[0].Split(new string[] { "Starting items: " }, StringSplitOptions.None)[1].Split(new string[] { ", " }, StringSplitOptions.None);
            Startingitems = new List<long>();
            foreach (string item in startingItems)
            {
                Startingitems.Add(long.Parse(item));
            }
            //second value in the array will contain the opperand after the text "Operation: new = old "
            operand = inputlist[1].Split(new string[] { "Operation: new = old " }, StringSplitOptions.None)[1][0];
            //the second value in the array will contain the opperand value after the text "Operation: new = old {opperand} "
            operandValue = inputlist[1].Split(new string[] { "Operation: new = old " + operand + " " }, StringSplitOptions.None)[1];
            //the third value in the array will contain the test value after the text "Test: divisible by "
            testValue = inputlist[2].Split(new string[] { "Test: divisible by " }, StringSplitOptions.None)[1];
            if(operandValue == "old")
                oldFlag = true;
            else
                oldFlag = false;
        }
        public String ToString()
        {
            string output = "Starting items:";
            foreach (long item in Startingitems)
            {
                output += item + ", ";
            }
            output = output.Substring(0, output.Length - 2);
            output += "\n";
            output += "Operation: " + operand + " " + operandValue + "\n";
            output += "Test: divisible by " + testValue;
            return output;
        }
        public String GetName()
        {
            return name;
        }
        public void inspectAllItems()
        {
            while (Startingitems.Count > 0)
            {
                this.inspectNextItem();
            }
        }
        public void inspectNextItem()
        {
            inspectcount++;
            if(oldFlag)
                this.operandValue = this.Startingitems[0].ToString();
            if(DebugThrows)
                Console.WriteLine("  Monkey inspects an item with a worry level of "+this.Startingitems[0]);
            string opperation = this.getOpperandWord();
            long worryLevel = this.CalculateWorryLevel(this.Startingitems[0], this.operand, this.operandValue);
            if(DebugThrows)
                Console.WriteLine("    Worry level is " + opperation + " " + this.operandValue + " to " + worryLevel);
            worryLevel = this.ReduceWorryLevel(worryLevel);
            if(DebugThrows)
                Console.WriteLine("    Monkey gets bored with item. Worry level is divided by 3 to " + worryLevel);
            if (this.TestCase(worryLevel))
            {
                if(DebugThrows)
                {
                    Console.WriteLine("    Current worry level is divisible by "+ this.testValue);
                    Console.WriteLine("    Item with worry level " + worryLevel + " is thrown to monkey " + this.trueThrow.GetName());
                }
                this.ThrowNextItem(this.trueThrow, worryLevel);
            }
            else
            {
                if(DebugThrows)
                {
                    Console.WriteLine("    Current worry level is not divisible by "+ testValue);
                    Console.WriteLine("    Item with worry level " + worryLevel + " is thrown to monkey " + this.falseThrow.GetName());
                }
                this.ThrowNextItem(this.falseThrow, worryLevel);
            }
        }

        private string getOpperandWord()
        {
            switch (this.operand)
            {
                case '+':
                    return "increased by";
                case '-':
                    return "subtracted from";
                case '*':
                    return "multiplied by";
                case '/':
                    return "divided by";
                default:
                    return "ERROR";
            }
        }
        private long CalculateWorryLevel(long worryLevel, char operand, string operandValue)
        {
            switch (operand)
            {
                case '+':
                    worryLevel += long.Parse(operandValue);
                    break;
                case '-':
                    worryLevel -= long.Parse(operandValue);
                    break;
                case '*':
                    worryLevel *= long.Parse(operandValue);
                    break;
                case '/':
                    worryLevel /= long.Parse(operandValue);
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
            return worryLevel;
        }
        private long ReduceWorryLevel(long worryLevel)
        {
            //divide worry level by 3, round down
            worryLevel = worryLevel%maxValue;
            return worryLevel;
        }
        private bool TestCase(long worryLevel)
        {
            //if worry level is divisible by test value return true
            if (worryLevel % long.Parse(testValue) == 0)
            {
                return true;
            }
            return false;
        }
        private void ThrowNextItem(Monkey monkey, long worryLevel)
        {
            this.RemoveFirstItem();
            monkey.AddItem(worryLevel);
        }
        private void AddItem(long worryLevel)
        {
            this.Startingitems.Add(worryLevel);
        }

        private void RemoveFirstItem()
        {
            this.Startingitems.RemoveAt(0);
        }
        public long GetInspectCount()
        {
            return this.inspectcount;
        }
        public int getTestValue()
        {
            return int.Parse(this.testValue);
        }
        public void setMaxValue(long value)
        {
            this.maxValue = (int)value;
        }
        
        public int calculateLCM(int a, int b)
        {
            return (a * b) / calculateGCD(a, b);
        }
        public int calculateGCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return calculateGCD(b, a % b);
        }
    }
}