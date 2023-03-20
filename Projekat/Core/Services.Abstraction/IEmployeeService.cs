using Projekat.Core.Domain.Entities;
using Projekat.Core.Contract;

namespace Projekat.Core.Services.Abstraction
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();  
        Employee GetEmployee(Guid id);  
        Employee InsertEmployee(EmployeeDtoInsert employee);  
        void UpdateEmployee(Employee employee);  
        void DeleteEmployee(Guid id);  
        
                
    }
}