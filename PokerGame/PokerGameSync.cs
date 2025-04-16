namespace Game.PokerGame;

public class PokerGameSync {
    readonly int TOTAL_CARDS_PER_HAND = 5;
    List<Player> Players{get; set;}    
    private readonly List<HandRank> allCombinations = [.. Enum.GetValues(typeof(HandRank)).Cast<HandRank>()];

    public PokerGameSync(List<string> playerNames) {
        Players = [.. playerNames.Select(name => new Player(name))];
    }

    public void Start() {
        var deck = new Deck();

        
        while (!Players.All(p => p.HasCompletedAllCombinations(allCombinations)))
        {
            foreach (var player in Players)
            {
                if (player.HasCompletedAllCombinations(allCombinations)) continue;

                var hand = deck.GetRandomCards(TOTAL_CARDS_PER_HAND);

                player.Tries++;

                var rank = PokerHandEvaluator.EvaluateHand(hand);


                if (!player.CompletedCombinations.Contains(rank))
                {
                    player.CompletedCombinations.Add(rank);
                }

            }
        }

        this.PrintResults();
    }

    private static void PrintHand(List<Card> hand) {
        foreach (var card in hand) {
            Console.Write($"{card} ");
        }
        Console.WriteLine();
    }

    public static void DisplayTotalTries(int totalTries) {
    string formattedTries = totalTries.ToString("#,0", System.Globalization.CultureInfo.InvariantCulture);

    Console.WriteLine($"Total tries: {formattedTries}");
}


    private void PrintResults() {
        var ranked = Players.OrderBy(p => p.Tries).ToList();
        var totalTries = 0;
        Console.WriteLine("\n🏆 Game Over! Rankings:");

        for (int i = 0; i < ranked.Count; i++) {
            totalTries += ranked[i].Tries;
            Console.WriteLine($"{i + 1}. {ranked[i].Name} - {ranked[i].Tries} tries");
        }
        DisplayTotalTries(totalTries);
    }
}