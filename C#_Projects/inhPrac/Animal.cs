namespace animalProgram {
    class Animal {  // base class (parent) 
        protected string animalName;  
        protected double animalWeight;
        public string getAnimalName() {
            return animalName; 
        }

        public void setAnimalName (string newName) {
            animalName = newName;
        }

        public double getWeight() {
            return animalWeight; 
        }

        public void setWeight (double newWeight) {
            animalWeight = newWeight;
        }

        public Animal(string newAnimal, double newWeight) {
            animalName = newAnimal;
            animalWeight = newWeight;
        }

        public Animal() {
            animalName = "";
            animalWeight = -1;
        }


        public override string ToString() {
            return "Name: " + animalName + ", Weight: " + animalWeight;
        }
    }
}