using System;
using System.Collections.Generic;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("Input.txt");
            List<Cell> cells = new List<Cell>();
            int startx = 0;
            int starty = 0;
            int endx = 0;
            int endy = 0;
            for(int i = 0; i < lines.Length; i++){
                for(int j = 0; j < lines[i].Length; j++){
                    if(lines[i][j] == 'S'){
                        Cell cell = new Cell(i, j, 1);
                        cells.Add(cell);
                        startx = i;
                        starty = j;
                    }
                    else if(lines[i][j] == 'E'){
                        Cell cell = new Cell(i, j, (int)'{'- 96);
                        cells.Add(cell);
                        endx = i;
                        endy = j;
                    }
                    else if(lines[i][j] == ' '){
                        Console.WriteLine("Error: Invalid character in input file");
                    }
                    else{
                        Cell cell = new Cell(i, j, (int)lines[i][j]-96);
                        cells.Add(cell);
                    }
                }
            }
            for(int rows = 0; rows < lines.Length; rows++){
                for(int columns = 0; columns < lines[rows].Length; columns++){
                    if(rows > 0){
                        cells[rows * lines[rows].Length + columns].AddNeighbour(cells[(rows - 1) * lines[rows].Length + columns]);
                    }
                    if(rows < lines.Length - 1){
                        cells[rows * lines[rows].Length + columns].AddNeighbour(cells[(rows + 1) * lines[rows].Length + columns]);
                    }
                    if(columns > 0){
                        cells[rows * lines[rows].Length + columns].AddNeighbour(cells[rows * lines[rows].Length + columns - 1]);
                    }
                    if(columns < lines[rows].Length - 1){
                        cells[rows * lines[rows].Length + columns].AddNeighbour(cells[rows * lines[rows].Length + columns + 1]);
                    }
                }
            }
            List<Cell> Copy = new List<Cell>(cells);
            List<Cell> shortest = new List<Cell>(cells);
            int shortestPath = 0;
            int shortestx = 0;
            int shortesty = 0;
            foreach(Cell cell1 in cells){
                foreach (Cell cell in cells){
                    cell.TotalDistance = 0;
                    cell.VisitedFrom = null;
                }
                List<Cell> cellsToCheck = new List<Cell>();
                if(cell1.value == (int)'a' - 96){
                    cellsToCheck.Add(cell1);
                }
                else
                {
                    continue;
                }
                List<Cell> NextCellsToCheck = new List<Cell>();

                Boolean found = false;
                int loopCount = 0;
                while(loopCount<1000 && !found)
                {
                    loopCount++;
                    foreach(Cell cell in cellsToCheck){
                        //Console.WriteLine("Checking cell with value: " + cell.value + " at X:" + cell.x + ", Y:" + cell.y);
                        if(cell.value == (int)'{' - 96){
                            Console.WriteLine("Found the end");
                            Console.WriteLine("Total distance: " + cell.TotalDistance);
                            if(shortestPath == 0 || cell.TotalDistance < shortestPath){
                                shortestPath = cell.TotalDistance;
                                shortestx = cell.x;
                                shortesty = cell.y;
                                shortest = new List<Cell>(cells);
                            }
                            found = true;
                            break;
                        }
                        else{
                            foreach(Cell neighbour in cell.neighbours){
                                if(neighbour.VisitedFrom==null){
                                    if(cell.value-neighbour.value >= -1)
                                    {
                                        neighbour.setDistance(cell.TotalDistance + 1,cell);
                                        NextCellsToCheck.Add(neighbour);
                                    }
                                }
                            }
                        }
                    }
                    //create a copy of the list
                    cellsToCheck = new List<Cell>(NextCellsToCheck);
                }
            }
            Console.WriteLine("Shortest path: " + shortestPath);
            cells = new List<Cell>(shortest);
            //set the values for the path
            Cell currentCell = cells[endx * lines[endx].Length + endy];
            int max = 400;
            int iterate = 0;
            while(currentCell.VisitedFrom != null){
                Console.WriteLine("Setting value of "+(char)(currentCell.value+96)+" at X:" + currentCell.x + ", Y:" + currentCell.y + " to " + (char)(currentCell.value + 96));
                currentCell.value = (int)'#'-96;
                currentCell = currentCell.VisitedFrom;
                if (iterate>max){
                    break;
                }
                iterate++;
            }


            //print the cells
            for(int i = 0; i < lines.Length; i++){
                for(int j = 0; j < lines[i].Length; j++){
                    Console.Write((char)(cells[i * lines[i].Length + j].value + 96));
                }
                Console.WriteLine();
            }
            

        }

    }

    class Cell{
        public int x;
        public int y;
        public int value;
        public int TotalDistance;
        public Cell VisitedFrom;
        public List<Cell> neighbours = new List<Cell>();
        public Cell(int x, int y, int value){
            this.x = x;
            this.y = y;
            this.value = value;
            VisitedFrom = null;

        }
        public Cell(Cell cell){
            this.x = cell.x;
            this.y = cell.y;
            this.value = cell.value;
            this.TotalDistance = cell.TotalDistance;
            this.VisitedFrom = cell.VisitedFrom;
            this.neighbours = cell.neighbours;
        }
        public void AddNeighbour(Cell cell){
            neighbours.Add(cell);
        }
        public void setDistance(int distance, Cell visitedFrom){
            this.TotalDistance = distance;
            this.VisitedFrom = visitedFrom;
        }
        public void PrintNeighbours(){
            Console.WriteLine("Neighbours of " +this.value + " at X:" + this.x + ", Y:" + this.y);
            for(int i = 0; i < neighbours.Count; i++){
                if(neighbours[i].x == this.x){
                    if(neighbours[i].y > this.y){
                        Console.WriteLine("Right: " + neighbours[i].value);
                    }
                    else{
                        Console.WriteLine("Left"+ neighbours[i].value);
                    }
                }
                else{
                    if(neighbours[i].x > this.x){
                        Console.WriteLine("Down"+ neighbours[i].value);
                    }
                    else{
                        Console.WriteLine("Up"+ neighbours[i].value);
                    }
                }
            }
        }
        public void ClearVisited(){
            this.VisitedFrom = null;
            this.TotalDistance = 0;
        }
    }
}

