namespace Game.PokerGame;

public class Deck {
    private List<Card> cards;
    private readonly Random random = new();

    public Deck() {
        cards = GenerateDeck();
    }

    public List<Card> GetRandomCards(int count) {
        var hand = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            if (cards.Count == 0) cards = GenerateDeck();
            int index = random.Next(cards.Count);
            hand.Add(cards[index]);
            cards.RemoveAt(index);
        }
        return hand;
    }

    private static List<Card> GenerateDeck() {
        var deck = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                    deck.Add(new Card (suit, rank ));
            }
        }
        return deck;
    }

    public static void PrintCards(List<Card> cards) {
        foreach (Card card in cards) {
            Console.WriteLine(card);
        }
    }
}