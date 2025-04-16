namespace Game.PokerGame;

public enum Suit {
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public enum Rank {
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public class Card(Suit suit, Rank rank)
{
    public Suit Suit { get; set; } = suit;
    public Rank Rank { get; set;} = rank;

    private char GetSuitSymbol() {
        return Suit switch {
            Suit.Hearts => '♥',
            Suit.Diamonds => '♦',
            Suit.Clubs => '♣',
            Suit.Spades => '♠',
            _ => '?'
        };
    }

    private String GetRankString() {
        return Rank switch {
            >= Rank.Two and <= Rank.Ten => ((int)Rank).ToString(),
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            Rank.Ace => "A",
            _ => "?"
        };
    }
    

    public override string ToString() {
        return $"{GetRankString()}{GetSuitSymbol()}";
    }
}