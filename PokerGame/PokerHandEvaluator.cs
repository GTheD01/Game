namespace Game.PokerGame;

public enum HandRank {
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFlush
}

public class PokerHandEvaluator {
    public static HandRank EvaluateHand(List<Card> hand) {
        var rankGroups = hand.GroupBy(c => c.Rank).ToList();
        var suitGroups = hand.GroupBy(c => c.Suit).ToList();

        if (IsRoyalFlush(hand)) {
            return HandRank.RoyalFlush;
        }
        if (IsStraightFlush(hand)) {
            return HandRank.StraightFlush;
        }
        if (rankGroups.Any(g => g.Count() == 4)) {
            return HandRank.FourOfAKind;
        }
        if (rankGroups.Any(g => g.Count() == 3) && rankGroups.Any(g => g.Count() == 2)) {
            return HandRank.FullHouse;
        }
        if (suitGroups.Count() == 1) {
            return HandRank.Flush;
        }
        if (IsStraight(hand)) {
            return HandRank.Straight;
        }
        if (rankGroups.Any(g => g.Count() == 3)) {
            return HandRank.ThreeOfAKind;
        }
        if (rankGroups.Count(g => g.Count() == 2) == 2) {
            return HandRank.TwoPair;
        }
        if (rankGroups.Any(g => g.Count() == 2)) {
            return HandRank.OnePair;
        }
        return HandRank.HighCard;
    }

    private static bool IsRoyalFlush(List<Card> hand) {
        return IsStraightFlush(hand) && hand.All(c => c.Rank >= Rank.Ten);
    }

    private static bool IsStraightFlush(List<Card> hand) {
      return IsFlush(hand) && IsStraight(hand);
    }

    private static bool IsStraight(List<Card> hand) {
        var ranks = hand.Select(c => (int)c.Rank).OrderBy(r => r).ToList();
        for (int i = 1; i < ranks.Count; i++) {
            if (ranks[i] != ranks[i - 1] + 1) {
                return false;
            }
        }
        return true;
    }

    private static bool IsFlush(List<Card> hand) {
        return hand.GroupBy(c => c.Suit).Count() == 1;
    }
}