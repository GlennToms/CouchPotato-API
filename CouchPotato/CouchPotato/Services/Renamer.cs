using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model;

namespace CouchPotato.Services
{
    public class RenamerService
    {
        private readonly HttpClient _client;

        public RenamerService()
        {
            _client = new HttpClient();
        }

        public bool IsScanning()
        {
            const string command = "/renamer.progress";

            var result = _client.GetJson<StatusCodes>(command);

            return result.IsSuccess;
        }

        public StatusCodes Renamer()
        {
            const string command = "/renamer.scan";

            var result = _client.GetJson<StatusCodes>(command);

            return result;
        }
    }
}
