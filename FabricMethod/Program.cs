using System;

namespace FabricMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    abstract class Developer
    {
        public abstract House GetHome();
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
