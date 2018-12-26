using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabric
{
    class Program
    {
        static void Main(string[] args)
        {
            Client hero = new Client(new Elf());
            hero.Ability();
            hero.Wheapon();
            Console.WriteLine(new string('-', 50));

            Client hero1 = new Client(new Gnome());
            hero1.Ability();
            hero1.Wheapon();
            Console.WriteLine(new string('-', 50));

            Client hero2 = new Client(new Homo());
            hero2.Ability();
            hero2.Wheapon();
            Console.WriteLine(new string('-', 50));

            Console.ReadKey();
        }
    }

    class Client
    {
        private Hero hero;
        private Wheapon wheapon;
        private Ability ability;

        public Hero Hero
        {
            set { hero = value; }
            get { return hero; }
        }

        public Client(Hero hero)
        {
            this.hero = hero;
            ability = hero.CreateAbility();
            wheapon = hero.CreateWheapon();
        }

        public void Ability()
        {
            ability.GetAbility(hero);
        }

        public void Wheapon()
        {
            wheapon.GetWheapon(hero);
        }
    }

    //абстрактный класс Героя
    abstract class Hero
    {
        public string Name { get; set; }

        public Hero(string name)
        {
            Name = name;
        }

        public abstract Wheapon CreateWheapon();
        public abstract Ability CreateAbility();
    }

    //абстрактный класс оружия для героя
    abstract class Wheapon
    {
        public abstract void GetWheapon(Hero hero);
    }

    //абстрактный класс способности для героя
    abstract class Ability
    {
        public abstract void GetAbility(Hero hero);
    }

    class Elf : Hero
    {
        public Elf(): base("Эльф"){}

        public override Wheapon CreateWheapon()
        {
            return new Crossbow();
        }

        public override Ability CreateAbility()
        {
            return new ToRun();
        }
    }

    class Gnome : Hero
    {
        public Gnome():base("Гном"){}

        public override Wheapon CreateWheapon()
        {
            return new Hammer();
        }

        public override Ability CreateAbility()
        {
            return new Power();
        }
    }

    class Homo : Hero
    {
        public Homo(): base("Человек"){}

        public override Wheapon CreateWheapon()
        {
            return new Sword();
        }

        public override Ability CreateAbility()
        {
            return new Neitral();
        }
    }

    //класс Арбалет
    class Crossbow : Wheapon
    {
        public override void GetWheapon(Hero hero)
        {
            Console.WriteLine("{0} может стрелять из арбалета", hero.Name);
        }
    }

    class ToRun : Ability
    {
        public override void GetAbility(Hero hero)
        {
            Console.WriteLine("{0} умеет быстро бегать", hero.Name);
        }
    }

    class Hammer : Wheapon
    {
        public override void GetWheapon(Hero hero)
        {
            Console.WriteLine("{0} умеет сражаться молотом", hero.Name);
        }
    }

    class Power : Ability
    {
        public override void GetAbility(Hero hero)
        {
            Console.WriteLine("{0} имеет недюжинную силу", hero.Name);
        }
    }

    //класс меч
    class Sword : Wheapon
    {
        public override void GetWheapon(Hero hero)
        {
            Console.WriteLine("{0} умеет сражаться мечом", hero.Name);
        }
    }

    class Neitral : Ability
    {
        public override void GetAbility(Hero hero)
        {
            Console.WriteLine("{0} нихрена не умеет", hero.Name);
        }
    }
}

