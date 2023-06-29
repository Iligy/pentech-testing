using System.ComponentModel.DataAnnotations;

namespace BenchmarkDatabase.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Email { get; set; }

        public int SerialNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string? Segment { get; set; }

        [Required]
        [MaxLength(100)]
        public string? WorkDescription { get; set; }

        [Required]
        [MaxLength(100)]
        public string? PersonalDescription { get; set; }

        [Required]
        [MaxLength(100)]
        public string? PerformanceNotes { get; set; }

        [Required]
        [MaxLength(100)]
        public string? BankAccount { get; set; }

        [Required]
        [MaxLength(100)]
        public string? BankNotes { get; set; }

        [Required]
        [MaxLength(100)]
        public string? TelephoneAccount { get; set; }

        [Required]
        [MaxLength(100)]
        public string? TelephoneNotes { get; set; }
    }
}
