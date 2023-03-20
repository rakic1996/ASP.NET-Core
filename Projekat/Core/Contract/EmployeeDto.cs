namespace Projekat.Core.Contract
{
    public class EmployeeDto
    {
        public Guid Id { get; set; } 
        public String Name { get; set; }
        public String Username { get; set; }
        public double HoursPerWeek { get; set; }
        public String Email { get; set; }
        public String Role {get; set;}
        public String Status {get; set;}
    }
}