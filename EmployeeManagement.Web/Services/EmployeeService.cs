﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await _httpClient.PutJsonAsync<Employee>("api/employees", updatedEmployee);
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            return await _httpClient.PostJsonAsync<Employee>("api/employees", newEmployee);
        }
    }
}
