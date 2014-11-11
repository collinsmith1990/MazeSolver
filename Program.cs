using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeSolver mazesolver = new MazeSolver();
            string mazeFilePath = args[0];
            Maze maze = new Maze(mazeFilePath);
            mazesolver.solveMaze(maze);
            maze.print();
        }
    }
}
