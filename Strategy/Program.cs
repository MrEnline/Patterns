using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            IMoveable gas = new GasMove();

            //газовый тарантас
            Transport transport = new Transport(gas);
            transport.Move();

            //установили электрический движок на тарантас
            transport.Moveable = new ElectricMove();
            transport.Move();

            Console.ReadKey();
        }
    }

    //интерфейс поведения экземпляра класса
    interface IMoveable
    {
        void Move();
    }

    class PetrolMove: IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Данный вид транспорта использует бензин для перемещения");
        }
    }

    class ElectricMove: IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Данный вид транспорта использует электричество для перемещения");
        }
    }

    class GasMove: IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Данный вид транспорта использует газ для перемещения");
        }
    }

    //класс транспорта
    class Transport
    {
        IMoveable moveable;
        public Transport(IMoveable moveable)
        {
            this.moveable = moveable;
        }

        public void Move()
        {
            moveable.Move();
        }

        public IMoveable Moveable
        {
            set { moveable = value; }
        }
    }
}
