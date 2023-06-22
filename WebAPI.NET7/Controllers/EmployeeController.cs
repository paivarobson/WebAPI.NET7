using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.NET7.Model;
using WebAPI.NET7.ViewModel;

namespace WebAPI.NET7.Controllers
{
    [ApiController]
    [Route("api/v1/employee)")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName); // Cocatena o caminho da imagem com a pasta Storage dentro do projeto

            using Stream fileStream = new FileStream(filePath, FileMode.Create); // Cria a imagem em memória
            employeeView.Photo.CopyTo(fileStream); // Adiciona a imagem na pasta Storage 

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employees = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employees.photo);

            return File(dataBytes, "image/png");
        }
    }
}