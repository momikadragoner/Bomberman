namespace Bomberman.Model.Tiles
{
    public class Crate : Tile
    {
        public Crate(int x, int y) : base(x, y)
        {
            Walkable = false;
        }

        public override void Blown() { } // TODO: DROP A POWERUP
    }
}
