using Domain.Exceptions;
using Domain.ValueObjects;
using Domain.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Ports;

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
        public string Email { get; set; }

        [Column("identity_document")]
        public IdentityDocument IdentityDocument { get; set; }


        private void ValidateState()
        {
            if (IdentityDocument == null || IdentityDocument.IdentityNumber.Length <= 3) throw new InvalidIdentityDocument();
            if (Name == null || LastName == null || Email == null) throw new MissingRequiredInfos();
            if(!Utils.Utils.ValidateEmail(Email)) throw new InvalidEmail();
        }

        public async Task Save(IGuestRepository repository)
        {
            ValidateState();
            if (Id == 0) Id = await repository.Create(this);
            //else await repository.Update(this);
        }
    }
}
