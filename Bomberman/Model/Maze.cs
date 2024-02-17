using Bomberman.Model.Tiles;

namespace Bomberman.Model
{
    public class Maze
    {
        // Fields
        private readonly int _size; // size of the maze
        private readonly int _playerCount; // number of players
        private Tile[,] _tiles; // matrix representing the tiles of the maze

        // Properties
        public string Name { get; set; }
        public int Size => _size;
        public int PlayerCount => _playerCount;
        public Tile this[int x, int y] => _tiles[x, y];

        public TileEnum[,] Grid 
        { 
            get 
            {
                TileEnum[,] grid = new TileEnum[Size,Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        TileEnum t = TileEnum.Field;
                        switch (this[i,j].GetType().Name)
                        {
                            case "Crate":
                                t = TileEnum.Crate;
                                break;
                            case "Field":
                                t = TileEnum.Field;
                                break;
                            case "Monster":
                                t = TileEnum.Monster;
                                break;
                            case "Player":
                                t = TileEnum.Player;
                                break;
                            case "Wall":
                                t = TileEnum.Wall;
                                break;
                        }
                        grid[i, j] = t;
                    }
                }
                return grid;
            }
        }

        // Constructors
        public Maze(int size, int playerCount = 2)
        {
            _size = size;
            _playerCount = playerCount;
            _tiles = new Tile[_size, _size];
            InitializeMaze();
        }

        // Methods
        private void InitializeMaze()
        {
            // FOR TESTING FOR NOW

            // IDEA: METHOD TAKES INT A MATRIX REPRESENTING THE LAYOUT OF THE MAZE
            // MAYBE USE AN ENUM FOR IT

            Name = "Default Maze 1";

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (i == 0 || j == 0 || i == _size - 1 || j == _size - 1)
                    {
                        _tiles[i, j] = new Wall(i, j);
                    }
                    else
                    {
                        _tiles[i, j] = new Field(i, j);
                    }
                }
            }

            _tiles[1, 1] = new Player(1, 1, 1);
            _tiles[1, 2] = new Player(1, 2, 2);
            _tiles[1, 3] = new Monster(1, 3);
            _tiles[1, 4] = new Crate(1, 4);

            // SHOULD SEE THIS IF SIZE = 7
            // W  W  W  W  W  W  W
            // W  P1 P2 M  C  F  W
            // W  F  F  F  F  F  W
            // W  F  F  F  F  F  W 
            // W  F  F  F  F  F  W
            // W  F  F  F  F  F  W
            // W  W  W  W  W  W  W
            // (W = WALL, F = FIELD, Pn = PLAYER WITH ID n, M = MOSNTER, C = CRATE)
        }
    }
}
