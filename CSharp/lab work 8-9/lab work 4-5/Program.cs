using lab_work_4_5.Factory.Domain;
using lab_work_4_5.Factory.Factories;
using lab_work_4_5.Observer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
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
            Fasad facad = new Fasad();
            Prumichenya prumichenya = new();
            CManager manager = new();
            Person guest = new Guest();
            CJournal j = new();
            Cdata data = new();
            facad.OperationAdd("Bogdan", "Misha");
            facad.OperationDialog();
            facad.OperationPrintEnd();

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
    public sealed class Prumichenya : IObservable
    {
        #region Fields and properties
        public int _cost;
        private static Prumichenya? _instance;
        public SBox box;
        public CChair[,] Seat { get; set; }
        public int _row;
        public int _colum;
        private List<IObserver> _observers;
        #endregion

        #region Methods
        public Prumichenya()
        {
        }
        public Prumichenya(int width, int height, int length, int rows, int columns)
        {
            Seat = new CChair[rows, columns];
            box = new SBox();
            box.Width = width;
            box.Height = height;
            box.Length = length;
            _row = rows;
            _colum = columns;
            _observers = new List<IObserver>();
            #region seats comfortable
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Seat[row, column] = new CChair();

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
        public void PrintChair()
        {
            Console.WriteLine("1 - free. 0 - occupied chair");
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _colum; j++)
                {
                    Console.Write(Convert.ToInt32(Seat[i, j].isFree));
                    Seat[i, j].Row = i;
                    Seat[i, j].Colum = j;
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Observer
        public void ChangeFree(CChair chair)
        {
            chair.isFree = false;
            Notify(chair);
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(CChair chair)
        {
            foreach (var item in _observers.ToList())
            {
                item.Update(chair.Row, chair.Colum);
            }
        }
        #endregion
    }
    #endregion
    public class CChair 
    {
        //Наглядач
       
        public bool isFree { get; set; }
        public int Row { get; set; }
        public int Colum { get; set; }
        public CChair()
        {
            isFree = true;
        }
       
    }
    public abstract class Person
    {
        public string Name { get; set; }
        public string? Exspirens { get; set; }
        public int Age { get; set; }
        public int Sallary { get; set; }
        Random rnd = new Random();
        public Actor Type { get; set; }
        public Person()
        {
        }
        public Person(string name, int age)
        {

            Type = (Actor)rnd.Next(0, 2);
            Name = name;
            Age = age;
            checkAge();
        }

        public void checkAge()
        {
            if (Age > 17 && Age <= 20)
            {
                Exspirens = "Student";
            }
            else if (Age > 20 && Age <= 30)
            {
                Exspirens = "Junior";
            }
            else if (Age > 30 && Age <= 40)
            {
                Exspirens = "Midle";
            }
        }
        public virtual void Print()
        {
            Console.WriteLine($"\nName:{Name};\nAge:{Age};\nExspirens':{Exspirens}");
        }

    }
    public class Guest : Person
    {
        public Guest()
        {
        }
        public Guest(string name, int age) : base(name, age)
        {
        }
        public override void Print()
        {
            base.Print();
        }
    }
    class CDecoratorPerson : Person
    {
        protected Person _decoratorPerson;
        public CDecoratorPerson(Person decoratorPerson) : base(decoratorPerson.Name, decoratorPerson.Age)
        {
            _decoratorPerson = decoratorPerson;
        }
        public override void Print()
        {
            Console.WriteLine($"\nName:{Name};\nAge:{Age};\nExspirens':{Exspirens};");
        }
    }
    //Підписник
    class CViewer : CDecoratorPerson,IObserver
    {
        private IObservable chairs;
        public int Row { get; set; }
        public int Colum { get; set; }
        public CViewer(Person decoratorPerson,IObservable obj) : base(decoratorPerson)
        {
            chairs = obj;
            obj.AddObserver(this);
        }

        public void Update(int row, int colum)
        {
            Console.WriteLine(">>>>>Observable<<<<<");
            Console.WriteLine($"Chair {row}{colum} already busy");
            Console.WriteLine("------------------");
            chairs.RemoveObserver(this);
        }
    }
    class COrator : CDecoratorPerson
    {
        public CContent Content { get; set; }
        public COrator(Person decoratorPerson) : base(decoratorPerson)
        {
            Content = new CContent();
        }

    }
    class CCashier : Person
    {
        public CChair[,] _seat;
        public double? dlzir { get; set; }

        public CCashier(string name, int age, CChair[,] seat) : base(name, age)
        {
            _seat = seat;
        }
        #region FactoryMethod(buy ticket)
        private static TicketFactory GetFactory(string ticketType, int row, int colum)
        {
            switch (ticketType)
            {
                case "TopTicket":
                    {
                        return new TopTicketFactory(250, row, colum);
                    }
                case "LowTicket":
                    {
                        return new LowTicketFactory(110, row, colum);
                    }
                default:
                    return new TopTicketFactory(250, row, colum);
            }
        }
        #endregion
        public override void Print()
        {
            Console.WriteLine($"I am:{Name}, and i am cashier today");
        }
        public int SellTicket(Prumichenya prumichenya)
        {
            int money = 0;
            Console.WriteLine("Enter chair do you want");
            Console.Write("Row: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Colum: ");
            int colum = int.Parse(Console.ReadLine());
            TicketFactory factory;
            ITicket ticket;
            if (_seat[row, colum].isFree == true)
            {
                if (row > _seat.Length / 3)
                {
                    factory = GetFactory("TopTicket", row, colum);
                    ticket = factory.GetTicket();
                    money += ticket.GetPrice();
                }
                else
                {
                    factory = GetFactory("TopTicket", row, colum);
                    ticket = factory.GetTicket();
                    money += ticket.GetPrice();
                }
                prumichenya.ChangeFree(_seat[row, colum]);
                Console.WriteLine($"\t>>>>Ticket<<<<\nType:\t{ticket.Type}\nPrice:{ticket.GetPrice()}\nYourChair:\t{ticket.Colum}{ticket.Row}\nDate:{ticket.Date}");
            }
            return money;
        }
    }

    public class CContent//++++++
    {
        Random rnd = new Random();
        public int _number;
        List<string> Content = new List<string> { "content", "content1", "content2", "content3", "content4", "content5" };
        public CContent()
        {
            _number = rnd.Next(0, 6);
            Console.WriteLine($"Content: {Content[_number]}");

        }
    }
    class CManager : Person//+++++++
    {
        public Actor _vubir;
        public int Sallary { get; set; }
        public Prumichenya Prumichenya { get; set; }
        public CManager(string name, int age, int sallary,Prumichenya prumichenya) : base(name, age)
        {
            Sallary = sallary;
            Prumichenya = prumichenya;
        }

        public CManager()
        {
        }

        public CDecoratorPerson Clasification(Person person)
        {
            Console.WriteLine($"You are:{person.Name}, Age: {person.Age}");

            if (person.Type == Actor.Orator)
            {
                CDecoratorPerson orator = new COrator(person);
                return orator;
            }
            else
            {
                
                CDecoratorPerson viewer = new CViewer(person,Prumichenya);
                return viewer;
            }

        }
        public void AddMoney(int money)
        {
            this.Sallary += money;
        }
    }
    class CJournal
    {

        public void PrintMananger(CManager mananger, Cdata data)
        {
            Console.WriteLine($"Mananger: {mananger.Name} Exspirens: {mananger.Exspirens} Sallary: {mananger.Sallary}");
            data.PrintDate();
        }
    }
    class Cdata
    {
        DateTime data = new DateTime();

        public Cdata()
        {
            data = RandomDay("2002-01-01 00:01:00", "2022-01-01 00:01:00");
        }
        public void PrintDate()
        {
            Console.WriteLine($"Date: {data}");
        }
        DateTime RandomDay(string date1, string date2)
        {
            DateTime start = DateTime.Parse(date1);
            DateTime stop = DateTime.Parse(date2);
            Random rnd = new Random();
            return start.AddDays(rnd.Next(0, new TimeSpan(stop.Ticks - start.Ticks).Days));
        }
    }
    class Fasad
    {
        public Prumichenya Prumichenya { get; set; }
        public CManager Manager { get; set; }
        public Person Guest { get; set; }
        public CJournal Journal { get; set; }
        public Cdata Data { get; set; }
        Random rnd = new Random();
        public void OperationAdd(string manangerName, string guestName)
        {
            Prumichenya = new Prumichenya(rnd.Next(10, 20), rnd.Next(3, 6), rnd.Next(20, 35), 10, 6);
            Manager = new CManager("Bogdan", rnd.Next(18, 40), 0,Prumichenya);
            Guest = new Guest("Volodymyr", rnd.Next(18, 40));
            Journal = new CJournal();
            Data = new Cdata();
        }
        public void OperationDialog()
        {
            Console.WriteLine($"Hello, I am {Manager.Name}");
            Guest = Manager.Clasification(Guest);

            if (Guest.Type == Actor.Orator)
            {
                OperatorOrator();
            }
            else if (Guest.Type == Actor.Viewer)
            {
                OperatorVisitor();
            }
        }
        public void OperatorOrator()
        {
            Console.WriteLine("ORATOR");
            Console.Write("Enter cost prumishchenya: ");
            Prumichenya._cost = Convert.ToInt32(Console.ReadLine());
            if (Prumichenya._cost <= 20000)
            {
                Prumichenya.Print();
                Console.WriteLine("Client Info: ");
                Guest.Print();
                Manager.AddMoney(Prumichenya._cost);

            }
            else
            {
                Console.WriteLine("Forum close");
            }
        }
        public void OperatorVisitor()
        {
            CCashier cashier = new CCashier("Mykola", 23, Prumichenya.Seat);
            cashier.Print();
            Console.WriteLine("VISITORS");
            while (true)
            {
                Guest = Manager.Clasification(Guest);
                Console.WriteLine("Choose free chair ");
                Prumichenya.PrintChair();
                Manager.AddMoney(cashier.SellTicket(Prumichenya));
                Console.WriteLine("It all? 1 - yes");
                if (Console.ReadLine() == "1")
                {
                    break;
                }
            }
        }
        public void OperationPrintEnd()
        {
            Journal.PrintMananger(Manager, Data);
        }
    }
}




