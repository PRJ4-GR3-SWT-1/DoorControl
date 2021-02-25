namespace DoorControlNS
{
    public interface IUserValidation
    {
        public bool ValidateEntryRequest(int id);

    }

    public  class UserValidation : IUserValidation
    {
        public bool ValidateEntryRequest(int id)
        {
            return true;
        }
    }
}