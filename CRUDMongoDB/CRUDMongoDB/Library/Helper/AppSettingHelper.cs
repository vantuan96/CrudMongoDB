using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Library.Helper
{
    public class AppSettingHelper
    {
        public static Task<string> GetStringFromAppSetting(string key)
        {
            var valu = "";

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            valu = root[key];

            return Task.FromResult(valu);
        }

        public static Task<string> GetStringFromFileJson(string file, string key)
        {
            var valu = "";

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), file + ".json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            valu = root[key];

            return Task.FromResult(valu);
        }
    }
}

