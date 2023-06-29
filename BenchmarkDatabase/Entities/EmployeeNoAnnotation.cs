
using System.ComponentModel.DataAnnotations;

namespace BenchmarkDatabase.Entities
{
    public class EmployeeNoAnnotation
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int SerialNumber { get; set; }
        public string? Segment { get; set; }
        public string? WorkDescription { get; set; }
        public string? PersonalDescription { get; set; }
        public string? PerformanceNotes { get; set; }
        public string? BankAccount { get; set; }
        public string? BankNotes { get; set; }
        public string? TelephoneAccount { get; set; }
        public string? TelephoneNotes { get; set; }
    }
}
