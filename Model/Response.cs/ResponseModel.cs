using Newtonsoft.Json;

namespace PMS.Models.ApiResponse
{
    public class Response
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object? data { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? error_status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? statuscode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? is_exist { get; set; }
    }
}