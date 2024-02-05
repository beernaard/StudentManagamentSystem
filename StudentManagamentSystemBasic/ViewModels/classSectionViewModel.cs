using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.ViewModels
{
    public class classSectionViewModel
    {
        public string? SectionName { get; set; }
        public int? Id { get; set; }

        public string? Year { get; set; }
        public int? TotalStudentbySection { get; set; }
        public IEnumerable<Student>? students { get; set; }
        public int? Male { get; set; }
        public int? Female { get; set; }
    }
}
