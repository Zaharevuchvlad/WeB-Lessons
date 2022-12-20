using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab4_5
{
    public enum Actor
    {
        Orator,
        Viewer
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int colum = 1;
            int row = 11;
            Prumichenya prumichenya = new Prumichenya(rnd.Next(10, 20), rnd.Next(3, 6), rnd.Next(20, 35), row, colum);

            //Person person = new Person(//"Bob", rnd.Next(18, 40));
          // CCashier cashier = new CCashier("Bob", 43, prumichenya.Seat);
           // CViewer viewer = new CViewer("andrey", 32);
            // COrator orator = new COrator("oleg", 21);
           


            prumichenya._cost = Convert.ToInt32(Console.ReadLine());
            if (prumichenya._cost <= 20000)
            {
                prumichenya.Print();
                //person.Print();
                //CContent content = new CContent(rnd.Next(1,6));
                Cdata data = new Cdata(rnd.Next(0, 6));

            }
            else
            {
                Console.WriteLine("Forum close");
            }
        }
    }
    //--------------------------------
    public struct SBox
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
    }

    #region prumichenya_odunac
    public sealed class Prumichenya
    {
        #region Fields and properties
        public int _cost;
        private static Prumichenya? _instance;
        public SBox box;
        public CChair[,] Seat { get; set; }
        #endregion

        #region Methods
        public Prumichenya(int width, int height, int length, int rows, int columns)
        {
            Seat = new CChair[rows, columns];
            box = new SBox();
            box.Width = width;
            box.Height = height;
            box.Length = length;

            #region seats comfortable
            for (int row = 0; row < rows / 3; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Seat[row, column] = new CChair(10);

                }
            }
            for (int row = rows / 3; row < (rows / 3) * 2; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Seat[row, column] = new CChair(9);

                }
            }
            for (int row = (rows / 3) * 2; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Seat[row, column] = new CChair(8);

                }
            }
            #endregion

        }
        public static Prumichenya Instance(int width, int height, int length, int seat, int row, int column)
        {
            if (_instance == null)
            {
                _instance = new Prumichenya(width, height, length, row, column);
            }
            return _instance;
        }
        public void Print()
        {
            Console.WriteLine($"Width prumichenya={box.Width}m;");
            Console.WriteLine($"Height prumichenya={box.Height}m;");
            Console.WriteLine($"Length prumichenya={box.Length}m;");
        }
        #endregion
    }
    #endregion

    public class CChair
    {
        int _Comfortable { get; set; }
        public CChair(int _comfortable)
        {
            _Comfortable = _comfortable;

        }

    }
    public abstract class Person
    {
        public string Name { get; set; }
        public string? Exspirens { get; set; }
        public int Age { get; set; }
        public string Studens = "Studens";
        public string Junior = "Junior";
        public string Middle = "Middle";

        public abstract Actor Type { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            if (Age > 17 && Age <= 20)
            {
                Exspirens = Studens;
            }
            else if (Age > 20 && Age <= 30)
            {
                Exspirens = Junior;
            }
            else if (Age > 30 && Age <= 40)
            {
                Exspirens = Middle;
            }
        }
        public void Print()
        {
            Console.WriteLine($"\nName:{Name};\nAge:{Age};\nExspirens':{Exspirens}");
        }
    }
    //--------------------------------
    class CViewer : Person
    {
        public override Actor Type { get; set; }
        public CViewer(string name, int age) : base(name, age)
        {
            Type = Actor.Viewer;
        }
    }
    class CCashier : Person
    {
        public CChair[,] _seat;
        public double? dlzir { get; set; }
        public override Actor Type { get; set; }

        public CCashier(string name, int age, CChair[,] seat) : base(name, age)
        {
            _seat = seat;
        }
        public void Proposals(double dlzir)
        {
            if (dlzir == 3)
            {
                Console.WriteLine("dalnozorist");
            }
            else if (dlzir == 2)
            {
                Console.WriteLine("normal zir");
            }
            else if (dlzir == 1)
            {
                Console.WriteLine("Blizkozorist");
            }
        }
        #region buy_ticket
        public int BuyOneRowTicket()
        {
            return 110;
        }
        public int BuyTwoRowTicket()
        {
            return 100;
        }
        public int BuyThreeRowTicket()
        {
            return 90;
        }
        #endregion
    }
    class COrator : Person
    {
        public override Actor Type { get; set; }
        public COrator(string name, int age) : base(name, age)
        {
            Type = Actor.Orator;
        }

     }
    class CContent//++++++
    {
        public int _number;
        public CContent(int number)
        {
            _number = number;

            switch (_number)
            {
                case 1:
                    Console.WriteLine("content");
                    break;
                case 2:
                    Console.WriteLine("content1");
                    break;
                case 3:
                    Console.WriteLine("content2");
                    break;
                case 4:
                    Console.WriteLine("content3");
                    break;
                case 5:
                    Console.WriteLine("content4");
                    break;
                case 6:
                    Console.WriteLine("content5");
                    break;
            }

        }
    }
        class CManager : Person//+++++++
        {
            public override Actor Type { get; set; }
            public Actor _vubir;
            public CManager(string name, int age, Actor vubir) : base(name, age)
            {

            }
            public void Clasification(Person person)
            {
                SBadge badge = new SBadge();
                badge.name = person.Name;
                badge.position = person.Type;
            }
        }
        class CJournal
        {

        }
        class Cdata
        {
        int _n;
           static Random rnd = new Random();
           public string[] _day { get; set; } = {"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Satuday"};
            string[] _month { get; set; } = {"January","February","March","April","May","June",
            "July","August","September","October","November","December"};
            double? _year { get; set; } = rnd.Next(2004,2022);
            public Cdata(int n)
            {
            _n = n;
                switch(_n)
                {
                case 0:
                    Console.WriteLine($"Day:{_day[0]}  Month:{_month[rnd.Next(1, 12)]} Year:{_year}");
                    break;
                case 1:
                    Console.WriteLine($"Day:{_day[1]}  Month:{_month[rnd.Next(1,12)]} Year:{_year}");
                        break;
                    case 2:
                    Console.WriteLine($"Day:{_day[2]}  Month:{_month[rnd.Next(1, 12)]} Year:{_year}"); ;
                        break;
                    case 3:
                    Console.WriteLine($"Day:{_day[3]}  Month:{_month[rnd.Next(1, 12)]} Year:{_year}");
                    break;
                    case 4:
                    Console.WriteLine($"Day:{_day[4]}  Month:{_month[rnd.Next(1, 12)]} Year:{_year}");
                    break;
                    case 5:
                    Console.WriteLine($"Day:{_day[5]}  Month:{_month[rnd.Next(1, 12)]} Year:{_year}");
                    break;
                    case 6:
                    Console.WriteLine($"Day:{_day[6]}  Month:{_month[rnd.Next(1, 12)]} Year:{_year}");
                    break;

                }
            }
        }
        struct SBadge//++++++++++++
        {
            public string name;
            public Actor position;
        }
}




