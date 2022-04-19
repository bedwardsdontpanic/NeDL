using System;

namespace tradingCardProgram {
  class Program {
    static void Main(string[] args) { 
        
        List<TradingCard> myCards = new List<TradingCard>();
       
        myCards.Add(new TradingCard("Michael Jordan", 5000));
        myCards.Add(new TradingCard("Tom Brady", 3000));
        
        foreach(TradingCard theCard in myCards) {
            Console.WriteLine(theCard.ToString());
        }
    }


  }
}