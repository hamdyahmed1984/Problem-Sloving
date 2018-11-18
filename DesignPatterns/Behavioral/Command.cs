using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /*
     * Definition
       Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.
       Participants
       
       The classes and objects participating in this pattern are:
       
       Command  (ICommand)
       declares an interface for executing an operation
       ConcreteCommand  (LightOnCommand, LightOffCommand, FanHighCommand, FanOffCommand, ..)
       defines a binding between a Receiver object and an action
       implements Execute by invoking the corresponding operation(s) on Receiver
       Client  (CommandApp)
       creates a ConcreteCommand object and sets its receiver
       Invoker  (RemoteControl)
       asks the command to carry out the request
       Receiver  (Light, Fan)
       knows how to perform the operations associated with carrying out the request.
     */
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    class Light
    {
        private string _location;

        public Light(string location)
        {
            this._location = location;
        }

        public void On() => Console.WriteLine(_location + " light is ON.");
        public void Off() => Console.WriteLine(_location + " light is OFF.");
    }

    #region Commands
    /// <summary>
    /// Empty command to use it in case of null instead off checking for null commands
    /// </summary>
    class NoCommand : ICommand
    {
        public void Execute()
        {
        }

        public void Undo()
        {
        }
    }

    class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }

    class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }

    class GarageOpenCommand : ICommand
    {
        private Garage _garage;

        public GarageOpenCommand(Garage garage)
        {
            this._garage = garage;
        }

        public void Execute()
        {
            _garage.Open();
        }

        public void Undo()
        {
            _garage.Close();
        }
    }

    class GarageCloseCommand : ICommand
    {
        private Garage _garage;

        public GarageCloseCommand(Garage garage)
        {
            this._garage = garage;
        }

        public void Execute()
        {
            _garage.Close();
        }

        public void Undo()
        {
            _garage.Open();
        }
    }

    /// <summary>
    /// We implemented FanHighCommand and FanOffCommand, we can implement FanLowCommand and FanMediumCommand the same way.
    /// </summary>
    class FanHighCommand : ICommand
    {
        private Fan _fan;
        private int prevSpeed;

        public FanHighCommand(Fan fan)
        {
            this._fan = fan;
        }

        public void Execute()
        {
            prevSpeed = _fan.GetSpeed();
            _fan.High();
        }

        public void Undo()
        {
            switch (prevSpeed)
            {
                case 0:
                        _fan.Off();
                    break;
                case 1:
                    _fan.Low();
                    break;
                case 2:
                    _fan.Medium();
                    break;
                case 3:
                    _fan.High();
                    break;
                default:
                    break;
            }
        }
    }

    class FanOffCommand : ICommand
    {
        private Fan _fan;
        private int prevSpeed;

        public FanOffCommand(Fan fan)
        {
            this._fan = fan;
        }

        public void Execute()
        {
            prevSpeed = _fan.GetSpeed();
            _fan.Off();
        }

        public void Undo()
        {
            switch (prevSpeed)
            {
                case 0:
                    _fan.Off();
                    break;
                case 1:
                    _fan.Low();
                    break;
                case 2:
                    _fan.Medium();
                    break;
                case 3:
                    _fan.High();
                    break;
                default:
                    break;
            }
        }
    }
    #endregion

    #region Invoker

    public class RemoteControl
    {
        private List<ICommand> onCommands = new List<ICommand>();
        private List<ICommand> offCommands = new List<ICommand>();
        private Stack<ICommand> undoCommands= new Stack<ICommand>();

        public RemoteControl()
        {
            NoCommand noCommand = new NoCommand();
            //We wiil has 20 slots in out remote control, 10 for on and 10 for off
            for (int i = 0; i < 10; i++)
            {
                onCommands.Add(noCommand);
                offCommands.Add(noCommand);
            }
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand; 
        }

        public void OnButtonPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommands.Push(onCommands[slot]);
        }

        public void OffButtonPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommands.Push(offCommands[slot]);
        }

        public void Undo()
        {
            if (undoCommands.Any())
            {
                ICommand lastExecutedCommand = undoCommands.Pop();
                lastExecutedCommand.Undo();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------ Remote Control ---------------");
            for (int i = 0; i < onCommands.Count; i++)
            {
                sb.AppendLine("[Slot " + i + "] " + onCommands[i].GetType().Name + " " +
                              offCommands[i].GetType().Name);
            }

            sb.AppendLine("--------------------------------------------");
            return sb.ToString();
        }

    }
    #endregion


    #region Receivers

    class Fan
    {
        private string _location;
        private int _speed;

        public static readonly int OFF = 0;
        public static readonly int LOW = 1;
        public static readonly int MEDIUM = 2;
        public static readonly int HIGH = 3;

        public int GetSpeed() => _speed;

        public Fan(string location)
        {
            this._location = location;
        }

        public void Off()
        {
            _speed = OFF;
            Console.WriteLine(_location + " fan speed is OFF.");
        }

        public void Low()
        {
            _speed = LOW;
            Console.WriteLine(_location + " fan speed is LOW.");
        }

        public void Medium()
        {
            _speed = MEDIUM;
            Console.WriteLine(_location + " fan speed is MEDIUM.");
        }

        public void High()
        {
            _speed = HIGH;
            Console.WriteLine(_location + " fan speed is HIGH.");
        }
    }

    class Garage
    {
        public void Open() => Console.WriteLine("Garage is OPEN.");
        public void Close() => Console.WriteLine("Garage is CLOSED.");
    }

    #endregion
}
