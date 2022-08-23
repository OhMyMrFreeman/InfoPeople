using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace InfoPeople.Data
{
    static class OpenSaveFiles
    {
        const string path = "dbPeople.json";


        public static void SaveFile<T>(T people)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {


                writer.WriteLine(JsonSerializer.Serialize(people));

            }

        }

        public static List<T> LoadFile<T>()
        {
            using (StreamReader fs = new StreamReader(path))
            {
                List<T> peoples = new List<T>();
                

                peoples = JsonSerializer.Deserialize<List<T>>(fs.ReadToEnd());

                return peoples;
            }

        }
    }
}
