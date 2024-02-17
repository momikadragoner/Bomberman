namespace Bomberman.Model.Tiles
{
    public class Wall : Tile
    {
        public Wall(int x, int y) : base(x, y)
        {
            Walkable = false;
        }

        public override void Blown() { } // nothing happens when blown up
    }
}
