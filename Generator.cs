using System;
using Troschuetz.Random.Generators;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetics {
    class Generator {
        int numberOfPeopleInFirstGeneration, numberOfGenerations;
        float numberOfChildrenPerCouple;
        bool manualPropertiesInput;
        Human[][] people;

        public int NumberOfPeopleInFirstGeneration { get => numberOfPeopleInFirstGeneration; set => numberOfPeopleInFirstGeneration = value; }
        public int NumberOfGenerations { get => numberOfGenerations; set => numberOfGenerations = value; }
        public float NumberOfChildrenPerCouple { get => numberOfChildrenPerCouple; set => numberOfChildrenPerCouple = value; }
        public bool ManualPropertiesInput { get => manualPropertiesInput; set => manualPropertiesInput = value; }

        public void Start() {
            people = new Human[numberOfGenerations][];
            people[0][numberOfPeopleInFirstGeneration] = new Human();
            if (manualPropertiesInput) {
                for (int i = 0; i < numberOfPeopleInFirstGeneration; i++) {
                    people[0][i] = new Human();
                    Console.WriteLine("\nEnter properties of human no. {0}", i + 1);
                    people[0][i].SetProperties();
                }
            }
            else {
                for (int i = 0; i < numberOfPeopleInFirstGeneration; i++) {
                    people[0][i] = new Human();
                    people[0][i].RandomProperties();
                }
            }
        }

        public void GenerateAllGenerations () {
            NR3Generator random = new NR3Generator();
            for (int generationNo = 1; generationNo < people.Length; generationNo++) {
                List<Human> manList, womanList;
                manList = new List<Human>();
                womanList = new List<Human>();
                for (int HumanNo = 0; HumanNo < people[generationNo-1].Length; HumanNo++) {
                    if (people[generationNo-1][HumanNo].IsMan == true)
                        manList.Add(people[generationNo-1][HumanNo]);
                    else
                        womanList.Add(people[generationNo-1][HumanNo]);
                    if(manList.Count == 0 || womanList.Count == 0) {
                        Console.WriteLine("Unfortunatly, there are only people of one sex in last generation" +
                            "\nPress any key to exit");
                        Console.ReadKey();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
                for (int HumanNo = 0; HumanNo < people[generationNo].Length; HumanNo++) {
                    Human mother, father;
                    mother = womanList[random.Next(womanList.Count)];
                    father = manList[random.Next(manList.Count)];
                    people[generationNo][HumanNo] = new Human(father, mother);
                }
            }
        }

        public void ConsoleWritePropertiesOfPeopleFromLastGeneration() {
            Console.WriteLine("Properties of people from last generation: ");
            for (int i = 0; i < people[numberOfGenerations].Length; i++) {
                Console.WriteLine("\nProperties of human no {0}:", i);
                people[0][i].ConsoleWriteProperties();
            }
        }

        public void ConsoleWritePropertiesOfPeopleFromAllGenerations () {
            for (int i = 0; i < people.Length; i++) {
                Console.WriteLine("Properties of people from generation no. " + i);
                for (int j = 0; j < people[i].Length; j++) {
                    Console.WriteLine("\nProperties of human no {0}:", j);
                    people[i][j].ConsoleWriteProperties();
                }
            }
        }
    }
}