using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2C2P.Api.Models
{
    public class ResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("payment")]
        public string Payment { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}