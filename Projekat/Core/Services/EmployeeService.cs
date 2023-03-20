using Projekat.Core.Services.Abstraction;
using Projekat.Core.Domain;
using Projekat.Core.Domain.Entities;
using Projekat.Core.Contract;
using Projekat.Core.Domain.Enums;
using Projekat.Core.Domain.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Projekat.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployee(Guid id)
        {
            Employee gotEmployee = _repository.Get(id);

            if (gotEmployee is null)
            {
                throw new EmployeeNotFoundException(id);
            }
            else
            {
                return gotEmployee;
            }
        }

        public Employee InsertEmployee([FromBody] EmployeeDtoInsert dto)
        {
            Employee employee = new Employee(Guid.NewGuid(), dto.Name, dto.Username, dto.HoursPerWeek, dto.Email, (Role)Enum.Parse(typeof(Role), dto.Role), (Status)Enum.Parse(typeof(Status), dto.Status));
            _repository.Create(employee);
            _repository.SaveChanges();

            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee foundEmployee = GetEmployee(employee.Id);

            if (foundEmployee is null)
            {
                throw new EmployeeNotFoundException(employee.Id);
            }

            foundEmployee.Name = employee.Name;
            foundEmployee.Username = employee.Username;
            foundEmployee.HoursPerWeek = employee.HoursPerWeek;
            foundEmployee.Email = employee.Email;
            foundEmployee.Role = employee.Role;
            foundEmployee.Status = employee.Status;
            _repository.Update(foundEmployee);
            _repository.SaveChanges();
        }

        public void DeleteEmployee(Guid id)
        {
            Employee foundEmployee = GetEmployee(id);

            if (foundEmployee is null)
            {
                throw new EmployeeNotFoundException(id);
            }
            _repository.Remove(foundEmployee);
            _repository.SaveChanges();
        }
    }
}