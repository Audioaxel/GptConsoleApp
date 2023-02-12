using Microsoft.Extensions.Configuration;

public class ConfigData : IConfigData
{
    private readonly IConfiguration _config;
    
    public ConfigData(IConfiguration config)
    {
        _config = config;
    }
    
    public string ApiKey => _config.GetSection("ApiKeys").GetSection("ApiKey").Value;
}