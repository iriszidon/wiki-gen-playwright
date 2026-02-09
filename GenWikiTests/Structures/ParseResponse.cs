using System.Text.Json.Serialization;

namespace GenWikiTests.Structures
{
    public class ParseResponse
    {
        [JsonPropertyName("parse")]
        public ParseData Parse { get; set; }
    }
}

