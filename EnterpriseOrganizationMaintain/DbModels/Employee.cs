using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EnterpriseOrganizationMaintain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }


        public GenderEnum GenderType
        {
            get { return (GenderEnum)Gender; }
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderEnum
    {
        Male = 0,
        Female = 1,
        Others = 2
    }
}
