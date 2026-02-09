using DotNetEnv;
using GenWikiTests.Structures;

namespace GenWikiTests.Helpers
{
    public static class ApiUtils
    {
        static string BASE_URL = Environment.GetEnvironmentVariable("API_URL");
        private static string WIKI_USER = Environment.GetEnvironmentVariable("WIKI_USER");

        public static async Task<string> GetDebuggingFeaturesWikiTextAsync(string format, string pageTitle, int sectionNumber, string textProp = "wikitext", CancellationToken cancellationToken = default)
        {
            LoadEnvVariables();
            var client = new HttpClient();
            // Per Wikimedia policy: include identifying UA with contact URL/email
            client.DefaultRequestHeaders.UserAgent.ParseAdd(WIKI_USER);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{BASE_URL}?action=parse&format={format}&formatversion=2&page={pageTitle}&prop={textProp}&section={sectionNumber}");

            Console.WriteLine($"Request URL:\n ---- {request.RequestUri}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            ParseResponse apiResponse = System.Text.Json.JsonSerializer.Deserialize<ParseResponse>(content);
            string wikiText = apiResponse.Parse.WikiText;
            Console.WriteLine(content);
            Console.WriteLine($"Extracted wikitext:\n{wikiText}");
            return wikiText;
        }

        public static void LoadEnvVariables()
        {
            string envFileDirectory = DirectoryUtils.GetNthParentDirectory(4);
            Console.WriteLine($"envFileDirectory ------> : {envFileDirectory}");
            Env.Load($"{envFileDirectory}\\.env"); // loads .env from project root
        }
    }
}

