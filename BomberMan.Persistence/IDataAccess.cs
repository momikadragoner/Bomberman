using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.Model;

namespace BomberMan.Persistence
{
    public interface IDataAccess
    {
        Task<T> LoadAsync<T>(String path);
        Task<Maze> LoadMapAsync(String fileName);
        Task<GameState> LoadGameStateAsync(String fileName);
        Task SaveAsync (String path, String fileName, object obj);
        Task SaveMapAsync(Maze map);
        Task SaveGameSateAsync(GameState gameState);
    }
}
