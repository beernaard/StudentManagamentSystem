using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.ViewModels
{
    public class studentViewModel
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Sex { get; set; }
        public string? Year { get; set; }
        public string? SectionName { get; set; }
        public IEnumerable<classSection>? listofclasssections { get; set; }
        public IEnumerable<Student>? listofstudents { get; set; }
        public classSection? classSections { get; set; }
    }
}
