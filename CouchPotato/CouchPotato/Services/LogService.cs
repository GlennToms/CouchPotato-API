﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model;
using CouchPotato.Model.Logging;
using CouchPotato.Model.Movie;

namespace CouchPotato.Services
{
    public class LogService
    {
        private readonly HttpClient _client;

        public LogService()
        {
            _client = new HttpClient();
        }

        public LogList GetLogs()
        {
            const string command = "/logging.get";

            var response = _client.GetJson<LogList>(command);

            response.Total = response.Log.Count;

            return response;
        }

        public LogList GetLogs(int lines)
        {
            const string command = "/logging.partial/?lines=";

            var response = _client.GetJson<LogList>(command + lines);

            response.Total = response.Log.Count;

            return response;
        }

        public LogList GetLogs(Model.Logging.Type type)
        {
            const string command = "/logging.partial/?type=";

            var response = _client.GetJson<LogList>(command + type);

            response.Total = response.Log.Count;

            return response;
        }

        public StatusCodes ClearLogs()
        {
            const string command = "/logging.clear";

            var response = _client.GetJson<StatusCodes>(command);

            response.Total = 0;
            response.IsEmpty = true;

            return response;
        }
    }
}
