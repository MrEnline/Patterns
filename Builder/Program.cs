using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            BreadBuilder builder = new RyeBread("Ржаной хлеб");
            Baker baker = new Baker(builder);
            Bread ryeBread = baker.Bake();
            Console.WriteLine(ryeBread.ToString());

            Console.WriteLine(new string('-', 50));

            builder = new CornyBread("Злаковый хлеб");
            baker.Builder = builder;
            Bread cornBread = baker.Bake();
            Console.WriteLine(cornBread.ToString());

            Console.ReadKey();
        }
    }

    //класс-строитель определенного вида хлеба
    abstract class BreadBuilder
    {
        public Bread bread { get; private set; }                          //ссылка на хлеб

        public abstract void SetSolt();                 //количество соли
        public abstract void SetSupplement();           //название добавки
        public abstract void SetFlour();                //сорт муки
                                                        //public abstract Bread GetBread();               //продукт

        public BreadBuilder(string name)
        {
            bread = new Bread(name);
        }
    }

    //класс соль
    class Solt
    {
        public int Gramm { get; set; }
    }

    //класс добавки
    class Supplement
    {
        public string Name { get; set; }
    }

    //класс сорт муки
    class Flour
    {
        public string Sort { get; set; }
    }

    //ржаной хлеб
    class RyeBread : BreadBuilder
    {
        public RyeBread(string name) : base(name) { }

        public override void SetFlour()
        {
            bread.Flour = new Flour { Sort = "Ржаной сорт" };
        }
        public override void SetSolt()
        {
            bread.Solt = new Solt { Gramm = 100 };
        }
        public override void SetSupplement()
        {
            bread.Supplement = new Supplement { Name = "Хрень какая-то, а не добавка" };
        }
        //public override Bread GetBread()
        //{
        //    return bread;
        //}
    }

    class CornyBread : BreadBuilder
    {
        public CornyBread(string name) : base(name) { }

        public override void SetSolt()
        {
            bread.Solt = new Solt { Gramm = 100 };
        }
        public override void SetSupplement()
        {
            bread.Supplement = new Supplement { Name = "Получше даже добавочка" };
        }
        public override void SetFlour()
        {
            bread.Flour = new Flour { Sort = "Злаковый сорт" };
        }
        //public override Bread GetBread()
        //{
        //    return bread;
        //}
    }

    //класс хлеб, который является продуктом
    class Bread
    {
        //ссылки на компоненты для хлеба
        public string Name { get; set; }
        public Solt Solt { get; set; }
        public Supplement Supplement { get; set; }
        public Flour Flour { get; set; }

        public Bread(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Name != null)
            {
                sb.Append(Name + "\n");
            }

            if (Flour != null)
            {
                sb.Append(Flour.Sort + "\n");
            }

            if (Solt != null)
            {
                sb.Append(Solt.Gramm + "\n");
            }

            if (Supplement != null)
            {
                sb.Append(Supplement.Name + "\n");
            }

            return sb.ToString();
        }
    }

    //класс Пекарь
    class Baker
    {
        BreadBuilder builder;

        public Baker(BreadBuilder builder)
        {
            this.builder = builder;
        }

        public Bread Bake()
        {
            builder.SetFlour();
            builder.SetSupplement();
            builder.SetSolt();
            return builder.bread;
        }

        public BreadBuilder Builder
        {
            set { builder = value; }
        }
    }
}
