using Newtonsoft.Json;
using System.IO;

namespace AM
{
    public class Program
    {
        public static void Main()
        {
            string filePath = "./SavedData";
            AssetManager AM = new AssetManager();
            AM.AddBoilersAndSaveState(filePath);
        }
    }
}