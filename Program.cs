using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetics {
    class Program {
        static void Main () {
            int minPeopleInFirstGeneration = 2, maxPeopleInFirstGeneration = 10, minGenerations = 2, maxGenerations = 10;
            float minChildrenPerCouple = 1, maxChildrenPerCouple = 5;
            Generator generator = new Generator();
            Console.WriteLine("Enter number of people in first generation ({0} - {1})", minPeopleInFirstGeneration, maxPeopleInFirstGeneration);
            generator.NumberOfPeopleInFirstGeneration = Input.NumberInt(minPeopleInFirstGeneration, maxPeopleInFirstGeneration);
            Console.WriteLine("Enter number of generations ({0} - {1})", minGenerations, maxGenerations);
            generator.NumberOfGenerations = Input.NumberInt(minGenerations, maxGenerations);
            Console.WriteLine("Enter number of children per couple in each generation ({0} - {1})", minChildrenPerCouple, maxChildrenPerCouple);
            generator.NumberOfChildrenPerCouple = Input.NumberFloat(minChildrenPerCouple, maxChildrenPerCouple);
            Console.WriteLine("Do you want to enter properties of each human manually?");
            generator.ManualPropertiesInput = Input.YesOrNo();

            generator.Start();

            Console.WriteLine("Do you want to see properties of people from all generations?");
            if (Input.YesOrNo())
                generator.ConsoleWritePropertiesOfPeopleFromAllGenerations();
            else
                generator.ConsoleWritePropertiesOfPeopleFromLastGeneration();
            Console.ReadKey();
        }
    }
}
