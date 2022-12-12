using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab4_5
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть cost");

            Random rnd = new Random();
            int colum = 1;
            int row = 11;
            int seat = 111;
            Prumichenya prumichenya = new Prumichenya(rnd.Next(10, 20), rnd.Next(3, 6), rnd.Next(20, 35), seat, row, colum);
            //Person person = new Person(//"Bob", rnd.Next(18, 40));
            CCashier cashier = new CCashier("Bob", 43,prumichenya.Seat);
            CViewer viewer = new CViewer("andrey", 32);
            COrator orator = new COrator("oleg", 21);


            prumichenya._cost = Convert.ToInt32(Console.ReadLine());
            if (prumichenya._cost <= 20000)
            {
                prumichenya.Print();
                //person.Print();

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
        public Prumichenya(int width, int height, int length, int seat, int rows, int columns)
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
                _instance = new Prumichenya(width, height, length, seat, row, column);
                return _instance;

            }
            else
            {
                return _instance;
            }
        }
        public void Print()
        {
            Console.WriteLine($"Width prumichenya={box.Width}m; \nHeight prumichenya={box.Height}m; \nLength prumichenya={box.Length}m;");

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
    abstract class Person
    {
        public string Name { get; set; }
        public string? Exspirens { get; set; }
        public int Age { get; set; }
        public string Studens = "Studens";
        public string Junior = "Junior";
        public string Middle = "Middle";
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
        public CViewer(string name, int age) : base(name, age)
        {

        }
    }
    class  CCashier: Person
    {
        public CChair[,] _seat;
        public double? dlzir { get; set; }
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
        public COrator(string name,int age): base(name,age)
        {

        }
    }
    class CContent
    {

    }
    class CManager
    {

    }
    class CJournal
    {

    }
    class Cdata
    {

    }



}

