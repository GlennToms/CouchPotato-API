# CouchPotato-API
C-Sharp API for CouchPotato

Code cloned from https://github.com/SiCKRAGETV/SickRage.

## Setup
You'll need the CouchPotato url and api key. The api key can be found from "Settings" => "Show Advanced" => Api Key.

## Supported Fuctions
+ Listing Movies and Logs.
+ Adding and Removing Movies.
+ Checking CouchPotato Health.

### Setup Client

```c#
const string apiKey = "123456789abcdefghijk"; //Replace by your CouchPotato API Key.
const string url = "http://localhost:5050"; //Replace by your CouchPotato Hostname or IP.
var client = new Client(url, apiKey);
```

### List All Movies
```c#
var movies = client.Movie.GetMovies();

foreach (var movie in movies.Movies)
{
    Console.WriteLine(movie.Title);
}
```

### Get Logs By Type
```c#
var logs = client.Log.GetLogs(Type.all);
var logs = client.Log.GetLogs(Type.error);
var logs = client.Log.GetLogs(Type.info);
```
