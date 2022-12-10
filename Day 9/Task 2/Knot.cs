using System;

//create a new class for object named Head
class Knot
{
    //create a new method for the object named Head
    int x{get; set;}
    int y{get; set;}
    char name{get; set;}
    Knot tail;
    List<int[]> path = new List<int[]>();
    public Knot(int x, int y, char name)
    {
        this.x = x;
        this.y = y;
        this.name = name;
        this.tail = null;
    }

    public void setTail(Knot ntail)
    {
        this.tail = ntail;
    }
    public void Move(string Dir, int Dist)
    {
        for(int i = 0; i < Dist; i++)
        {
            switch (Dir)
            {
                case "U":
                    y ++;
                    break;
                case "D":
                    y --;
                    break;
                case "L":
                    x --;
                    break;
                case "R":
                    x ++;
                    break;
            }
            Track();
            tail.Follow(x,y);
        }
    }

    public void Follow(int Hx, int Hy)
    {
        if(Hx-x == 2 && Hy-y == 2)
        {
            x++;
            y++;
        }
        else if(Hx-x == -2 && Hy-y == -2)
        {
            x--;
            y--;
        }
        else if(Hx-x == 2 && Hy-y == -2)
        {
            x++;
            y--;
        }
        else if(Hx-x == -2 && Hy-y == 2)
        {
            x--;
            y++;
        }
        else if(Hx-x == 2)
        {
            x++;
            if(Hy-y == 1)
            {
                y++;
            }
            else if(Hy-y == -1)
            {
                y--;
            }
        }
        else if(Hx-x == -2)
        {
            x--;
            if(Hy-y == 1)
            {
                y++;
            }
            else if(Hy-y == -1)
            {
                y--;
            }
        }
        else if(Hy-y == 2)
        {
            y++;
            if(Hx-x == 1)
            {
                x++;
            }
            else if(Hx-x == -1)
            {
                x--;
            }
        }
        else if(Hy-y == -2)
        {
            y--;
            if(Hx-x == 1)
            {
                x++;
            }
            else if(Hx-x == -1)
            {
                x--;
            }
        }
        Track();
        if(this.tail != null)
        {
            this.tail.Follow(x,y);
        }
    }

    public void Track()
    {
        int[] pos = new int[2];
        pos[0] = x;
        pos[1] = y;
        path.Add(pos);
    }

    public void printPath()
    {
        if(tail != null)
        {
            int counter = 0;
            foreach (int[] pos in tail.path)
            {
                Console.WriteLine("Head: " + this.getPath(counter) + " Tail: " + tail.getPath(counter));
                counter++;
            }
        }
        else
        {
            int counter = 0;
            foreach (int[] pos in path)
            {
                Console.WriteLine(this.getPath(counter));
                counter++;
            }
        }
    }

    public string getPath(int x)
    {
        return this.path[x][0] + ", " + this.path[x][1];
    }

    public int getDistinctPointsOnPath()
    {
        List<int[]> distinct = new List<int[]>();
        foreach (int[] pos in path)
        {
            if(!this.ExistsInPath(pos,distinct))
            {
                distinct.Add(pos);
                Console.WriteLine("Added: " + pos[0] + ", " + pos[1]);
            }
        }
        return distinct.Count;
    }

    public Boolean ExistsInPath(int[] input,List<int[]> npath)
    {
        foreach (int[] pos in npath)
        {
            if(pos[0] == input[0] && pos[1] == input[1])
            {
                return true;
            }
        }
        return false;
    }
    

}