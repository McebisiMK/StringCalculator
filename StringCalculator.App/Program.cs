using System;
using Autofac;
using StringCalculator_Library;
using StringCalculator_Library.Exceptions;

namespace StringCalculator_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var terminator = "Y";
            while (terminator.ToUpper() == "Y")
            {
                try
                {
                    Console.WriteLine("Enter your numbers in string");
                    var input = Console.ReadLine();

                    var container = Container();
                    var stringCalculator = container.Resolve<IStringCalculator>();

                    var sum = stringCalculator.Add(input);
                    Console.WriteLine();
                    Console.WriteLine($"Sum of given number(s): {sum}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine();
                    Console.WriteLine(exception.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Press 'Y' to continue with calculation:");
                terminator = Console.ReadLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static IContainer Container()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<Modules>();

            return containerBuilder.Build();
        }
    }
}
