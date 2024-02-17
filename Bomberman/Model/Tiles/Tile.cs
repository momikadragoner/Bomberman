namespace Bomberman.Model.Tiles
{
    public abstract class Tile
    {
        // Fields
        private int _x; // x coordinate of the tile
        private int _y; // y coordinate of the tile
        private bool _walkable; // whether the tile is walkable

        // Properties
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public bool Walkable { get { return _walkable; } protected set { _walkable = value; } }

        // Constructors
        public Tile(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // Methods
        public abstract void Blown(); // what happens after the tile blown up
    }
}
