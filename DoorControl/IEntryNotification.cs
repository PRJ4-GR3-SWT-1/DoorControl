namespace DoorControlNS
{
    public interface IEntryNotification
    {
        void NotifyEntryDenied(int id);
        void NotifyEntryGranted(int id);
    }

    class EntryNotification : IEntryNotification
    {
        public void NotifyEntryDenied(int id)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyEntryGranted(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}