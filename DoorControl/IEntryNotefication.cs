namespace DoorControl
{
    public interface IEntryNotefication
    {
        void NotifyEntryDenied(int id);
        void NotifyEntryGranted(int id);
    }

    class EntryNotefication : IEntryNotefication
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