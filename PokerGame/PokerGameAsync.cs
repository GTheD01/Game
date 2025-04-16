namespace Game.PokerGame;

public class PokerGameAsync {
    readonly int TOTAL_CARDS_PER_HAND = 5;
    private readonly List<Player> players;
    private readonly List<HandRank> allCombinations = [.. Enum.GetValues(typeof(HandRank)).Cast<HandRank>()];

    public PokerGameAsync(List<string> playerNames) {
        players = [.. playerNames.Select(name => new Player(name))];
    }

    public async Task StartAsync() {
        var tasks = players.Select(player => Task.Run(() => PlayUntilComplete(player)));

        await Task.WhenAll(tasks);

        PrintResults();
    }

    private void PlayUntilComplete(Player player) {
        var deck = new Deck();

        while (!player.HasCompletedAllCombinations(allCombinations)) {
            var hand = deck.GetRandomCards(TOTAL_CARDS_PER_HAND);
            var rank = PokerHandEvaluator.EvaluateHand(hand);
            player.Tries++;
            player.CompletedCombinations.Add(rank);
        }
    }

    public static void DisplayTotalTries(int totalTries)
{
    string formattedTries = totalTries.ToString("#,0", System.Globalization.CultureInfo.InvariantCulture);

    Console.WriteLine($"Total tries: {formattedTries}");
}


    private void PrintResults() {
        var ranked = players.OrderBy(p => p.Tries).ToList();
        var totalTries = 0;
        Console.WriteLine("\n🏆 Final Rankings:");
        for (int i = 0; i < ranked.Count; i++) {
            totalTries += ranked[i].Tries;
            Console.WriteLine($"{i + 1}. {ranked[i].Name} - {ranked[i].Tries} tries");
        }
        DisplayTotalTries(totalTries);
    }
}