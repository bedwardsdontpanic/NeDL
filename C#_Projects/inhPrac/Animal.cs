namespace animalProgram {
    class Animal {  // base class (parent) 
        public string animalName;  
        public double animalWeight;
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

        public virtual void makeSound() {
            Console.WriteLine("generic sound");
        }
    }
}