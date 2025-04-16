namespace Game.PokerGame;

public class Player(string name)
{
    public string Name { get; } = name;
    public int Tries { get; set; } = 0;

    public HashSet<HandRank> CompletedCombinations {get; set;} = [];

    public bool HasCompletedAllCombinations(IEnumerable<HandRank> allCombos) {
        return CompletedCombinations.IsSupersetOf(allCombos);
    }

}