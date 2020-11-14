using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Tour : AuditableBaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(250)")]

        public string FromWhere { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ToWhere { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Notes { get; set; }

        public int NumberOfSeats { get; set; }

        public string Status { get; set; }
        public bool IsActive { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
