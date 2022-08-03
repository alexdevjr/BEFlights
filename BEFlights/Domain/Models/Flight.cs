using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFlights.Domain.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Origin { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Destination { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int FlightNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Airline { get; set; }
        public DateTime Depart { get; set; }
        public DateTime Arrive { get; set; }
        public bool Nonstop { get; set; }
    }
}
