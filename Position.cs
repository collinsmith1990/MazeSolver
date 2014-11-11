using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    class Position
    {
        private char _sprite;
        private int _x;
        private int _y;
        private bool _visited;
        private bool _hasEndOption;
        private Stack<Position> _options;

        public Position()
        {
            _options = new Stack<Position>{};
        }

        public Position(char sprite, int x, int y)
        {
            _sprite = sprite;
            _x = x;
            _y = y;
            _options = new Stack<Position>{};
        }

        //Properties
        public char sprite { get { return _sprite; } set { _sprite = value; } }
        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }
        public bool visited { get { return _visited; } set { _visited = value; } }
        public bool hasEndOption { get { return _hasEndOption; } set { _hasEndOption = value; } }
        public Stack<Position> options { get { return _options; } set { _options = value; } }
    }
}
