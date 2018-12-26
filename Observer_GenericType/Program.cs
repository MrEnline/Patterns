using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_GenericType
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Broker broker = new Broker();
            broker.Subscribe(stock);
            stock.Market();
            stock.Market();
            stock.Market();
            broker.UnSubscribe();
            Console.ReadKey();
        }
    }

    struct sInfo
    {
        public int USD { get; set; }
        public int EURO { get; set; }
    }

    class Stock: IObservable<sInfo>
    {
        List<IObserver<sInfo>> list = new List<IObserver<sInfo>>();
        IObserver<sInfo> observer;
        sInfo sInfo = new sInfo();

        public IDisposable Subscribe(IObserver<sInfo> observer)
        {
            if (observer != null && !list.Contains(observer))
                list.Add(observer);
            return new UnSubscriber(list, observer);
        }

        private class UnSubscriber: IDisposable
        {
            List<IObserver<sInfo>> list = new List<IObserver<sInfo>>();
            IObserver<sInfo> observer;

            public UnSubscriber(List<IObserver<sInfo>> list, IObserver<sInfo> observer)
            {
                this.list = list;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observer != null && list.Contains(observer))
                    list.Remove(observer);
            }
        }

        //уведомим подписчиков о окончании подписки
        public void EndPush()
        {
            foreach (IObserver<sInfo> item in list)
                 item.OnCompleted();
             list.Clear();
        }

        //торги
        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(60, 70);
            sInfo.EURO = rnd.Next(70, 80);
            foreach (IObserver<sInfo> item in list)
            {
                item.OnNext(sInfo);
            }    
        }
    }

    class Broker: IObserver<sInfo>
    {
        private IDisposable unsubscriber;
        int oldUSD,
            oldEURO;

        //подписка на уведомления необходимого класса
        public void Subscribe(IObservable<sInfo> observable)
        {
            if (observable != null)
                unsubscriber = observable.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Подписка окончена. Уведомлений больше не будет");
            this.UnSubscribe();
        }

        public void OnError(Exception error)
        {

        }

        //уведомления
        public void OnNext(sInfo sInfo)
        {
            Calculate(sInfo.USD, ref oldUSD, "доллара");
            Calculate(sInfo.EURO, ref oldEURO, "евро");
        }

        private void Calculate(int currency, ref int oldcurrency, string textCurr)
        {
            if (currency != oldcurrency)
                Console.WriteLine("Значение {0} изменилось на {1}. Текущее значение валюты {2}", textCurr, currency - oldcurrency, currency);
            oldcurrency = currency;
        }

        public void UnSubscribe()
        {
            if (unsubscriber != null)
                unsubscriber.Dispose();
        }

    }

    class UnknownExeption: Exception
    {
        public override string Message { get; }
    }
}
