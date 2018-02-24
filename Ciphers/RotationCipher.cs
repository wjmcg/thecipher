using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public abstract class RotationCipher
    {
        private readonly int offset;
        private readonly char[] lookup;
        private const int maxCharacterValue = 0xFF;  //Cover UTF-8
        private const char errorCharacter = (char) 0x2610;

        public RotationCipher(int offset)
        {
            this.offset = offset;
            lookup = new char[char.MaxValue - 1];
            initialiseLookup();
        }

        public string Map(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char character in s) sb.Append(Map(character));
            return sb.ToString();
        }

        public char Map(char input)
        {
            if (input > maxCharacterValue) return errorCharacter;
            return lookup[input];
        }

        private void initialiseLookup()
        {
            List<char> uppers = new List<char>(maxCharacterValue + 1);
            List<char> lowers = new List<char>(maxCharacterValue + 1);
            List<char> numbers = new List<char>(maxCharacterValue + 1);
            List<char> others = new List<char>(maxCharacterValue + 1);

            List<List<char>> allLists = new List<List<Char>>{uppers, lowers, numbers, others};

            //Sort out the sets which will be rotated.
            for (char c = char.MinValue; c <= maxCharacterValue; c++)  //Covers all UTF-8
            {
                if (char.IsUpper(c)) uppers.Add(c);
                else if (char.IsLower(c)) lowers.Add(c);
                else if (char.IsNumber(c)) numbers.Add(c);
                else others.Add(c);
            }

            //Work through all characters, apply & store rotated value based on sets.
            for (char c = char.MinValue; c <= maxCharacterValue; c++)
            {
                foreach (List<char> subList in allLists)
                {
                    if(subList.Contains(c))
                    {
                        int index = subList.IndexOf(c);
                        index += offset;
                        if (index < 0) index += subList.Count();
                        if (index >= subList.Count()) index -= subList.Count();
                        lookup[c] = subList[index];
                        break;
                    }
                }
            }

        }







    }
}
