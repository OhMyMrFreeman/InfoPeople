using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace InfoPeople.Data
{
    static class LoadSaveFiles
    {
        private static readonly string path = @"DB\";
        private static readonly string nameFile = "DBPeople.json";


        public static void SaveFile<T>(T people)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            using (StreamWriter writer = new(path + nameFile, false, Encoding.UTF8))
            {
                writer.WriteLine(JsonSerializer.Serialize(people, options));
            }

        }

        public static List<T> LoadFile<T>()
        {
            FileInfo fileInfo = new(path + nameFile);
            if(!fileInfo.Exists)
            {
                Directory.CreateDirectory(path);
                using (StreamWriter writer = File.CreateText(path + nameFile))
                {
                    writer.WriteLine(JsonSerializer.Serialize(new List<T>()));
                }
            }


            using (StreamReader fs = new StreamReader(path + nameFile))
            {
                List<T> peoples = new();
                
                peoples = JsonSerializer.Deserialize<List<T>>(fs.ReadToEnd());

                return peoples;
            }

        }
    }
}
