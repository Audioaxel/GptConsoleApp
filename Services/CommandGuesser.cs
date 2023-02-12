public static class CommandGuesser
{
    public static string GuessCommand(string raw)
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