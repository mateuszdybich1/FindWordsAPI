namespace FindWordsAPI
{
    public class Letters
    {
        private char[] _letters;
        private int _minWordLength = 1;

        private Letters(string letters)
        {
            if (letters == null)
                throw new ArgumentNullException(nameof(letters));

            _letters = letters.ToCharArray().OrderBy(l => l).ToArray();
        }

        public static Letters From(string letters)
        {
            return new Letters(letters);
        }

        public Letters SetMinWordLength(int minWordLength)
        {
            if (minWordLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(minWordLength));

            _minWordLength = minWordLength;
            return this;
        }

        public string[] CreateWords()
        {
            return Permute(new string(_letters)).ToArray();
        }

        private ICollection<string> Permute(string letters, string word = "")
        {
            var result = new List<string>();
            if (!string.IsNullOrEmpty(word) && word.Length >= _minWordLength)
                result.Add(word);

            for (int i = 0; i < letters.Length; i++)
            {
                if (i > 0 && letters[i] == letters[i - 1])
                    continue;

                result.AddRange(Permute(letters.Remove(i, 1), word + letters[i]));
            }

            return result;
        }
    }
}
