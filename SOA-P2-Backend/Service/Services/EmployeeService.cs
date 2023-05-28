﻿using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly EmployeeRepository empleoyeeRepository;

        public EmployeeService(ILogger<EmployeeService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            empleoyeeRepository = new EmployeeRepository(context);
        }

        public List<Empleado> GetAll()
        {
            List<Empleado> empleaoyees = new List<Empleado>();

            try
            {
                empleaoyees = empleoyeeRepository.GetList();
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
            }

            return empleaoyees;
        }
    }
}
