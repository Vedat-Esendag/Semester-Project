using Newtonsoft.Json;
using System.IO;

namespace AM
{
    public class Program
    {
        public static void Main()
        {
            string filePath = "/Users/lajoskariko/Documents/AssetManager"; // It's a local file, you can change it to yours.
            AssetManager AM = new AssetManager();
            AM.AddBoilersAndSaveState(filePath);
        }
    }
}