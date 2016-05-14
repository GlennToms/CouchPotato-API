using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato
{
    internal class Settings
    {
        private const string Api = "/api/";
        private static volatile Settings instance;
        private static object syncRoot = new object();

        private Settings()
        {
        }

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Settings();
                    }
                }

                return instance;
            }
        }

        internal string BaseUrl { get; set; }

        internal string ApiKey { get; set; }

        internal string Url
        {
            get
            {
                var baseUrl = new Uri(new Uri(BaseUrl), Api);
                return new Uri(baseUrl, ApiKey).ToString();
            }
        }
    }
}
