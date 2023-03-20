using Projekat.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;


namespace Projekat.Core.Domain.Entities
{   
    [Index(nameof(Employee.Name), IsUnique = true)]  // proveri dal je ovo dobro
    public class Employee
    {
        public Guid Id { get; set; } 
        public String Name { get; set; }
        public String Username { get; set; }
        public double HoursPerWeek { get; set; }
        public String Email { get; set; }
        public Role Role { get; set; }
        public Status Status { get; set; }  

        public Employee(Guid id, string name, string username, double hoursPerWeek, string email, Role role, Status status)
        {
            Id = id;
            Name = name;
            Username = username;
            HoursPerWeek = hoursPerWeek;
            Email = email;
            Status = status;
            Role = role;
        }

        public override string ToString()
        {
            return "Name " + Name + "Username  " + Username +  "Hours per week " + HoursPerWeek + "Email " + Email + "Role " + Role +  "Status " + Status.ToString();
        }
    }
}