using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    class MazeSolver
    {
        private bool solved;
        private bool solutionNeedsBacktrack;
        private Stack<Position> solution = new Stack<Position>{};
        private Maze _maze;

        public MazeSolver()
        {

        }

        public Maze solveMaze(Maze maze)
        {
            _maze = maze;
            solved = false;
            solutionNeedsBacktrack = false;
            DepthSearch(_maze.start);
            return _maze;
        }

        private void DepthSearch(Position node)
        {
            node.visited = true;
            setOptions(node);
            if(node.hasEndOption)
            {
                solved = true;
            }
            else
            {
                while(node.options.Count > 0 && !solved)
                {
                    if(solutionNeedsBacktrack)
                    {
                        backTrackSolutionTo(node);
                    }
                    else
                    {
                        solution.Push(node);
                    }
                    node.options.Peek().sprite = '.';
                    DepthSearch(node.options.Pop());
                }

                if(!solved)
                {
                    node.sprite = '+';
                    solutionNeedsBacktrack = true;
                }
            }
        }

        private void backTrackSolutionTo(Position start)
        {
            while(solution.Peek() != start)
            {
                solution.Pop().sprite = '+';
            }
            solutionNeedsBacktrack = false;
        }

        private void setOptions(Position position)
        {
            if (position.sprite == '.' || position.sprite == 'S' || position.sprite == 'E') 
            {
                //Check surronding spaces
                for(int i = -1; i <= 1; i ++){
                    for(int j = -1; j <= 1; j++){
                        //Exclude diagnols
                        if(j == 0 ^ i == 0){
                            int x = position.x + j;
                            int y = position.y + i;
                            if(inbounds(x, y))
                            {
                                if(_maze.mazeArray[x, y].sprite == ' ' && !_maze.mazeArray[x, y].visited)
                                {
                                    position.options.Push(_maze.mazeArray[x, y]);
                                }
                                else if (_maze.mazeArray[x, y].sprite == 'E')
                                {
                                    position.hasEndOption = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool inbounds(int x, int y)
        {
            if(x < 0  || x > _maze.width)
            {
                return false;
            }
            else if( y < 0 || y > _maze.height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
