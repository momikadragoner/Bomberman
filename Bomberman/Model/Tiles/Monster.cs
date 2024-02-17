namespace Bomberman.Model.Tiles
{
    public class Monster : Tile
    {
        public Monster(int x, int y) : base(x, y)
        {
            Walkable = false;
        }

        public override void Blown() { } // TODO: CALL A "DEAD" EVENT
    }
}
