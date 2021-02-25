using System;
using System.Threading;

namespace DoorControlNS
{
    public interface IDoor
    {
        void Open(DoorControl door);
        void Close(DoorControl door);
    }

    public class Door : IDoor
    {
        public void Open(DoorControl door)
        {
           Console.WriteLine("Opening Door");
           Thread.Sleep(300);
           Console.WriteLine("Door opened");
           door.DoorOpened();
        }

        public void Close(DoorControl door)
        {
            Console.WriteLine("Closing Door");
            Thread.Sleep(300);
            Console.WriteLine("Door closed");
            door.DoorClosed();
        }
    }
}