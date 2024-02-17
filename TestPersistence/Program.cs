using BomberMan.Persistence;
using Bomberman.Model;
using System.Windows.Controls;

namespace TestPersistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press s to save");
            char c = 'a';
            while (c != 'q')
            {
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (c == 's')
                {
                    save();
                }
                if (c == 'l')
                {
                    load();
                }
                if (c == 't')
                {
                    testStore();
                }
            }
        }

        static async void testStore()
        {
            IStore mapStore = new MapStore();
            IEnumerable<string> maps = await mapStore.GetFilesAsync();
            Dictionary<string, DateTime> mapModifiedDates = new Dictionary<string, DateTime>();
            foreach (string s in maps)
            {
                mapModifiedDates[s] = await mapStore.GetModifiedTimeAsync(s);
            }
            foreach (var item in mapModifiedDates)
            {
                await Console.Out.WriteLineAsync(string.Format("{0} - {1}", item.Key, item.Value));
            }
        }

        static async void load()
        {
            JsonDataAccess access = new JsonDataAccess();
            Maze map = await access.LoadMapAsync("Default Maze 1.json");
            Console.WriteLine(map.Name);
            Console.WriteLine(map.PlayerCount);
            foreach (var item in map.Grid)
            {
                await Console.Out.WriteLineAsync(item.ToString());
            }
        }

        static async void save()
        {
            Maze map = new Maze(7);
            JsonDataAccess access = new JsonDataAccess();
            await access.SaveMapAsync(map);
            Console.WriteLine("Done");
        }
    }
}
