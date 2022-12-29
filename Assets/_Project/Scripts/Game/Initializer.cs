using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Persistence;
using UI;

namespace Game
{
    public class Initializer : MonoBehaviour
    {
        public DataContext context;
        [Header("Repositories")] 
        public Players players;
        public Shops shops;
        [Header("Other Dependencies")] 
        public ShopWindow shopWindow;
        public TextAsset sampleData;

        private async void Start()
        {
            if (!File.Exists(FilePath))
            {
                await BootstrapShopData();
            }

            await context.Load();
            players.context = context;
            shops.context = context;
            shopWindow.Refresh();
        }

        private async Task BootstrapShopData()
        {
            using var writer = new StreamWriter(FilePath);
            await writer.WriteAsync(sampleData.text);
        }

        private static string FilePath => $"{Application.persistentDataPath}/shop_data.json";
    }
}