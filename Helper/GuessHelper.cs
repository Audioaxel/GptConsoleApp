public static class GuessHelper
{
    public static string GuessCommand(string raw)
    {
        System.Console.WriteLine("===> OpenAi: ");
        UiHelper.WriteLine(EColors.Yellow, raw);

        return raw.Substring(raw.LastIndexOf('\n') + 1);
    }

}