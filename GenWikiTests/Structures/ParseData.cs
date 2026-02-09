using System.Text.Json.Serialization;
namespace GenWikiTests.Structures
{
    public class ParseData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public int PageId { get; set; }

        [JsonPropertyName("wikitext")]
        public string WikiText { get; set; }
    }
}
