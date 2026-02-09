using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Net;

public static class JsonToHtmlConverterUtil
{
    /// <summary>
    /// Parses the MediaWiki "parse" JSON payload, decodes its HTML, strips tags,
    /// and returns plain text. Expects JSON with shape: { "parse": { "text": "<html...>" } }
    /// </summary>
    /// <param name="json">The JSON string returned by MediaWiki parse API (section response).</param>
    /// <returns>Plain text extracted from the HTML.</returns>
    public static string ExtractPlainTextFromParseJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return string.Empty;

        using var doc = JsonDocument.Parse(json);

        if (!doc.RootElement.TryGetProperty("parse", out var parseEl) ||
            !parseEl.TryGetProperty("text", out var textEl))
        {
            return string.Empty;
        }

        // The "text" property contains HTML but often still entity-escaped (e.g., &lt;div&gt;).
        var htmlEncoded = textEl.GetString() ?? string.Empty;

        // 1) Decode HTML entities to get real HTML
        var html = WebUtility.HtmlDecode(htmlEncoded);

        // 2) Strip tags → plain text
        var text = StripHtmlToPlainText(html);

        return text;
    }

    /// <summary>
    /// Strips HTML tags and normalizes whitespace. Also decodes entities again just in case
    /// the HTML contained nested encodings after removal.
    /// </summary>
    private static string StripHtmlToPlainText(string html)
    {
        if (string.IsNullOrEmpty(html)) return string.Empty;

        // Remove script/style contents first (conservative)
        html = Regex.Replace(html, "<(script|style)[^>]*>.*?</\\1>", " ", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        // Remove all remaining tags
        var noTags = Regex.Replace(html, "<[^>]+>", " ");

        // Decode any remaining HTML entities
        var decoded = WebUtility.HtmlDecode(noTags);

        // Collapse whitespace
        var normalized = Regex.Replace(decoded, @"\s+", " ").Trim();

        return normalized;
    }
}
