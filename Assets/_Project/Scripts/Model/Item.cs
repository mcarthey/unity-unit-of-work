using System;

namespace Model
{
    [Serializable]
    public class Item : Base
    {
        public string name;
        public string description;
        public int price;
    }
}