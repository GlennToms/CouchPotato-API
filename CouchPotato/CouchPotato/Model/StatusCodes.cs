using Newtonsoft.Json;

namespace CouchPotato.Model
{
    public class StatusCodes
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("empty")]
        public bool IsEmpty { get; set; }

        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        public override string ToString()
        {
            return IsSuccess.ToString();
        }
    }
}