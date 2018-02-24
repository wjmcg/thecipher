using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ciphers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace TheCipher
{
    public static class RunCipher
    {
        [FunctionName("Run")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger for encryption/decryption.");

            //Process input


            Mode m = Mode.Unset;
            string data = null;

            IEnumerable<KeyValuePair<string,string>> inputs = req.GetQueryNameValuePairs();

            foreach(KeyValuePair<string,string> kvp in inputs)
            {
                if (kvp.Key.Equals("encrypt",StringComparison.InvariantCultureIgnoreCase))
                {
                    log.Info("Encryption specified.");
                    data = kvp.Value;
                    m = Mode.Encrypt;
                    break;
                }

                if (kvp.Key.Equals("decrypt", StringComparison.InvariantCultureIgnoreCase))
                {
                    log.Info("Decryption specified.");
                    data = kvp.Value;
                    m = Mode.Decrypt;
                    break;
                }

            }

            dynamic body = await req.Content.ReadAsAsync<object>();

            //Execute
            IEncryptor ise;

            switch(m)
            {
                case Mode.Encrypt:
                    ise = new EncryptRotate(Constants.Rotation);
                    break;
                case Mode.Decrypt:
                    ise = new DecryptRotate(Constants.Rotation);
                    break;
                case Mode.Unset:
                    log.Info("Returning advice string.");
                    ise = new NullEncryptor("Please use ?encrypt=[StringToEncrypt] or ?decrypt=[StringToDecrypt]");
                    break;
                default:
                    log.Error("Encryption mode switch not recognised.");
                    throw new NotImplementedException("Crypto mode not valid.");
            }


            string processedString = ise.Map(data);

            StringContent sc = ContentGenerator.MakeJsonPayload(processedString);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = sc
            };
        }



        

    }
}
