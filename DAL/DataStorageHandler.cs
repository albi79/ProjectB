using System;
using System.IO;
using Newtonsoft.Json;
using ProjectB.Classes;

namespace ProjectB.DAL
{
    public class DataStorageHandler
    {
        private static string StorageFileLocation { get; set; }
        public static DataStorage Storage { get; set; }

        public static void Init(string filename)
        {
            if (!File.Exists(filename))
            {
                using StreamWriter sw = File.CreateText(filename);
            }

            StorageFileLocation = filename;
            string fileContent = File.ReadAllText(StorageFileLocation);

            try
            {
                Storage = JsonConvert.DeserializeObject<DataStorage>(fileContent);
                if(Storage == null)
                {
                    Storage = new DataStorage();
                }
            }
            catch(Exception)
            {
                Storage = new DataStorage();
            }
        }

        public static void Opslaan()
        {
            string JsonString = JsonConvert.SerializeObject(Storage, Formatting.Indented);
            File.WriteAllText(StorageFileLocation, JsonString);
        }
    }
}
