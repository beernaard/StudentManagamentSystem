using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.Repository
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> getAllStudent();
        Task<Student> getStudentById(int id);
        Task<Student> getStudentByIdNoTracking(int id);

        Task<IEnumerable<Student>> getStudentBySection(string section);
        Task<IEnumerable<Student>> getStudentBySec(string sex);

        bool Add(Student student);
        bool Update(Student student);
        bool Delete(Student student);
        bool Save();
    }
}
