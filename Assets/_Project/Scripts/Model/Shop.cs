using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Shop : Base
    {
        public string name;
        public int gold;
        public List<Item> products;
    }
}