using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bomberman.Model;

namespace BomberMan.Persistence
{
    public class JsonDataAccess : IDataAccess
    {
        private string mapPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".bomberman", "maps");
        private string gameStatePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".bomberman", "saves");
        private JsonSerializerOptions serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
                    {
                        new TwoDimEnumArrayJsonConverter()
                    }
        };

        public async Task<GameState> LoadGameStateAsync(string fileName)
        {
            return await LoadAsync<GameState>(Path.Combine(gameStatePath, fileName));
        }

        public async Task<Maze> LoadMapAsync(string fileName)
        {
            return await LoadAsync<Maze>(Path.Combine(mapPath, fileName));
        }

        public async Task<T> LoadAsync<T>(string path)
        {
            if (!File.Exists(path)) throw new DataException("File not found");
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                object? obj = await JsonSerializer.DeserializeAsync<T>(stream, serializeOptions);
                if (obj == null) throw new DataException();
                if (obj is not T) throw new DataException("Typecast not possible");
                else return (T)obj;
            }
        }

        public async Task SaveAsync(string path, string fileName, object obj)
        {
            Directory.CreateDirectory(path);
            using (FileStream stream = File.Open(Path.Combine(path, string.Format("{0}.json", fileName)), FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(stream, obj, serializeOptions);
            }
        }

        public async Task SaveGameSateAsync(GameState gameState)
        {
            await SaveAsync(gameStatePath, gameState.GetHashCode().ToString(), gameState);
        }

        public async Task SaveMapAsync(Maze map)
        {
            await SaveAsync(mapPath, map.Name, map);
        }
    }
}
