using System.ComponentModel.DataAnnotations;

namespace EnterpriseOrganizationMaintain.Models
{
    public class HrData
    {
        [Key]
        public int Id { get; set; }
        public int SecurityNumber { get; set; }
        public int Salary { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int EmployeeId { get; set; }

    }
}
