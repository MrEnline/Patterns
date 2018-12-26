using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage coffee = new Cappuchino();
            coffee = new Foam(coffee);
            coffee = new ChocolateChips(coffee);
            coffee = new Chocolate(coffee);
            Console.WriteLine("Заказ: {0}. Cтоимость {1}", coffee.Name, coffee.GetCost());

            Console.ReadKey();
        }
    }

    //перечисление для порции кофе
    public enum Size { Small = 1, Middle = 2, Big = 3 }

    //абстрактный класс напитка
    public abstract class Beverage
    {
        //присваиваем значение по умолчанию
        Size size = Size.Small;

        //второй аргумент(size) с присвоением позволяет нам как использовать его, так и не использовать
        public Beverage(string name, Size size = Size.Small)
        {
            Name = name;
        }

        //абстрактный метод получения цены
        public abstract double GetCost();

        public string Name
        {
            get;
            set;
        }

        public void SetSize(Size size)
        {
            this.size = size;
        }

        public Size GetSize()
        {
            return size;
        }

        public abstract double ToGetCostForPortion();
    }

    //абстрактный класс декоратора - дополнительная функциональность
    public abstract class Decorator : Beverage
    {
        //protected Beverage beverage;
        public Decorator(string nameOrder) : base(nameOrder)
        {
            //this.beverage = beverage;
        }

        //public void SetSize(Size size)
        //{
        //    beverage.SetSize(size);
        //}

        //public Size GetSize()
        //{
        //    return beverage.GetSize();
        //}
    }

    public class Cappuchino : Beverage
    {

        public Cappuchino() : base("Cappuchino") { }

        public override double GetCost()
        {
            return ToGetCostForPortion() * 10.99;
        }

        public override double ToGetCostForPortion()
        {
            switch (GetSize())
            {
                case Size.Small: { return 1; }
                case Size.Middle: { return 1.3; }
                case Size.Big: { return 1.4; }
            }
            return 1;
        }
    }

    public class Latte : Beverage
    {
        public Latte() : base("Latte") { }

        public override double GetCost()
        {
            return ToGetCostForPortion() * 12.99;
        }

        public override double ToGetCostForPortion()
        {
            switch (GetSize())
            {
                case Size.Small: { return 1; }
                case Size.Middle: { return 1.3; }
                case Size.Big: { return 1.4; }
            }
            return 1;
        }
    }

    public class Chocolate : Decorator
    {
        Beverage beverage;

        public Chocolate(Beverage beverage) : base(beverage.Name + ", шоколад") { this.beverage = beverage; }

        public override double GetCost()
        {
            return ToGetCostForPortion() * 1.89 + beverage.GetCost();
        }

        public override double ToGetCostForPortion()
        {
            switch (beverage.GetSize())
            {
                case Size.Small: { return 1; }
                case Size.Middle: { return 1.2; }
                case Size.Big: { return 1.4; }
            }
            return 1;
        }
    }

    public class Foam : Decorator
    {

        Beverage beverage;

        public Foam(Beverage beverage) : base(beverage.Name + ", пенка") { this.beverage = beverage; }

        public override double GetCost()
        {
            return ToGetCostForPortion() * 0.89 + beverage.GetCost();
        }

        public override double ToGetCostForPortion()
        {
            switch (beverage.GetSize())
            {
                case Size.Small: { return 1; }
                case Size.Middle: { return 1.2; }
                case Size.Big: { return 1.4; }
            }
            return 1;
        }
    }

    public class ChocolateChips : Decorator
    {
        Beverage beverage;

        public ChocolateChips(Beverage beverage) : base(beverage.Name + ", шоколадная крошка") { this.beverage = beverage; }

        public override double GetCost()
        {
            return ToGetCostForPortion() * 0.99 + beverage.GetCost();
        }

        public override double ToGetCostForPortion()
        {
            switch (beverage.GetSize())
            {
                case Size.Small: { return 1; }
                case Size.Middle: { return 1.2; }
                case Size.Big: { return 1.4; }
            }
            return 1;
        }
    }
}
