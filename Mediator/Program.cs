using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Collegue customer = new Customer(manager);
            Collegue programmist = new Programmist(manager);
            Collegue tester = new Tester(manager);
            manager.Customer = customer;
            manager.Programmist = programmist;
            manager.Tester = tester;
            customer.Send("Начинайте выполнять заказ");
            programmist.Send("Программа написана. Надо тестировать");
            tester.Send("Программа оттестирована. Можно внедрять на предприятии");

            Console.ReadKey();
        }
    }

    //абстрактный класс посредника
    abstract class Mediator
    {
        public abstract void Send(string msg, Collegue collegue);
    }

    //абстрактный класс получателя сообщения и отправителя
    abstract class Collegue
    {
        protected Mediator mediator;

        public Collegue(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Send(string msg);

        public abstract void Notify(string msg);
    }

    //класс заказчика
    class Customer: Collegue
    {
        public Customer(Mediator mediator): base(mediator) { }

        public override void Send(string msg)
        {
            mediator.Send(msg, this);    
        }

        public override void Notify(string msg)
        {
            Console.WriteLine("Сообщение заказчику: " + msg);
        }
    }

    class Programmist: Collegue
    {
        public Programmist(Mediator mediator): base(mediator) { }

        public override void Send(string msg)
        {
            mediator.Send(msg, this);
        }

        public override void Notify(string msg)
        {
            Console.WriteLine("Сообщение программисту: " + msg);
        }
    }

    class Tester: Collegue
    {
        public Tester(Mediator mediator): base(mediator) { }

        public override void Send(string msg)
        {
            mediator.Send(msg, this);
        }

        public override void Notify(string msg)
        {
            Console.WriteLine("Сообщение тестеру: " + msg);
        }
    }


    class Manager: Mediator
    {
        public Collegue Customer { get; set; }
        public Collegue Programmist { get; set; }
        public Collegue Tester { get; set; }

        public override void Send(string msg, Collegue collegue)
        {
            if (collegue == Customer)
            {
                Programmist.Notify(msg);
            }
            if (collegue == Programmist)
            {
                Tester.Notify(msg);
            }
            if (collegue == Tester)
            {
                Customer.Notify(msg);
            }
        }
    }
}
