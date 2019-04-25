using System;
using Troschuetz.Random.Generators;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetics {
    class Human {
        public enum Genes {
            Recessive,
            Hetero,
            Dominant
        }
        //test 2
        Genes areHairDark, areHairCurly, isSkinDark, areEyesDark, isTall;
        bool isMan;

        public Human (bool isMan, Genes areHairDark, Genes areHairCurly, Genes isSkinDark, Genes areEyesDark, Genes isTall) {
            this.areHairDark = areHairDark;
            this.areHairCurly = areHairCurly;
            this.isSkinDark = isSkinDark;
            this.areEyesDark = areEyesDark;
            this.isMan = isMan;
            this.isTall = isTall;
        }

        public Human() {
        }

        #region Properties
        public string GetSex { get { if (isMan == true) return "man"; return "woman"; } }
        public string GetHairTint { get { if (areHairDark == Genes.Dominant || areHairDark == Genes.Hetero) return "dark"; return "light"; } }
        public string GetHairType { get { if (areHairCurly == Genes.Dominant || areHairCurly == Genes.Hetero) return "curly"; return "straight"; } }
        public string GetSkinTone { get { if (isSkinDark == Genes.Dominant || isSkinDark == Genes.Hetero) return "dark"; return "light"; } }
        public string GetEyeHue { get { if (areEyesDark == Genes.Dominant || areEyesDark == Genes.Hetero) return "dark"; return "light"; } }
        public string GetHeight { get { if (isTall == Genes.Dominant || isTall == Genes.Hetero) return "tall"; return "short"; } }
#endregion

        public void SetProperties () {
            Console.WriteLine("Should this human be man?");
            if (Input.YesOrNo()) {
                isMan = true;
            }
            else {
                isMan = false;
            }
            Console.WriteLine("Should hair be dark?");
            SetGene(out areHairDark);
            Console.WriteLine("Should hair be curly?");
            SetGene(out areHairCurly);
            Console.WriteLine("Should skin be dark?");
            SetGene(out isSkinDark);
            Console.WriteLine("Should eyes be dark?");
            SetGene(out areEyesDark);
            Console.WriteLine("Should human be tall?");
            SetGene(out isTall);
        }

        public void RandomProperies () {
            int[] values = new int[6];
            NR3Generator random = new NR3Generator();
            areHairDark = RandomGene(random.Next(4));
            areHairCurly = RandomGene(random.Next(4));
            isSkinDark = RandomGene(random.Next(4));
            areEyesDark = RandomGene(random.Next(4));
            isTall = RandomGene(random.Next(4));
            if (random.Next(4) < 2)
                isMan = true;
            else
                isMan = false;
        }

        Genes RandomGene (int value) {
            //int value = random.Next(4);
            Console.WriteLine(value);
            if (value < 1)
                return Genes.Recessive;
            else if (value < 3)
                return Genes.Hetero;
            else
                return Genes.Dominant;
        }

        void SetGene (out Genes gene) {
            if (Input.YesOrNo()) {
                if (HomoOrHeteroZygous()) {
                    //Gene is dominant and homozygous
                    gene = Genes.Dominant;
                } else {
                    //Gene is dominant and heterozygous
                    gene = Genes.Hetero;
                }
            }
            else {
                //Gene is recessive
                gene = Genes.Recessive;
            }
        }

        public void ConsoleWriteProperties () {
            Console.WriteLine("Sex: " + GetSex);
            Console.WriteLine("Hair tint: " + GetHairTint);
            Console.WriteLine("Hair type: " + GetHairType);
            Console.WriteLine("Skin tone: " + GetSkinTone);
            Console.WriteLine("Eye hue: " + GetEyeHue);
            Console.WriteLine("Height: " + GetHeight);
        }

        /// <summary>
        /// Returns true for homozygous
        /// </summary>
        static bool HomoOrHeteroZygous () {
            Console.WriteLine("Should it be homozygous?");
            return Input.YesOrNo();
        }
    }
}
