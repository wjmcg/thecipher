using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.Test
{
    [TestClass]
    public class DecryptRotateTests
    {
        IEncryptor ise;

        public DecryptRotateTests()
        {
            ise = new DecryptRotate(3);
        }

        [DataTestMethod]
        [DataRow('H', 'K')]
        [DataRow('E', 'H')]
        [DataRow('L', 'O')]
        [DataRow('O', 'R')]
        public void TestUpperExampleDecrypt(char expected, char input)
        {
            Assert.AreEqual(expected, ise.Map(input), "Upper case test failure.");
        }


        [DataTestMethod]
        [DataRow('h', 'k')]
        [DataRow('e', 'h')]
        [DataRow('l', 'o')]
        [DataRow('o', 'r')]

        public void TestLowerExampleDecrypt(char expected, char input)
        {
            Assert.AreEqual(expected, ise.Map(input), "Upper case test failure.");
        }


        [TestMethod]
        public void TestAllCharactersDecrypt()
        {
            //This just tests no characters cause an error.
            for (char c = char.MinValue; c <= 0xFF; c++)
            {
                char output = ise.Map(c);
                Assert.AreNotEqual(c, output, "Character seems to be encypting to itself.");
            }
        }
    }
}
