﻿using CouchPotato.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CouchPotato
{
    public class Client
    {
        public CouchPotatoService CouchPotato { get; private set; }

        public MovieService Movie { get; private set; }

        public LogService Log { get; private set; }

        public Client(string url, string apiKey) : this(url, apiKey, new CouchPotatoService(), new MovieService(), new LogService())
        {
        }

        internal Client(string url, string apiKey, CouchPotatoService couchPotatoService, MovieService movieService, LogService logService)
        {
            Settings.Instance.BaseUrl = url;
            Settings.Instance.ApiKey = apiKey;

            CouchPotato = couchPotatoService;
            Movie = movieService;
            Log = logService;

        }
    }
}
