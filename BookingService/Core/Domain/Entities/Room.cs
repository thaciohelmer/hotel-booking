using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("rooms")]
    public class Room
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("level")]
        public int Level { get; set; }

        public Price Price { get; set; }

        [Column("in_maintenace")]
        public bool InMaintenace { get; set; }

        [Column("is_available")]
        public bool IsAvailable
        {
            get
            {
                if (InMaintenace || HasGuest) return false;
                else return true;
            }
        }
        public bool HasGuest
        {
            get
            {
                return true;
            }
        }
    }
}
