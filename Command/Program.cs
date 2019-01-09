using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult pult = new Pult();

            TVOnCommand tVOnCommand = new TVOnCommand(new TV());
            MicrovaweOnCommand microvaweOnCommand = new MicrovaweOnCommand(new Microwave(), 5000);
            VolumeCommand volumeCommand = new VolumeCommand(new Volume());

            pult.SetCommand(tVOnCommand, 1);
            pult.PressButton(1);
            //pult.PressUndo();
            Console.WriteLine(new string('-', 50));
            pult.SetCommand(microvaweOnCommand, 2);
            pult.PressButton(2);
            Console.WriteLine(new string('-', 50));
            pult.SetCommand(volumeCommand, 3);
            pult.PressButton(3);
            Console.WriteLine(new string('-', 50));
            pult.PressUndo();
            pult.PressUndo();
            pult.PressUndo();

            Console.ReadKey();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    //класс, инициирующий команды
    class Pult
    {
        ICommand[] commands;
        private Stack<ICommand> historyCommands;

        public Pult()
        {
            commands = new ICommand[3];
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new NoCommand();
            }
            historyCommands = new Stack<ICommand>();
        }

        public void SetCommand(ICommand command, int num)
        {
            if (num > 0 && num <= commands.Length )
            {
                commands[num - 1] = command;
            }
            else
            {
                Console.WriteLine("Введен некорректный индекс команды");
            }

        }

        public void PressButton(int i)
        {
            if (i > 0 && i <= commands.Length)
                commands[i-1].Execute();
            //добавляем команду в историю
            historyCommands.Push(commands[i-1]);
        }

        public void PressUndo()
        {
            ICommand undoCommand = new NoCommand();
            if (historyCommands.Count > 0)
                undoCommand = historyCommands.Pop();
            undoCommand.Undo();
        }
    }

    //класс команд
    class TVOnCommand: ICommand
    {
        TV tV;
        public TVOnCommand(TV tV)
        {
            this.tV = tV;
        }

        public void Execute()
        {
            tV.On();
        }

        public void Undo()
        {
            tV.Off();
        }
    }

    class NoCommand: ICommand
    {
        public void Execute() { Console.WriteLine("Некорректная команда"); }
        public void Undo() { Console.WriteLine("Остановить процесс"); }
    }

    class MicrovaweOnCommand: ICommand
    {
        Microwave microwave;
        int timer;

        public MicrovaweOnCommand(Microwave microwave, int time)
        {
            this.microwave = microwave;
            timer = time;
        }

        public void Execute()
        {
            microwave.StartHeat(timer);
        }

        public void Undo()
        {
            microwave.StopHeat();
            timer = 0;
        }
    }

    class VolumeCommand : ICommand
    {
        Volume volume;

        public VolumeCommand(Volume volume)
        {
            this.volume = volume;
        }

        public void Execute()
        {
            volume.HighVolume();
        }

        public void Undo()
        {
            volume.LowVolume();
        }
    }
    
    //класс получателей команд
    class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен");
        }
    }

    class Microwave
    {

        //разогрев еды
        public void StartHeat(int time)
        {
            Console.WriteLine("Подогреваем еду");
            // имитация работы с помощью асинхронного метода Task.Delay
            Task.Delay(time).GetAwaiter().GetResult();
            StopHeat();
        }

        //остановить разогрев еды
        public void StopHeat()
        {
            Console.WriteLine("Еда подогрета");
        }
    }

    //громкость
    class Volume
    {
        private const int High = 5;
        private const int Low = 0;
        private int volume = 0;

        public void HighVolume()
        {
            if (volume < High)
                volume++;
            Console.WriteLine("Громкость увеличена");
        }

        public void LowVolume()
        {
            if (volume > Low)
                volume--;
            Console.WriteLine("Громкость уменьшена");
        }
    }

}
