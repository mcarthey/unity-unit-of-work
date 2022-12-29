using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Player : Base
    {
        public int gold;
        public List<Item> inventory;
    }
}
