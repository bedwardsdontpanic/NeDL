using System;

namespace DI_and_IoC_prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            ProductService productService = new ProductService(logger);
            productService.Log("Hello World!");
        }
    }
}
