namespace DoorControl
{
    public interface IDoor
    {
        void Open();
        void Close();
    }

    public class Door : IDoor
    {
        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }
    }
}