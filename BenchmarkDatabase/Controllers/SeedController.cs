using BenchmarkDatabase.Context;
using BenchmarkDatabase.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenchmarkDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly BenchMarkContext _context;
        private string lorem = "Contrary to popular belief, Lorem Ipsum is not simply random text.";

        public SeedController(BenchMarkContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("seed-employees")]
        public async Task<IActionResult> SeedEmployeesAsync() 
        {
            try
            {
                if (!_context.Employees.Any())
                {
                    List<Employee> employeesToAdd = new();
                    string[] segments = { "HFI", "HMA", "HOL", "HFF" };

                    for (int i = 0; i < 3_000_000; i++)
                    {
                        Random random = new Random();
                        int segmentKey = random.Next(0, segments.Length);

                        Employee employee = new Employee()
                        {
                            Username = $"User{i}",
                            Email = $"employeeemail{i}@text.com",
                            SerialNumber = i,
                            Segment = segments[segmentKey],
                            WorkDescription = lorem,
                            PersonalDescription = lorem,
                            PerformanceNotes = lorem,
                            BankAccount = lorem,
                            BankNotes = lorem,
                            TelephoneAccount = lorem,
                            TelephoneNotes = lorem
                        };

                        employeesToAdd.Add(employee);
                    }

                    await _context.Employees.AddRangeAsync(employeesToAdd);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("Employee table is not empty");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
   
        }

        [HttpPost]
        [Route("seed-employees-no-annotation")]
        public async Task<IActionResult> SeedEmployeesNoAnnotationAsync()
        {
            try
            {
                if (!_context.EmployeesNoAnnotations.Any())
                {
                    List<EmployeeNoAnnotation> employeeNoAnnotationsToAdd = new();
                    string[] segments = { "HFI", "HMA", "HOL", "HFF" };
                    ;

                    for (int i = 0; i < 3_000_000; i++)
                    {
                        Random random = new Random();
                        int segmentKey = random.Next(0, segments.Length);

                        EmployeeNoAnnotation employeeNoAnnotation = new EmployeeNoAnnotation()
                        {
                            Username = $"NoAnoUser{i}",
                            Email = $"employeeemail{i}@text.com",
                            SerialNumber = i,
                            Segment = segments[segmentKey],
                            WorkDescription = lorem,
                            PersonalDescription = lorem,
                            PerformanceNotes = lorem,
                            BankAccount = lorem,
                            BankNotes = lorem,
                            TelephoneAccount = lorem,
                            TelephoneNotes = lorem
                        };

                        employeeNoAnnotationsToAdd.Add(employeeNoAnnotation);
                    }

                    await _context.EmployeesNoAnnotations.AddRangeAsync(employeeNoAnnotationsToAdd);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("EmployeesNoAnnotation table is not empty");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
