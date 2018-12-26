using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем экземпляр биржи
            Stock stock = new Stock();
            Broker broker = new Broker(stock);
            Bank bank = new Bank(stock);
            //добавляемся на биржу
            broker.AddBrokerToStock();
            //имитируем биржу
            stock.Market();
            stock.Market();

            Console.ReadKey();
        }
    }

    //интерфейс наблюдателя
    interface IObserver
    {
        void Update(object ob);
    }

    //интерфейс наблюдаемого объекта
    interface IObservable
    {
        void NotifyObservers();                  //рассылка уведомлений
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }

    class Stock: IObservable
    {
        List<IObserver> list;
        sInfo sInfo;

        public Stock()
        {
            sInfo = new sInfo();
            list = new List<IObserver>();
        }

        //
        public void AddObserver(IObserver observer)
        {
            list.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            list.Remove(observer);
        }

        //уведомления подписчиков
        public void NotifyObservers()
        {
            foreach (IObserver item in list)
            {
                item.Update(sInfo);
            }
        }
        
        //торги
        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = (double)rnd.Next(60, 70);
            sInfo.Euro = (double)rnd.Next(70, 80);
            NotifyObservers();
        }
    }

    class Broker: IObserver
    {
        sInfo sInfo;
        double oldUSD = 0,
               oldEuro = 0;
        Stock stock;

        public Broker(Stock stock)
        {
            this.stock = stock;
        }

        //подписываемся на уведомления от биржи
        public void AddBrokerToStock()
        {
            stock.AddObserver(this);
        }
        //отписываемся от уведомлений от биржи
        public void RemoveBrokerToStock()
        {
            stock.RemoveObserver(this);
        }

        public void Update(object ob)
        {
            sInfo = ob as sInfo;
            Calculate(sInfo.USD, ref oldUSD, "доллара");
            Calculate(sInfo.Euro, ref oldEuro, "евро");
        }

        private void Calculate(double currency, ref double oldcurrency, string textCurr)
        {
            if (currency != oldcurrency)
                Console.WriteLine("Значение {0} изменилось на {1}", textCurr, currency - oldcurrency);
            oldcurrency = currency;
        }
    }

    class Bank : IObserver
    {
        sInfo sInfo;
        double oldUSD = 0,
               oldEuro = 0;
        Stock stock;

        public Bank(Stock stock)
        {
            this.stock = stock;
        }

        public void AddBankToStock()
        {
            stock.AddObserver(this);
        }

        public void RemoveBankToStock()
        {
            stock.RemoveObserver(this);
        }

        public void Update(object ob)
        {
            sInfo = ob as sInfo;
            Calculate(sInfo.USD, ref oldUSD, "доллара");
            Calculate(sInfo.Euro, ref oldEuro, "евро");

        }

        private void Calculate(double currency, ref double oldcurrency, string textCurr)
        {
            if (currency != oldcurrency)
                Console.WriteLine("Значение {0} изменилось на {1}", textCurr, currency - oldcurrency);
            oldcurrency = currency;
        }
    }

    class sInfo
    {
        public double Euro { get; set; }
        public double USD { get; set; }
    }
}
