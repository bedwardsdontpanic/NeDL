namespace animalProgram {

    class Reptile: Animal {  // base class (parent) 
        protected double tongueLength;  
        protected double avgBodyTemp;

        public Reptile(string newAnimal, double newWeight, double newavgBodyTemp, double newtongueLength) {
            animalName = newAnimal;
            animalWeight = newWeight;
            avgBodyTemp = newavgBodyTemp;
            avgBodyTemp = newtongueLength;
        }

        public Reptile() {
            avgBodyTemp = -1;
            tongueLength = -1;
        }

        public override string ToString() {
            return "Name: " + animalName + ", Weight: " + animalWeight + " lbs, tongueLength: " + 4 + " inches, average body temp: " + avgBodyTemp + " degrees C";
        }
    }    
}