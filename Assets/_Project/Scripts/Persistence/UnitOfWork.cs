using UnityEngine;

namespace Persistence
{
    public class UnitOfWork : MonoBehaviour
    {
        [SerializeField] private DataContext dataContext;
        [SerializeField] private Players players;
        [SerializeField] private Shops shops;

        public Players Players => players;
        public Shops Shops => shops;

        public async void Save() => await dataContext.Save();
    }
}