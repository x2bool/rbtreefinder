using System;

namespace RbTreeFinder.Tests
{
    public class StringGenerator
    {
        private readonly string _alphabet;
        private readonly Random _random;

        public StringGenerator(string alphabet = "0123456789abcdef")
        {
            _alphabet = alphabet;
            _random = new Random();
        }

        public string GenerateString(int minLength = 1, int maxLength = 100)
        {
            var length = _random.Next(1, maxLength + 1);
            var buffer = new char[length];

            for (int i = 0; i < length; i++)
            {
                buffer[i] = _alphabet[_random.Next(0, _alphabet.Length)];
            }

            return new string(buffer);
        }
    }
}