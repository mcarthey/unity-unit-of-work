using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Model;

namespace UI
{
    [AddComponentMenu("Game/UI/Item View")]
    public class ItemView : MonoBehaviour
    {
        [HideInInspector] public ShopWindow shopWindow;
        [HideInInspector] public Item item;

        public TMP_Text nameLabel;
        public TMP_Text descriptionLabel;
        public TMP_Text priceLabel;
        public Button buyButton;

        public void Buy()
        {
            shopWindow.Buy(item);
            shopWindow.Refresh();
        }

        #region Unity Events

        public void Start()
        {
            nameLabel.text = item.name;
            descriptionLabel.text = item.description;
            priceLabel.text = item.price.ToString();
        }

        private void OnEnable()
        {
            buyButton.onClick.AddListener(Buy);
        }

        private void OnDisable()
        {
            buyButton.onClick.RemoveListener(Buy);
        }

        #endregion
    }
}