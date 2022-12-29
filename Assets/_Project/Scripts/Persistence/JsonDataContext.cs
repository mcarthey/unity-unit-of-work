using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Persistence
{
    public class JsonDataContext : DataContext
    {
        public string fileName;

        public override async Task Load()
        {
            if (! File.Exists(FilePath)) return;
            using var reader = new StreamReader(FilePath);
            var json = await reader.ReadToEndAsync();
            JsonUtility.FromJsonOverwrite(json, data);
        }

        public override async Task Save()
        {
            var json = JsonUtility.ToJson(data);
            using var writer = new StreamWriter(FilePath);
            await writer.WriteAsync(json);
        }
        
        private string FilePath => $"{Application.persistentDataPath}/{fileName}.json";
    }
}