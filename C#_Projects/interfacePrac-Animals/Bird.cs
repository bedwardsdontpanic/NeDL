namespace animalProgram {

    class Bird: IAnimal, IRunAway {

        public Bird() {

        }

        public void makeSound() {
            Console.WriteLine("cacaw");
        }

        public void runAway(){
            Console.WriteLine("flying away");
        }
    }    
}