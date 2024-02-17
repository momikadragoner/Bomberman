namespace Bomberman.Model.Tiles
{
    public class Field : Tile
    {
        public Field(int x, int y) : base(x, y)
        {
            Walkable = true;
        }

        public override void Blown() { } // nothing happens when blown up
    }
}
