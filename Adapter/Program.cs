using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new Adapter();
            target.Request();

            Console.ReadKey();
        }
    }

    interface ITarget
    {
        void Request();
    }

    class  Adapter: Adaptee, ITarget
    {
        //Adaptee adaptee = new Adaptee();

        //public void Request()
        //{
        //    adaptee.SpecialRequest();
        //}

        public void Request()
        {
            base.SpecialRequest();
        }
    }

    class  Adaptee
    {
        public void SpecialRequest()
        {
            Console.WriteLine("Метод Special");
        }
    }
}
