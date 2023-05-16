using rockpaperscissor;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Rock, Paper, Scissor");
        Console.WriteLine("Built in C# (for learning purpose)");

        Game game = new Game();
        game.Play();


        Console.ReadKey();
    }
}