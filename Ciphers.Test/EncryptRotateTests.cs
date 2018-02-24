using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciphers.Test
{
    [TestClass]
    public class EncryptRotateTests
    {
        IEncryptor ise;

        [TestInitialize]
        public void TestInit()
        {
            ise = new EncryptRotate(3);
        }

        [DataTestMethod]
        [DataRow('H', 'K')]
        [DataRow('E', 'H')]
        [DataRow('L', 'O')]
        [DataRow('O', 'R')]
        public void TestUpperExampleEncrypt(char input, char expected)
        {
            Assert.AreEqual(expected, ise.Map(input), "Upper case test failure.");
        }


        [DataTestMethod]
        [DataRow('h', 'k')]
        [DataRow('e', 'h')]
        [DataRow('l', 'o')]
        [DataRow('o', 'r')]
        public void TestLowerExampleEncrypt(char input, char expected)
        {
            Assert.AreEqual(expected, ise.Map(input), "Upper case test failure.");
        }


        [TestMethod]
        public void TestAllCharactersEncrypt()
        {
            //This just tests no characters cause an error.
            for (char c = char.MinValue; c <= char.MaxValue; c++)
            {
                char output = ise.Map(c);
                Assert.AreNotEqual(c, output, "Character seems to be encypting to itself.");
            }
        }


    }
}
