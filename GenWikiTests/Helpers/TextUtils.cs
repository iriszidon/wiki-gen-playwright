namespace GenWikiTests.Helpers
{
    public static class TextUtils
    {
        /// <summary>
        /// Normalizes text by trimming whitespace and converting to lowercase.
        /// </summary>
        public static string NormalizeText(string text)
        {
            if (text == null) return string.Empty;
            return text.Trim().ToLowerInvariant();
        }

        public static string NormalizeTextWithCharsOnly(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            var sb = new System.Text.StringBuilder(text.Length);

            foreach (var ch in text)
            {
                if (char.IsLetter(ch) || char.IsWhiteSpace(ch))
                {
                    sb.Append(ch);
                }

                else
                {
                    sb.Append(' '); // Replace non-letter chars with space to preserve word boundaries
                }
            }

            // Trim edges and lowercase; keeps only alphabet characters and whitespace
            return sb.ToString().Trim().ToLowerInvariant();
        }
    }
}

