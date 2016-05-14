using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Services
{
    public class CouchPotatoService
    {
        private readonly HttpClient _client;

        public CouchPotatoService()
        {
            _client = new HttpClient();
        }

        public bool IsAvaliable()
        {
            const string command = "/app.available";

            var response = _client.GetDynamic(command);
            return (bool)response["success"].Value;
        }

        public Model.Version GetVersion()
        {
            const string command = "/app.version";

            var response = _client.GetDynamic(command);
            var str = (string)response["version"].Value;

            var ver = new Model.Version()
            {
                OS = str.Split('-')[0].Trim(),
                Type = str.Split('-')[1].Trim(),
                Commit = str.Split('-')[2].Trim(),
                Release = str.Split('-')[3].Trim()
            };
            return ver;
        }

        public bool Restart()
        {
            //const string command = "/app.restart";

            throw new NotImplementedException();
            //var response = _client.GetResponse<object>(command);
        }

        public bool Shutdown()
        {
            //const string command = "/app.shutdown";

            throw new NotImplementedException();
            //var response = _client.GetResponse<object>(command);
        }
    }
}
