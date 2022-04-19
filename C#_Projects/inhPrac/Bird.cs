namespace animalProgram {

    class Bird: Animal {  // base class (parent) 
        protected double wingSpan;  
        protected double flightSpeed;

        public Bird(string newAnimal, double newWeight, double newFlightSpeed, double newWingSpan) {
            animalName = newAnimal;
            animalWeight = newWeight;
            flightSpeed = newFlightSpeed;
            wingSpan = newWingSpan;
        }

        public Bird() {
            flightSpeed = -1;
            wingSpan = -1;
        }

        public override string ToString() {
            return "Name: " + animalName + ", Weight: " + animalWeight + " lbs, Wingspan: " + wingSpan + " inches, flight speed: " + flightSpeed +" MPH";
        }
    }    
}