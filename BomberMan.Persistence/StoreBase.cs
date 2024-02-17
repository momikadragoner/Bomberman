using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan.Persistence
{
    public abstract class StoreBase : IStore
    {
        private string directoryName;

        public StoreBase(string dir)
        {
            directoryName = dir;
        }

        public async Task<IEnumerable<string>> GetFilesAsync()
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".bomberman", directoryName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            return await Task.Run(() => Directory.GetFiles(directoryPath)
                .Select(x => Path.GetFileName(x))
                .Where(name => name.EndsWith(".json")));
        }

        public async Task<DateTime> GetModifiedTimeAsync(string name)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".bomberman", directoryName, name);
            return await Task.Run(() => File.GetLastWriteTime(filePath));
        }
    }
}
