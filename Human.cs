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

        public Human (Human father, Human mother) {
            NR3Generator random = new NR3Generator();
            if (random.Next(2) == 0)
                isMan = true;
            else
                isMan = false;

            areHairDark = InheritGeneFromParents(mother.AreHairDark, father.AreHairDark);
            areHairCurly = InheritGeneFromParents(mother.AreHairCurly, father.AreHairCurly);
            isSkinDark = InheritGeneFromParents(mother.IsSkinDark, father.IsSkinDark);
            areEyesDark = InheritGeneFromParents(mother.AreEyesDark, father.AreEyesDark);
            isTall = InheritGeneFromParents(mother.IsTall, father.IsTall);
        }

        #region Properties
        public bool IsMan { get { return isMan; } }
        public string GetSexString { get { if (isMan == true) return "man"; return "woman"; } }
        public string GetHairTintString { get { if (areHairDark == Genes.Dominant || areHairDark == Genes.Hetero) return "dark"; return "light"; } }
        public string GetHairTypeString { get { if (areHairCurly == Genes.Dominant || areHairCurly == Genes.Hetero) return "curly"; return "straight"; } }
        public string GetSkinToneString { get { if (isSkinDark == Genes.Dominant || isSkinDark == Genes.Hetero) return "dark"; return "light"; } }
        public string GetEyeHueString { get { if (areEyesDark == Genes.Dominant || areEyesDark == Genes.Hetero) return "dark"; return "light"; } }
        public string GetHeightString { get { if (isTall == Genes.Dominant || isTall == Genes.Hetero) return "tall"; return "short"; } }

        public Genes AreHairDark { get { return areHairDark; } }
        public Genes AreHairCurly { get { return areHairCurly; } }
        public Genes IsSkinDark { get { return isSkinDark; } }
        public Genes AreEyesDark { get { return areEyesDark; } }
        public Genes IsTall { get { return isTall; } }
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

        public void RandomProperties () {
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

        public void ConsoleWriteProperties () {
            Console.WriteLine("Sex: " + GetSexString);
            Console.WriteLine("Hair tint: " + GetHairTintString);
            Console.WriteLine("Hair type: " + GetHairTypeString);
            Console.WriteLine("Skin tone: " + GetSkinToneString);
            Console.WriteLine("Eye hue: " + GetEyeHueString);
            Console.WriteLine("Height: " + GetHeightString);
        }

        Genes InheritGeneFromParents (Genes motherGene, Genes fatherGene) {
            if (motherGene == Genes.Dominant && fatherGene == Genes.Dominant)
                return Genes.Dominant;
            else if (motherGene == Genes.Recessive && fatherGene == Genes.Recessive)
                return Genes.Recessive;
            else {
                NR3Generator random = new NR3Generator();
                int randomInt = random.Next(4);
                if (randomInt == 0)
                    return Genes.Recessive;
                else if (randomInt == 1 || randomInt == 2)
                    return Genes.Hetero;
                else
                    return Genes.Dominant;
            }
        }

        Genes RandomGene (int value) {
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


        /// <summary>
        /// Returns true for homozygous
        /// </summary>
        static bool HomoOrHeteroZygous () {
            Console.WriteLine("Should it be homozygous?");
            return Input.YesOrNo();
        }
    }
}
