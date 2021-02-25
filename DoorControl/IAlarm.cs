using System;

namespace DoorControlNS
{
   public interface IAlarm
    {
        void RaiseAlarm();

    }

    public class Alarm : IAlarm
    {
        public void RaiseAlarm()
        {
            Console.WriteLine("ALLLLAAAAAARRRMMMM");
        }
    }
}