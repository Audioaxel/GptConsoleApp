using System.Text;

public class OpenAiRequest : IOpenAiRequest
{
    private readonly IConfigData _config;

    public OpenAiRequest(IConfigData config)
    {
        _config = config;
    }

    public async Task<string> SendRequest(string prompt)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", _config.ApiKey);

            var content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \"" + prompt + "\",\"temperature\": 1,\"max_tokens\": 100}",
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
