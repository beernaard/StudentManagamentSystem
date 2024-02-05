using System.ComponentModel.DataAnnotations;

namespace StudentManagamentSystemBasic.Models
{
    public class classSection
    {
        [Key]
        public int? Id { get; set; }

        public string? SectionName { get; set; }

        public string? Year { get; set; }
    }
}
