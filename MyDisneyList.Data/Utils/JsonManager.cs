using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyList.Data.Utils
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
