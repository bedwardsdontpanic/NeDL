#pragma warning disable 8604, 8600, 8601, 8602, 8974

namespace animalProgram {
    class helloworld {
        public static void Main() {
            List<IAnimal> theAnimals = new List<IAnimal>();
            theAnimals.Add(new Bird());
            theAnimals.Add(new Mammal());
            theAnimals.Add(new Reptile());
            
            foreach(IAnimal theAnimal in theAnimals){
                theAnimal.makeSound();
                theAnimal.runAway();
            }
        
        }

    }
}