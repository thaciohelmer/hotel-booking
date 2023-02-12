using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    public class Price
    {
        [Column("value")]
        public decimal Value { get; set; }

        [Column("currency")]
        public Currency Currency { get; set; }
    }
}
