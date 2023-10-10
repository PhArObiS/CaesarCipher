using static CaesarCipherJan19.Caesar;

const string line = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
const string title = "  \\   MY CAESAR CIPHER   \\ ";
byte placement = (byte)((Console.WindowWidth / 3) - (line.Length / 3) - 30);

DisplayTitle($"{line}\n", placement, 3, ConsoleColor.Cyan);
DisplayTitle($"{title}\n", placement, 4, ConsoleColor.Cyan);
DisplayTitle($"{line}\n", placement, 5, ConsoleColor.Cyan);

do
{
    ChooseOption();
    ThankYou();
} while (Restart);