using System.Text.RegularExpressions;
namespace GenWikiTests.Helpers
{
    public static class TextUtils
    {
        public static string RemoveWikiReferenceToolTip(string text, string marker)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(marker))
                return text ?? string.Empty;

            // Build safe, case-insensitive patterns for the given marker (e.g., "ref")
            string tag = Regex.Escape(marker);

            // 1) Remove self-closing tags: <ref .../>
            string selfClosingPattern = $@"<\s*{tag}\b[^>]*?/>";
            // 2) Remove paired tags with content: <ref ...> ... </ref>
            string pairedPattern = $@"<\s*{tag}\b[^>]*?>(.*?)</\s*{tag}\s*>";
            // 3) Remove dangling open tag to the end of the string: <ref ...> ... (no closing)
            string danglingOpenPattern = $@"<\s*{tag}\b[^>]*?>.*$";

            // Apply repeatedly until no further changes (handles nested/edge cases)
            string before, after = text;
            do
            {
                before = after;

                // Remove self-closing tags
                after = Regex.Replace(after, selfClosingPattern, string.Empty,
                                      RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Remove paired tags (and their content)
                after = Regex.Replace(after, pairedPattern, string.Empty,
                                      RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Remove dangling open tags to end (if any remain)
                after = Regex.Replace(after, danglingOpenPattern, string.Empty,
                                      RegexOptions.IgnoreCase | RegexOptions.Singleline);

            } while (!ReferenceEquals(before, after) && before != after);

            // Collapse leftover whitespace and trim
            after = Regex.Replace(after, @"\s+", " ").Trim();

            return after;
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

