## Poker Game

# ♠️ Poker Dice Game Simulator

A C# console game where multiple players compete to collect all possible poker hand combinations by rolling virtual dice (drawing random cards). Players take turns (or run asynchronously) trying to complete hands like Full House, Straight, and Royal Flush. The one who completes all combinations in the fewest number of tries wins.

---

## 🕹 Game Modes

- **Synchronous Mode**: Players take turns one after another.
- **Asynchronous Mode**: Each player runs in their own task, completing hands concurrently.

Both modes are compared in terms of execution time and total number of tries.

---

## 🧩 Features

- 🎴 Card system with suits and ranks
- 🧠 Hand evaluator for poker combinations
- 👥 Player tracking with progress and tries count
- ⚙️ Two game modes: synchronous and async
- ⏱ Performance comparison with stopwatch timers
- 📊 Final ranking and formatted results

---

## 🚀 How to Run

### Requirements

- [.NET 8.0 SDK or later](https://dotnet.microsoft.com/en-us/download)

### Run the game

```bash
dotnet run


📁 Project Structure

Game.PokerGame/
├── Card.cs // Represents a playing card
├── Deck.cs // Generates and manages deck of cards
├── Player.cs // Stores player info and progress
├── PokerGame.cs // Synchronous game logic
├── PokerGameAsync.cs // Asynchronous game logic
├── PokerHandEvaluator.cs // Evaluates poker hands
├── HandRank.cs // Enum of poker hand combinations
Program.cs // Entry point for running and comparing both games

📌 Future Improvements

Add UI or Web frontend
Multiplayer over network
Save player history and stats
More advanced AI strategies
```
