namespace Bomberman.Model.Tiles
{
    public class Player : Tile
    {
        // Fields
        private readonly int _id;
        
        // Properties
        public int Id { get { return _id; } }
        
        // Constructors
        public Player(int x, int y, int id) : base(x, y)
        {
            Walkable = false;
            _id = id;
        }

        public override void Blown() { } // TODO: CALL A "DEAD" EVENT
    }
}
