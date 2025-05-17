using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Models
{
    public class PersonalInfomationDto
    {
        public PersonalInformation PersonalInfomation { get; set; }
        public List<Employee> Employees { get; set; }

        public int EmployeeId { get; set; }
    }
}