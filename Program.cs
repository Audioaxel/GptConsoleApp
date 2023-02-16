using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace gpt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            
            
            if (args.Length <= 0) {
                UiHelper.WriteLine(EColors.Red, "Stell ne Frage du Lappn;");
                return;
            }
            
            var prompt =  args[0] + ". please put the command after the last line";
            var request = serviceProvider.GetRequiredService<IOpenAiRequest>();

            string responseString = await request.SendRequest(prompt);

            try
            {
                var rootData = JsonConvert.DeserializeObject<Root>(responseString);
                
                string guess = GuessHelper.GuessCommand(rootData.choices.First().text);

                TextCopy.ClipboardService.SetText(guess);

                UiHelper.WriteLine(EColors.Green, $"Copied to Clipboard: {guess}");
            }
            catch(Exception e)
            {
                UiHelper.WriteLine(EColors.Red, $"===> Could not deserialize JSON: {e.Message}");
            }
        }
    }
}