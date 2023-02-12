using Entities = Domain.Entities;
using Domain.ValueObjects;
using Domain.Enums;

namespace Application.Guest.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public int DocumentType { get; set; }

        public static Entities.Guest MapToEntity(GuestDTO guest)
        {
            return new Entities.Guest
            {
                Id = guest.Id,
                Name = guest.Name,
                LastName = guest.LastName,
                Email = guest.Email,
                IdentityDocument = new IdentityDocument
                {
                    IdentityNumber = guest.IdentityNumber,
                    DocumentType = (DocumentType)guest.DocumentType
                }
            };
        }

        public static GuestDTO MapToDto(Entities.Guest guest)
        {
            return new GuestDTO
            {
                Id = guest.Id,
                Name = guest.Name,
                LastName = guest.LastName,
                Email = guest.Email,
                DocumentType = (int)guest.IdentityDocument.DocumentType,
                IdentityNumber = guest.IdentityDocument.IdentityNumber
            };
        }
    }
}
