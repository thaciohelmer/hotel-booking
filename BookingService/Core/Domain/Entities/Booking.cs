using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    [Table("bookings")]
    public class Booking
    {
        public Booking()
        {
            this.Status = Status.Created;
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("placed_at")]
        public DateTime PlacedAt { get; set; }

        [Column("start")]
        public DateTime Start { get; set; }

        [Column("end")]
        public DateTime End { get; set; }

        [Column("room_id")]
        public int RoomId { get; set; }

        public Room Room { get; set; }

        [Column("guest_id")]
        public int GuestId { get; set; }

        public Guest Guest { get; set; }

        [Column("status")]
        private Status Status { get; set; }

        [Column("current_status")]
        public Status CurrentStatus { get { return Status; } }


        public void ChangeState(Action action)
        {
            Status = (Status, action) switch
            {
                (Status.Created, Action.Pay) => Status.Paid,
                (Status.Created, Action.Cancel) => Status.Canceled,
                (Status.Paid, Action.Finish) => Status.Finished,
                (Status.Paid, Action.Refound) => Status.Refounded,
                (Status.Canceled, Action.Reopen) => Status.Created,
                (_) => Status
            };
        }
    }
}
