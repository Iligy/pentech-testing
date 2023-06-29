using BenchmarkDatabase.Context;
using BenchmarkDatabase.Entities;
using BenchmarkDotNet.Engines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkTests.Repositories
{
    public class DatabaseRepo
    {
        // https://www.linkedin.com/pulse/difference-between-ienumerable-ilist-list-iqueryable-pawan-verma/

        private readonly BenchMarkContext _context;
        private readonly DbSet<Employee> _employeeSet;
        private readonly DbSet<EmployeeNoAnnotation> _employeeNoAnnotationSet;
        private readonly Consumer _consumer;
        public DatabaseRepo()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BenchMarkContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Initial Catalog=BrenchmarkTest;User=sa;Password=!234Password432!;TrustServerCertificate=True;");
            _context = new BenchMarkContext(optionsBuilder.Options);

            _employeeSet = _context.Employees;
            _employeeNoAnnotationSet = _context.EmployeesNoAnnotations;
            _consumer = new Consumer();
        }
       


        public void IEnumerableGetTopTenHFIEmployee()
        {
            IEnumerable<Employee> employees = _employeeSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();
           

            employees.OrderBy(e => e.Id).Take(10).Consume(_consumer);
        }

        public void IQueryableGetTopTenHFIEmployee()
        {
            IQueryable<Employee> employees = _employeeSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000);

            employees.OrderBy(e => e.Id).Take(10).ToList();
        }

        public void IListGetTopTenHFIEmployee()
        {
            IList<Employee> employees = _employeeSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();

            employees.OrderBy(e => e.Id).Take(10);
        }

        public void ICollectionTopTenHFIEmployee()
        {
            ICollection<Employee> employees = _employeeSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();

            employees.OrderBy(e => e.Id).Take(10);
        }

        public void ListTopTenHFIEmployee()
        {
            List<Employee> employees = _employeeSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();

            employees.OrderBy(e => e.Id).Take(10);
        }

        // no annotation

        public void IEnumerableGetTopTenHFIEmployeeNoAnno()
        {
            IEnumerable<EmployeeNoAnnotation> employeesNoAnno = _employeeNoAnnotationSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();


            employeesNoAnno.OrderBy(e => e.Id).Take(10).Consume(_consumer);
        }

        public void IQueryableGetTopTenHFIEmployeeNoAnno()
        {
            IQueryable<EmployeeNoAnnotation> employeesNoAnno = _employeeNoAnnotationSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000);

            employeesNoAnno.OrderBy(e => e.Id).Take(10).ToList();
        }

        public void IListGetTopTenHFIEmployeeNoAnno()
        {
            IList<EmployeeNoAnnotation> employeesNoAnno = _employeeNoAnnotationSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();

            IList<EmployeeNoAnnotation> data = employeesNoAnno.OrderBy(e => e.Id).Take(10).ToList();
        }

        public void ICollectionTopTenHFIEmployeeNoAnno()
        {
            ICollection<EmployeeNoAnnotation> employeesNoAnno = _employeeNoAnnotationSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();

            ICollection<EmployeeNoAnnotation> data = employeesNoAnno.OrderBy(e => e.Id).Take(10).ToList();
        }

        public void ListTopTenHFIEmployeeNoAnno()
        {
            List<EmployeeNoAnnotation> employeesNoAnno = _employeeNoAnnotationSet
                .Where(e => e.Segment == "HFI"
                && e.PerformanceNotes.Contains("Lorem"))
                .Take(100000)
                .ToList();

            List<EmployeeNoAnnotation> data = employeesNoAnno.OrderBy(e => e.Id).Take(10).ToList();
        }
    }
}
