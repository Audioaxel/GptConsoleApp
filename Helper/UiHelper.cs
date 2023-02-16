public static class UiHelper
{
    public static void WriteLine(EColors color, string line)
    {
        switch (color)
        {
            case EColors.Reset:
                Console.ResetColor();
                break;

            case EColors.White:
                Console.ForegroundColor = ConsoleColor.White;
                break;

            case EColors.Green:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            
            case EColors.Yellow:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case EColors.Red:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case EColors.Blue:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

            default:
                Console.ResetColor();
                break;
        }

        System.Console.WriteLine(line);
        Console.ResetColor();
    }
}