using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public interface IEncryptor
    {
        string Map(string s);
        char Map(char s);
    }
}
