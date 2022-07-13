namespace Battleship
{
    class Player
    {
        public Board actualBoard { get; set; }
        public Board visualBoard { get; set; }

        public string name { get; set; }

        public Player(string name, int size)
        {
            this.name = name;
            this.actualBoard = new Board(size);
            this.visualBoard = new Board(size);
        }

        public bool Hit(int x, int y)
        {
            if (actualBoard.GetCoord(x, y) == 'X')
            {
                visualBoard.SetCoord('X', x, y);
                return true;
            }
            else
            {
                visualBoard.SetCoord('O', x, y);
                return false;
            }
        }
    }
}