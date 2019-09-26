using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicTacToeBlazerFun
{
    public static class Statics
    {
        private static List<string> _names;

        static Statics()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "TicTacToeBlazerFun.Stuff.first-names.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                _names = JsonSerializer.Deserialize<List<string>>(result);
            }
        }

        public static string GetRandomName()
        {
            var random = new Random();

            return _names[random.Next(_names.Count)];
        }
    }
}
