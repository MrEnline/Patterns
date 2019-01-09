using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            //pattern Facade
            Facade facade = new Facade(new SubSystem1(), new SubSystem2(), new SubSystem3());
            facade.OperationAB();
            Console.WriteLine();
            facade.OperationBC();
            Console.WriteLine();
            facade.OperationCA();
            Console.WriteLine();
            facade.OperationABC();

            Console.ReadKey();
        }
    }

    class Facade
    {
        SubSystem1 subSystem1;
        SubSystem2 subSystem2;
        SubSystem3 subSystem3;

        public Facade(SubSystem1 subSystem1, SubSystem2 subSystem2, SubSystem3 subSystem3)
        {
            this.subSystem1 = subSystem1;
            this.subSystem2 = subSystem2;
            this.subSystem3 = subSystem3;
        }

        public void OperationAB()
        {
            subSystem1.OperationA();
            subSystem2.OperationB();
        }

        public void OperationBC()
        {
            subSystem2.OperationB();
            subSystem3.OperationC();
        }

        public void OperationCA()
        {
            subSystem3.OperationC();
            subSystem1.OperationA();
        }

        public void OperationABC()
        {
            subSystem1.OperationA();
            subSystem2.OperationB();
            subSystem3.OperationC();
        }
    }

    class SubSystem1
    {
        public void OperationA()
        {
            Console.WriteLine("Операция А");
        }
    }

    class SubSystem2
    {
        public void OperationB()
        {
            Console.WriteLine("Операция Б");
        }
    }

    class SubSystem3
    {
        public void OperationC()
        {
            Console.WriteLine("Операция С");
        }
    }
}
