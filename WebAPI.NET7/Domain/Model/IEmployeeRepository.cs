﻿using WebAPI.NET7.Domain.DTOs;

namespace WebAPI.NET7.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}