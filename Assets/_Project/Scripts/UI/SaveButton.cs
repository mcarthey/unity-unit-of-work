using UnityEngine;
using UnityEngine.UI;
using Persistence;

namespace UI
{
    [AddComponentMenu("Game/UI/Save Button")]
    public class SaveButton : MonoBehaviour
    {
        public DataContext dataContext;

        private Button _button;

        private async void Save()
        {
            await dataContext.Save();
        }

        #region Unity Events

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Save);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Save);
        }

        #endregion
    }
}