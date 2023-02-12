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
            
            
            if (args.Length <= 0){
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Stell ne Frage du Lappn");
                Console.ResetColor();
                return;
            }

            
            var prompt =  args[0] + ". please put the command after the last line";
            var request = serviceProvider.GetRequiredService<IOpenAiRequest>();
            string responseString = await request.SendRequest(prompt);

            try
            {
                var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);
                string guess = GuessCommand(dyData!.choices[0].text);

                TextCopy.ClipboardService.SetText(guess);

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"Copied to Clipboard: {guess}");
                Console.ResetColor();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"===> Could not deserialize the JSON: {e.Message}");
                Console.ResetColor();
            }


            // Scheiß async...
            static string GuessCommand(string raw)
            {
                System.Console.WriteLine("===> OpenAi: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(raw);
                Console.ResetColor();

                return raw.Substring(
                    raw.LastIndexOf('\n') + 1
                    );
            }
        }
    }
}