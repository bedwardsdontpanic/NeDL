using System;

namespace helloWorld
{
  class TradingCard
    {        
        // Two pieces of data are being stored for each object.  
        // cardName is the restaurant name.  To show the difference in how values can be stored,
        // cardName will be an instance variable.
        // value is the restaurant rating.  To show the difference in how values can be stored,
        // value will be an automatic property.

        // This is the instance variable so it must be declared.  It's private so only methods of the 
        // object can access it.
        private string cardName;  // restaurant name

        // This is the automatic property variable.  The get and set methods are being created too.
        public double value  // property
            { get; set; }
        

        // This is the default constructor when no values are being passed.
        public TradingCard () {
            cardName = null;
            value = -1;
        }

        // This is the constructor when two values are passed.
        public TradingCard (string newCard, double newRating) {
            cardName = newCard;
            value = newRating;
        }
        
        //  Since cardName is not defined as a property, we need to create the get and set mehtods
        //  for it.
        public string getName() {
            return cardName; 
        }  

        public void setName (string newName) {
            cardName = newName;
        }


        // This overrides ToString so an object can be printed out with the WriteLine.

        public override string ToString() {
            return "Card: " + cardName + ", value: " + value;
        }

        public TradingCard getNewCard() {
            TradingCard theCard = new TradingCard();
            
            Console.Write("Card name: ");
            string cardName = Console.ReadLine();
            
            Console.Write("Card Value: ");
            string valueInput = Console.ReadLine();
            double cardValue = Convert.ToInt16(valueInput);
            
            theCard.cardName = cardName;
            theCard.value = cardValue;

            return theCard;
        }

    }
}