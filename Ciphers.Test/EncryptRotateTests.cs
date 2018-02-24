using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciphers.Test
{
    [TestClass]
    public class EncryptRotateTests
    {
        static IEncryptor ise;

        public EncryptRotateTests()
        {
            ise = new EncryptRotate(3);
        }

        [DataTestMethod]
        [DataRow('H', 'K')]
        [DataRow('E', 'H')]
        [DataRow('L', 'O')]
        [DataRow('O', 'R')]
        public static void TestUpperExampleEncrypt(char input, char expected)
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
            for (char c = char.MinValue; c <= 0xFF; c++)
            {
                char output = ise.Map(c);
                Assert.AreNotEqual(c, output, "Character seems to be encypting to itself.");
            }
        }


        [TestMethod]
        public void TestUniqueEncrypt()
        {
            //Check that nothing is repeated in the output.

            HashSet<char> output = new HashSet<char>();

            for (char c = char.MinValue; c <= 0xFF; c++) output.Add(ise.Map(c));

            Assert.AreEqual(0xFF + 1, output.Count, "Non-unique encryption.");
        }

        [TestMethod]
        public void TestEncryptInvalid()
        {
            char expected = (char) 0x2610;
            Assert.AreEqual(expected, ise.Map((char)0xFFFF), "Invlid character removal fails.");
        }


        [TestMethod]
        public void TestEncryptAllUpper()
        {
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string expected = "DEFGHIJKLMNOPQRSTUVWXYZABC";
            Assert.AreEqual(expected, ise.Map(input), "Upper all fails.");
        }

        [TestMethod]
        public void TestEncryptAllLower()
        {
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLowerInvariant();
            string expected = "DEFGHIJKLMNOPQRSTUVWXYZABC".ToLowerInvariant();
            Assert.AreEqual(expected, ise.Map(input), "Lower all fails.");
        }

    }
}
