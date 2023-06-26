using WebAPI.NET7.Model;

namespace WebAPI.NET7.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        void IEmployeeRepository.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        List<Employee> IEmployeeRepository.Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}

