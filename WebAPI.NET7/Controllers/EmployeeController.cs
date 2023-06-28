using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.NET7.Domain.DTOs;
using WebAPI.NET7.Domain.Model;
using WebAPI.NET7.ViewModel;

namespace WebAPI.NET7.Controllers
{
    [ApiController]
    [Route("api/v1/employee)")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Information, "Adicionando novo funcionário...");

            var employees = _employeeRepository.Get(pageNumber, pageQuantity);

            _logger.LogInformation("Funcionário adicionado com sucesso");

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employees = _employeeRepository.Get(id);

            var employeesDTOs = _mapper.Map<EmployeeDTO>(employees);

            return Ok(employeesDTOs);
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