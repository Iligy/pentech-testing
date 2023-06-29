using BenchmarkDatabase.Context;
using BenchmarkDatabase.Entities;
using BenchmarkDotNet.Engines;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkTests.Repositories
{
    public class InMemoryRepo
    {
        private readonly IEnumerable<string> _IEnumerableStrings = new List<string>();
        private readonly IQueryable<string> _IQueryableStrings = new List<string>().AsQueryable();
        private readonly IList<string> _IListStrings = new List<string>();
        private readonly ICollection<string> _ICollectionStrings = new List<string>();
        private readonly List<string> _strings = new List<string>();

        private readonly BenchMarkContext _context;
        private readonly DbSet<Employee> _employeeSet;
        private readonly DbSet<EmployeeNoAnnotation> _employeeNoAnnotationSet;
        private readonly Consumer _consumer;

        public InMemoryRepo()
        {

            var optionsBuilder = new DbContextOptionsBuilder<BenchMarkContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Initial Catalog=BrenchmarkTest;User=sa;Password=!234Password432!;TrustServerCertificate=True;");
            _context = new BenchMarkContext(optionsBuilder.Options);
            _employeeSet = _context.Employees;
            _employeeNoAnnotationSet = _context.EmployeesNoAnnotations;
            _consumer = new Consumer();
 
        }

        public void IEnumerableEmployeeLoopTest()
        {
            IEnumerable<Employee> employees = _employeeSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            employees.Consume(_consumer);


            foreach (Employee employee in employees) 
            {
                employee.Email = "fakeemailsending@example.com";
                employee.PerformanceNotes = "good";
            }

        }

        public void IQueryableEmployeeLoopTest()
        {
            IQueryable<Employee> employees = _employeeSet
             .Where(e => e.Segment == "HFI")
             .Take(10000);

            employees.ToList();


            foreach (Employee employee in employees)
            {
                employee.Email = "fakeemailsending@example.com";
                employee.PerformanceNotes = "good";
            }
        }

        public void IListLoopEmployeeTest()
        {
            IList<Employee> employees = _employeeSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            var a = employees[1];

            foreach (Employee employee in employees)
            {
                employee.Email = "fakeemailsending@example.com";
                employee.PerformanceNotes = "good";
            }
        }

        public void ICollectionEmployeeLoopTest()
        {
            ICollection<Employee> employees = _employeeSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            foreach (Employee employee in employees)
            {
                employee.Email = "fakeemailsending@example.com";
                employee.PerformanceNotes = "good";
            }
        }

        public void ListLoopEmployeeTest()
        {
            List<Employee> employees = _employeeSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            foreach (Employee employee in employees)
            {
                employee.Email = "fakeemailsending@example.com";
                employee.PerformanceNotes = "good";
            }
        }

        public void IEnumerableEmployeeNoAnoLoopTest()
        {
            IEnumerable<EmployeeNoAnnotation> employeesNoAnos = _employeeNoAnnotationSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            foreach (EmployeeNoAnnotation employeeNoAno in employeesNoAnos)
            {
                employeeNoAno.Email = "fakeemailsending@example.com";
                employeeNoAno.PerformanceNotes = "good";
            }
        }

        public void IQueryableEmployeeNoAnoLoopTest()
        {
            IQueryable<EmployeeNoAnnotation> employeesNoAnos = _employeeNoAnnotationSet
             .Where(e => e.Segment == "HFI")
             .Take(10000);

             employeesNoAnos.ToList();

            foreach (EmployeeNoAnnotation employeeNoAno in employeesNoAnos)
            {
                employeeNoAno.Email = "fakeemailsending@example.com";
                employeeNoAno.PerformanceNotes = "good";
            }
        }

        public void IListLoopEmployeeNoAnoTest()
        {
            IList<EmployeeNoAnnotation> employeesNoAnos = _employeeNoAnnotationSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            foreach (EmployeeNoAnnotation employeeNoAno in employeesNoAnos)
            {
                employeeNoAno.Email = "fakeemailsending@example.com";
                employeeNoAno.PerformanceNotes = "good";
            }
        }

        public void ICollectionEmployeeNoAnoLoopTest()
        {
            ICollection<EmployeeNoAnnotation> employeesNoAnos = _employeeNoAnnotationSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            foreach (EmployeeNoAnnotation employeeNoAno in employeesNoAnos)
            {
                employeeNoAno.Email = "fakeemailsending@example.com";
                employeeNoAno.PerformanceNotes = "good";
            }
        }

        public void ListLoopEmployeeNoAnoTest()
        {
            List<EmployeeNoAnnotation> employeesNoAnos = _employeeNoAnnotationSet
             .Where(e => e.Segment == "HFI")
             .Take(10000)
             .ToList();

            foreach (EmployeeNoAnnotation employeeNoAno in employeesNoAnos)
            {
                employeeNoAno.Email = "fakeemailsending@example.com";
                employeeNoAno.PerformanceNotes = "good";
            }
        }
    }
}
