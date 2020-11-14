using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Reservation : AuditableBaseEntity
    {

        public int TourId { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerFullName { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerPhone { get; set; }

        public int NumberOfPerson { get; set; }
        public bool IsActive { get; set; }

        public Tour Tour { get; set; }

    }
}