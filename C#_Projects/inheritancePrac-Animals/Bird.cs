namespace animalProgram {

    class Bird: Animal {  // base class (parent) 
        public double wingSpan { get; set; }
        public double flightSpeed { get; set; }

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

        public override void makeSound() {
            Console.WriteLine("cacaw");
        }
    }    
}