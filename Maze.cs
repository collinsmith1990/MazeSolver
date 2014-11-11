using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MazeSolver
{
    class Maze
    {
        private Position _start = new Position();
        private Position _end = new Position();
        private int _width;
        private int _height;
        private Position[,] _mazeArray;

        public Maze(string mazePath)
        {
            String[] mazeFile = File.ReadAllLines(mazePath);
            String[] mazeSize = mazeFile[0].Split(' ');
            _width = Convert.ToInt32(mazeSize[0]);
            _height = Convert.ToInt32(mazeSize[1]);
            _mazeArray = new Position[_width, _height];
            _mazeArray = buildMaze(mazeFile);
        }

        //Properties
        public Position start { get { return _start; } }
        public Position end { get { return _end; } }
        public int width { get { return _width; } }
        public int height { get { return _height; } }
        public Position[,] mazeArray { get { return _mazeArray; } }

        private Position[,] buildMaze(String[] mazeFile)
        {
            var maze = new Position[_width, _height];
            int x = 0;
            int y = 0;
            //pattern is used to skip metadata on first line
            string pattern = @"[0-9]";
            foreach(string line in mazeFile)
            {
                if(!Regex.IsMatch(line, pattern))
                {
                    x = 0;
                    foreach(char sprite in line)
                    {
                        maze[x,y] = new Position(sprite, x, y);
                        if(sprite == 'S')
                        {
                            _start = maze[x,y];
                        }
                        x ++;
                    }
                    y ++;
                }
            }
            return maze;
        }

        public void print()
        {
            String path = Directory.GetCurrentDirectory();
            path += @"\MazeSolver.Output.txt";
            File.WriteAllText(path, "");
            for(int i = 0; i < _height; i++)
            {
                string line = "";
                for(int j = 0; j < _width; j++)
                {
                    line += _mazeArray[j,i].sprite;
                }
                File.AppendAllText(path, line + Environment.NewLine);
                Console.WriteLine(line);
            }
        }
    }
}
