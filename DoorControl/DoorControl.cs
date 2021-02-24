using System;
using System.Threading;

namespace DoorControl
{
    public class DoorControl
    {
        public DoorControl(IDoor door, IEntryNotification entryNot, IAlarm alarm, IUserValidation userValidator, IEntryNotification entryNotification)
        {
            _door = door;
            _alarm = alarm;
            _userValidator = userValidator;
            _entryNotification = entryNotification;
        }
        public void RequestEntry(int id)
        {
            _allowedAcces = _userValidator.ValidateEntryRequest(id);
            if (_allowedAcces)
            {
                _door.Open();
                _entryNotification.NotifyEntryGranted(id);
            }
            else
            {
                _entryNotification.NotifyEntryDenied(id);
            }

        }

        public void DoorOpened()
        {
            if (_allowedAcces) { 
                Thread.Sleep(1000);
                _door.Close();
            }
            else
            {
                _door.Close();
                _alarm.RaiseAlarm();
            }
        }

        public void DoorClosed()
        {
            Console.WriteLine("Door closed. Ready for action");
        }

        private IDoor _door;
        private IUserValidation _userValidator;
        private IEntryNotification _entryNotification;
        private IAlarm _alarm;
        private bool _allowedAcces = false;


    }
}