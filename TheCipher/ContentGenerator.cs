using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciphers;
using System.Net.Http;

namespace TheCipher
{
    public static class ContentGenerator
    {

        public static StringContent MakeJsonPayload(string payload)
        {
            Return ret = new Return();
            ret.Response = payload;
            string json = JsonConvert.SerializeObject(ret, Formatting.Indented);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
