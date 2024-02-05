using Microsoft.EntityFrameworkCore;
using StudentManagamentSystemBasic.Data;
using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.Repository
{
    public class studentRepository: IStudent
    {
        private readonly ApplicationDbContext _context;

        public studentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Student student)
        {
            _context.Add(student);
            return Save();
        }

        public bool Delete(Student student)
        {
            _context.Remove(student);
            return Save();
        }

        public async Task<IEnumerable<Student>> getAllStudent()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> getStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Student> getStudentByIdNoTracking(int id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<IEnumerable<Student>> getStudentBySec(string sex)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> getStudentBySection(string section)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Student student)
        {
            _context.Update(student);
            return Save();
        }
    }
}
