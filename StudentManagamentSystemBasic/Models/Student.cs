using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagamentSystemBasic.Models
{
    public class Student
    {
        [Key]
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Sex { get; set; }
        [ForeignKey("classSection")]
        public int? classSectionId { get; set; }
    }
}
