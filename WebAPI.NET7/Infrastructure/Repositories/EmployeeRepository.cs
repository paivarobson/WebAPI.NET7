using WebAPI.NET7.Domain.DTOs;
using WebAPI.NET7.Domain.Model;

namespace WebAPI.NET7.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        void IEmployeeRepository.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        List<EmployeeDTO> IEmployeeRepository.Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees
                .Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(x =>
                new EmployeeDTO()
                {
                    Id = x.id,
                    NameEmployee = x.name,
                    Photo = x.photo
                }).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}