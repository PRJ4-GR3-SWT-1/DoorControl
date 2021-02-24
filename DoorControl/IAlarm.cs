namespace DoorControl
{
   public interface IAlarm
    {
        void RaiseAlarm();

    }

    public class Alarm : IAlarm
    {
        public void RaiseAlarm()
        {
            throw new System.NotImplementedException();
        }
    }
}