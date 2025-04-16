namespace Game;

using Game.PokerGame;


public class Program {
    public static async Task Main() {
        List<string> playerNames1 = ["Player 1", "Player 2", "Player 3", "Player 4", "Player 5", "Player 6", "Player 7", "Player 8"];
        List<string> playerNames2 = ["Player 3", "Player 4", "Player 3", "Player 4", "Player 5", "Player 6", "Player 7", "Player 8"];

        PokerGameSync game = new(playerNames1);        
        PokerGameAsync game2 = new(playerNames2);
        
        // Start both games concurrently
        var game1Task = Task.Run(() => game.Start());
        var game2Task = game2.StartAsync();

        // Start timer for each game
        var stopwatch1 = System.Diagnostics.Stopwatch.StartNew();
        var stopwatch2 = System.Diagnostics.Stopwatch.StartNew();

        // Wait for either game to finish
        var firstFinished = await Task.WhenAny(game1Task, game2Task);

        // Stop timers after game finishes
        if (firstFinished == game1Task)
        {
            stopwatch1.Stop();
            Console.WriteLine($"Game 1 finished first in {stopwatch1.ElapsedMilliseconds} ms");
            game2Task.Wait(); // Wait until the second game finishes
            stopwatch2.Stop();
            Console.WriteLine($"Game 2 ASYNC finished in {stopwatch2.ElapsedMilliseconds} ms");
        }
        else
        {
            stopwatch2.Stop();
            Console.WriteLine($"Game 2 ASYNC finished first in {stopwatch2.ElapsedMilliseconds} ms");
            game1Task.Wait(); // Wait until the first game finishes
            stopwatch1.Stop();
            Console.WriteLine($"Game 1 finished in {stopwatch1.ElapsedMilliseconds} ms");
        }
    }
}
