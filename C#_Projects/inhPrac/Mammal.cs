namespace animalProgram {

    class Mammal: Animal {  // base class (parent) 
        protected double numLegs;  
        protected double furLength;

        public Mammal(string newAnimal, double newWeight, double newfurLength, double newnumLegs) {
            animalName = newAnimal;
            animalWeight = newWeight;
            furLength = newfurLength;
            numLegs = newnumLegs;
        }

        public Mammal() {
            numLegs = -1;
            furLength = -1;
        }

        public override string ToString() {
            return "Name: " + animalName + ", Weight: " + animalWeight + " lbs, numLegs: " + numLegs + ", average fur length: " + furLength + " inches";
        }
    }    
}