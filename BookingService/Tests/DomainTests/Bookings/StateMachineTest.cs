using NUnit.Framework;
using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings
{
    public class StateMachineTest
    {
        [Test]
        public void CreatedWithStatusCreated()
        {
            var booking = new Booking();
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void SetStatusPaidAfterPay()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void SetStatusCanceledAfterCancel()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        }

        [Test]
        public void SetStatusFinishedAfterFinish()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Finish);
            Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        }

        [Test]
        public void SetStatusRefoundedAfterRefound()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Refounded);
        }

        [Test]
        public void SetStatusCreatedAfterReopen()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            booking.ChangeState(Action.Reopen);
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void ErrorOnRefoundOnCreated()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void ErrorOnRefoundOnFinished()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Finish);
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        }
    }
}
