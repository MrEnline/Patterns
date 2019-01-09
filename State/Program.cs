using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            //паттерн Состояние
            //
            Human human = new Human();
            human.Move();
            human.Move();
            human.Move();

            Console.ReadKey();
        }
    }

    class Human
    {

        public IMoveable Moveable { private get; set; }

        public Human()
        {
            Moveable = new Stop();
        }

        public void Move()
        {
            Moveable.Move(this);
        }
    }

    interface IMoveable
    {
        void Move(Human human);
    }

    class Run: IMoveable
    {
        public Run()
        {
            Console.WriteLine("Человек бежит");
        }

        public void Move(Human human)
        {
            human.Moveable = new Stop();
        }
    }

    class Stop : IMoveable
    {
        public Stop()
        {
            Console.WriteLine("Человек стоит");
        }

        public void Move(Human human)
        {
            human.Moveable = new Go();
        }
    }

    class Go : IMoveable
    {
        public Go()
        {
            Console.WriteLine("Человек идет");
        }

        public void Move(Human human)
        {
            human.Moveable = new Run();
        }
    }
}
