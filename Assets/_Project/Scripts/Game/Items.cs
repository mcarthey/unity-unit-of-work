using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Model;

namespace Game
{
    public class Items : MonoBehaviour
    {
        [SerializeField] private List<Item> items;

        public bool CanAfford(Player player, string itemId) =>
            items.FirstOrDefault(i => i.id == itemId)?.price < player.gold;

        public IEnumerable<Item> MoreExpensiveThan(int amount) => items.Where(x => x.price > amount);
        public IEnumerable<Item> CheaperThan(int amount) => items.Where(x => x.price < amount);
    }
}



#region Plumbing

public class Foo
{
    private Game.Items items;

    private void Bar()
    {
        if (items.CanAfford(null, string.Empty)) return;
        foreach (var i in items.MoreExpensiveThan(0))
        {
        }

        foreach (var i in items.CheaperThan(0))
        {
        }
    }
}

#endregion