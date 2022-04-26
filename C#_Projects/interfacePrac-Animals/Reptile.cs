namespace animalProgram {

    class Reptile: IAnimal, IRunAway {  // base class (parent) 


        public Reptile() {

        }

        public void makeSound() {
                Console.WriteLine("ssssss");
        }

        public void runAway(){
            Console.WriteLine("slithering away");
        }
    }    
}