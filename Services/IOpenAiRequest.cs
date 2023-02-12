public interface IOpenAiRequest
{
    Task<string> SendRequest(string prompt);
}
