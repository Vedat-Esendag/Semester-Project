using Newtonsoft.Json;
using System.IO;

namespace AM
{
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Asset manager results.");
            string filePath = "./SavedData";
            AssetManager AM = new();
            AM.AddBoilersAndSaveState(filePath);
        }
    }
}