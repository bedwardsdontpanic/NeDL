#pragma warning disable 8604, 8600

namespace HelloWorld {
    class Program {

        static void Main(string[] args) { 
            
            string writeText = "Hello";
            File.WriteAllText("Test.txt", writeText);
        
        }

    }

}