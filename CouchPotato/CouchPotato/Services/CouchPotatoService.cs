using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model;
using CouchPotato.Model.CouchPotato;

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

            var response = _client.GetJson<StatusCodes>(command);
            return response.IsSuccess;
        }

        public VersionModel GetVersion()
        {
            const string command = "/app.version";

            var response = _client.GetJson<VersionModel>(command);

            response.OS = response.VersionString.Split('-')[0].Trim();
            response.Type = response.VersionString.Split('-')[1].Trim();
            response.Commit = response.VersionString.Split('-')[2].Trim();
            response.Release = response.VersionString.Split('-')[3].Trim();

            return response;
        }

        public StatusCodes Restart()
        {
            const string command = "/app.restart";

            var response = _client.GetStringNoJson(command);

            var status = new StatusCodes
            {
                IsSuccess = response == "restarting",
                Total = 0,
                IsEmpty = true
            };

            return status;
        }

        public StatusCodes Shutdown()
        {
            const string command = "/app.shutdown";

            var response = _client.GetStringNoJson(command);

            var status = new StatusCodes
            {
                IsSuccess = response == "shutdown",
                Total = 0,
                IsEmpty = true
            };

            return status;
        }
    }
}
