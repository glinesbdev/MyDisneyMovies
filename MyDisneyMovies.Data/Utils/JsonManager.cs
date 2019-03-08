using MyDisneyMovies.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MyDisneyMovies.Data.Utils
{
    public static class JsonManager
    {
        public static bool ValidJson(string json)
        {
            JSchema schema = JSchema.Parse(json);
            return JObject.Parse(json).IsValid(schema);
        }
    }
}
