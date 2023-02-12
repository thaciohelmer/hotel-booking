using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    public class IdentityDocument
    {
        [Column("identity_number")]
        public string IdentityNumber { get; set; }

        [Column("document_type")]
        public DocumentType DocumentType { get; set; }
    }
}
