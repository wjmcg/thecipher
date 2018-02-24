using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ciphers
{
    public class Return
    {

        private string data;

        public string Response
        {
            get { return data; }
            set {
                data = value;
                ResponseUrlFriendly = HttpUtility.UrlEncode(data);
            }
        }

        public string ResponseUrlFriendly { get; set; }
    }
}
