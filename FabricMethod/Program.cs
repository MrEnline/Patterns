using System;

namespace FabricMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fabric Method
            Developer developer = new PanelDeveloper();
            developer.Create();
            Console.WriteLine(new string('-', 50));
            developer = new WoodDeveloper();
            developer.Create();

            Console.ReadKey();
        }
    }

    abstract class Developer
    {
        //string name;

        public Developer(string name)
        {
            //this.name = name;
            Console.WriteLine("В работе участвует {0}", name);
        }

        public abstract House Create();
    }

    class PanelDeveloper: Developer
    {
        public PanelDeveloper(): base("Панельная компания")
        {

        }

        public override House Create()
        {
            return new PanelHome();
        }
    }

    class WoodDeveloper: Developer
    {
        public WoodDeveloper(): base("Деревянная компания")
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

       
    abstract class House
    {

    }

    class PanelHome: House
    {
        public void CreatePanelHome()
        {
            Console.WriteLine("Построен панельный дом");
        }
    }

    class WoodHouse: House
    {
        public void CreateWoodHouse()
        {
            Console.WriteLine("Построен деревянный дом");
        }
    }
}
