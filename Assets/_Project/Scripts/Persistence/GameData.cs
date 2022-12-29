using System;
using System.Collections.Generic;
using Model;

namespace Persistence
{
    [Serializable]
    public class GameData
    {
        public List<Player> players;
        public List<Shop> shops;
    }
}