namespace animalProgram {

    class Mammal: IAnimal, IRunAway {  // base class (parent) 

        public Mammal() {

        }

        public void makeSound() {
            Console.WriteLine("Ahhh");
        }

        public void runAway(){
            Console.WriteLine("sprinting away");
        }
    }    
}