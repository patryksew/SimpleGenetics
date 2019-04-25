using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetics {
    class Generator {
        int numberOfPeopleInFirstGeneration, numberOfGenerations;
        float numberOfChildrenPerCouple;
        bool manualPropertiesInput;
        Human[] people;

        public int NumberOfPeopleInFirstGeneration { get => numberOfPeopleInFirstGeneration; set => numberOfPeopleInFirstGeneration = value; }
        public int NumberOfGenerations { get => numberOfGenerations; set => numberOfGenerations = value; }
        public float NumberOfChildrenPerCouple { get => numberOfChildrenPerCouple; set => numberOfChildrenPerCouple = value; }
        public bool ManualPropertiesInput { get => manualPropertiesInput; set => manualPropertiesInput = value; }

        public void Start() {
            people = new Human[numberOfPeopleInFirstGeneration];
            if (manualPropertiesInput) {
                for (int i = 0; i < numberOfPeopleInFirstGeneration; i++) {
                    people[i] = new Human();
                    Console.WriteLine("\nEnter properties of human no. {0}", i + 1);
                    people[i].SetProperties();
                }
            }
            else {
                for (int i = 0; i < numberOfPeopleInFirstGeneration; i++) {
                    people[i] = new Human();
                    people[i].RandomProperies();
                }
            }
        }

        public void ConsoleWriteProperties() {
            for (int i = 0; i < people.Length; i++) {
                Console.WriteLine("\nProperties of human no {0}:", i);
                people[i].ConsoleWriteProperties();
            }
        }
    }
}