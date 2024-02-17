using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberMan.Persistence
{
    public class GameStateStore : StoreBase
    {
        public GameStateStore() : base("saves") { }
    }
}
