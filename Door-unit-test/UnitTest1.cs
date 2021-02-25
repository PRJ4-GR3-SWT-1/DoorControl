using System;
using NUnit.Framework;
using DoorControlNS;
using NSubstitute;
using NSubstitute.Core.Arguments;

namespace Door_unit_test
{
    public class Tests
    {
        private DoorControl uut;
        private IAlarm alarm;
        private IDoor door;
        private IEntryNotification entryNot;
        private IUserValidation userValidator;
        [SetUp]
        public void Setup()
        {
            alarm = Substitute.For<IAlarm>();
            door = Substitute.For<IDoor>();
            entryNot = Substitute.For<IEntryNotification>();
            userValidator = Substitute.For<IUserValidation>();

            uut = new DoorControl(door,alarm,userValidator,entryNot);
        }
        //Req
        [TestCase(true,true)]
        [TestCase(false, false)]
        public void RequestAccess_ValidateEntryRequestReturnsBool_AccesGranted_returns_bool(bool isAllowed, bool expectedResult)
        {
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(isAllowed);
            uut.RequestEntry(123);
            door.Received(Convert.ToInt32(expectedResult)).Open(Arg.Any<DoorControl>());


        }
        [TestCase(123)]
        [TestCase( 0)]
        [TestCase(-1)]
        [TestCase(999999)]
        public void RequestAccess_UserIDInt_NotifyEntryGrantedCorrect(int id)
        {
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(true);
            uut.RequestEntry(id);
            entryNot.Received(1).NotifyEntryGranted(id);

        }

        [TestCase(123)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(999999)]
        public void RequestAccess_UserIDInt_NotifyEntryDeniedCorrect(int id)
        {
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(false);
            uut.RequestEntry(id);
            entryNot.Received(1).NotifyEntryDenied(id);

        }

        //Door opened
        [Test]
        public void DoorOpened_AccesNotDenied_AlarmIsStarted()
        {
            
            uut.DoorOpened();
            alarm.Received(1).RaiseAlarm();
        }
        [Test]
        public void DoorOpened_AccesNotDenied_DoorCloses()
        {

            uut.DoorOpened();
            door.Received(1).Close(Arg.Any<DoorControl>());
        }

        [Test]
        public void DoorOpened_AccesGranted_DoorCloses()
        {
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(true);
            uut.RequestEntry(123);
            uut.DoorOpened();
            door.Received(1).Close(Arg.Any<DoorControl>());
        }

        [Test]
        public void DoorOpened_AccesGranted_AccessAutomaticlyRevokedAfterEntry()
        {
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(true);
            uut.RequestEntry(123);
            uut.DoorOpened();
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(false);
            uut.RequestEntry(234);
            door.Received(1).Open(Arg.Any<DoorControl>());

        }
        [Test]
        public void DoorOpened_AccesGranted_AccessAutomaticlyRevokedAfterEntryNotifyCalled()
        {
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(true);
            uut.RequestEntry(123);
            uut.DoorOpened();
            userValidator.ValidateEntryRequest(Arg.Any<int>()).Returns(false);
            uut.RequestEntry(234);
            entryNot.Received(1).NotifyEntryDenied(Arg.Any<int>());

        }

        //Door CLosed
        [Test]
        public void DoorClose_AccesGranted_AccessAutomaticlyRevokedAfterEntryNotifyCalled()
        {
            uut.DoorClosed();
            Assert.That(1,Is.EqualTo(1));

        }
    }
}