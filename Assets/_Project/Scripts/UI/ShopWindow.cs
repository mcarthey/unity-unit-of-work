using UnityEngine;
using TMPro;
using Model;
using Persistence;

namespace UI
{
    [AddComponentMenu("Game/UI/Shop Window")]
    public class ShopWindow : MonoBehaviour
    {
        public string shopId;
        public string playerId;

        [Header("Dependencies")] 
        public UnitOfWork unitOfWork;
        public GameObject itemViewPrefab;

        [Header("UI Elements")] public Transform itemGrid;
        public TMP_Text shopNameLabel;
        public TMP_Text shopGoldLabel;
        public TMP_Text playerGoldLabel;

        public void Refresh()
        {
            var shop = unitOfWork.Shops.GetById(shopId);
            var player = unitOfWork.Players.GetById(playerId);
            shopNameLabel.text = shop.name;
            shopGoldLabel.text = shop.gold.ToString();
            playerGoldLabel.text = player.gold.ToString();
            ClearItemGrid();
            PopulateItemGrid(shop);
        }

        public void Buy(Item item)
        {
            var shop = unitOfWork.Shops.GetById(shopId);
            var player = unitOfWork.Players.GetById(playerId);
            
            if (!shop.products.Contains(item)) return;
            if (player.gold < item.price) return;
            
            player.gold -= item.price;
            player.inventory.Add(item);
            unitOfWork.Players.Modify(player);
            
            shop.gold += item.price;
            shop.products.Remove(item);
            unitOfWork.Shops.Modify(shop);
            
            unitOfWork.Save();
        }
        
        
        #region Plumbing

        private void PopulateItemGrid(Shop shop)
        {
            foreach (var item in shop.products)
            {
                var itemViewGO = CreateItemViewGO(item);
                itemViewGO.transform.SetParent(itemGrid);
            }
        }

        private void ClearItemGrid()
        {
            for (var i = itemGrid.childCount - 1; i >= 0; i--)
                Destroy(itemGrid.GetChild(i).gameObject);
        }

        private GameObject CreateItemViewGO(Item item)
        {
            var itemViewGO = Instantiate(itemViewPrefab);
            if (!itemViewGO.TryGetComponent<ItemView>(out var itemView)) return null;
            itemView.item = item;
            itemView.shopWindow = this;
            return itemViewGO;
        }

        #endregion
    }
}