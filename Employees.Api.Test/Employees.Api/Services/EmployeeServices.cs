﻿using AutoMapper;
using Employees.Api.Context;
using Employees.Api.Dtos;
using Employees.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Api.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeContext _context;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                _context.Employees.Add(_mapper.Map<Employee>(employeeDto));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

    }
}
