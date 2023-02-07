using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOPPractice
{
    public class card
    {
        protected int number;
        protected string colour;

        public card(int Num, string Col)
        {
            this.number = Num;
            this.colour = Col;
        }

        public virtual void Constructor(int Num, string Col)
        {
            this.number = Num;
            this.colour = Col;
        }

        public int GetNumber
        {
            get { return number; }
        }

        public string GetColour
        {
            get { return colour; }
        }
    }

    public class Balloon
    {
        protected int health;
        protected string colour;
        protected string defence;

        public Balloon(string Col, string Def)
        {
            this.health = 100;
            this.colour = Col;
            this.defence = Def;
        }

        private void Constructor(string Col, string Def)
        {
            this.health = 100;
            this.colour = Col;
            this.defence = Def;
        }

        public string GetDefenceNumber
        {
            get { return defence; }
        }

        public int ChangeHealth
        {
            set { health += value; }
        }

        public bool CheckHealth
        {
            get { if(health > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }

    public class Character
    {
        protected string Name;
        protected int XCoordinate;
        protected int YCoordinate;

        public Character(string Nom, int X, int Y)
        {
            this.Name = Nom;
            this.XCoordinate = X;
            this.YCoordinate = Y;
        }

        private void Constructor(string Nom, int X, int Y)
        {
            this.Name = Nom;
            this.XCoordinate = X;
            this.YCoordinate = Y;
        }

        public string GetName
        {
            get { return Name; }
        }

        public int GetX
        {
            get { return XCoordinate; }
        }

        public int GetY
        {
            get { return YCoordinate; }
        }

        public string ChangePosition
        {
            set
            {
                string[] coords = value.Split(',');

                XCoordinate += Int32.Parse(coords[0]);
                YCoordinate += Int32.Parse(coords[1]);
            }
        }
    }

    internal class Program
    {
        static int ChooseCards(int[] Q)
        {
            Console.WriteLine("Enter the position of card: ");
            int q = Int32.Parse(Console.ReadLine());
            int count = 0;

            foreach (int index in Q)
            {
                if (index == 0)
                {
                    count += 1;
                }

                else
                {
                    break;
                }
            }

            return count;
        }

        static Balloon Defend(Balloon Q)
        {
            Console.WriteLine("Enter opponent strength: ");
            int opp = Int32.Parse(Console.ReadLine());
            Q.ChangeHealth = -opp;
            Console.WriteLine(Q.GetDefenceNumber);
            if (Q.CheckHealth == true)
            {
                Console.WriteLine("No health remaining");
            }
            else
            {
                Console.WriteLine("Health remaining");
            }

            return Q;
        }

        

        static void Main(string[] args)
        {
            Console.WriteLine("OOP1");

            /*
             * CARDS MAIN

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = Path.Combine(docPath, "Academic/Computing/C#/CardValues.txt");
            StreamReader input = new StreamReader(docPath);

            string[] lines = File.ReadAllLines(docPath);
            int[] index = new int[30];
            for (int i = 0; i < index.Length; i++)
            {
                index[i] = 0;
            }

            int[] carry = new int[4];

            card[] Player1 = new card[10];

            for(int i = 0; i <= 4; i++)
            {
                ChooseCards(index);
                Console.WriteLine("Enter Index again: ");
                int carr = Int32.Parse(Console.ReadLine());
            }

            foreach(int v in carry)
            {
                Console.WriteLine(lines[2 * v]);
                Console.WriteLine(lines[(2 * v) + 1]);
            }

            */

            Console.WriteLine("OOP2");

            /*
             * BALLOONS MAIN

            Console.WriteLine("Enter Defence Item: ");
            string def = Console.ReadLine();
            Console.WriteLine("Enter Colour Item: ");
            string col = Console.ReadLine();

            Balloon Bloon = new Balloon(def, col);

            Defend(Bloon);

            */

            Console.WriteLine("OOP3");

            Character[] Chars = new Character[10];

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = Path.Combine(docPath, "Academic/Computing/C#/Characters.txt");

            string[] lines = File.ReadAllLines(docPath);

            for (int i = 1; i <= 11; i++)
            {
                string c1 = lines[3*(i)-2];
                int c2 = Int32.Parse(lines[3 * (i) - 1]);
                int c3 = Int32.Parse(lines[3 * (i)]);

                Chars[i - 1] = new Character(c1, c2, c3);
            }
            bool check = true;

            do
            {
                Console.WriteLine("Search name: ");
                string search = Console.ReadLine();
                try
                {
                    int index = Array.FindIndex(Chars, (Character) => (Character.GetName == search));
                    Console.WriteLine("index = " + index);

                    Console.WriteLine("Enter Movement: ");
                    string move = Console.ReadLine();
                    Character s = Array.Find(Chars, (Character) => (Character.GetName == search));

                    if (move == "A")
                    {
                        s.ChangePosition = "-1,0";
                    }
                    else if (move == "W")
                    {
                        s.ChangePosition = "0,1";
                    }
                    else if (move == "S")
                    {
                        s.ChangePosition = "0,-1";
                    }
                    else if (move == "D")
                    {
                        s.ChangePosition = "1,0";
                    }
                    Console.WriteLine(search + " has changed coordinates to X = " + s.GetX + " and Y = " + s.GetY);
                    check = false;
                }
                catch
                {
                    Console.WriteLine("Could not find item in array");
                }

            } while (check == true);
        }
    }
}