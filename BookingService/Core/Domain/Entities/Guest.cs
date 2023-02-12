using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("guests")]
    public class Guest
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("identity_document")]
        public IdentityDocument IdentityDocument { get; set; }
    }
}
