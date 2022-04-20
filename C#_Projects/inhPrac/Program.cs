#pragma warning disable 8604, 8600, 8601, 8602, 8974

namespace animalProgram {
    class helloworld {
        public static void Main() {
            
            List<Animal> theAnimals = new List<Animal>();

            theAnimals.Add(new Bird("Cardinal", 1, 10, 20));
            theAnimals.Add(new Bird());
            theAnimals.Add(new Mammal("Human", 150, 2, 3));
            theAnimals.Add(new Reptile("Lizard", 5, 5, 15));
            theAnimals.Add(new Animal("Basic Animal", 0));

            foreach(Animal theAnimal in theAnimals){
                Console.WriteLine(theAnimal);
                theAnimal.makeSound();
                
            }

        }

    }
}