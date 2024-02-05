using Microsoft.EntityFrameworkCore;
using StudentManagamentSystemBasic.Data;
using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.Repository
{
    public class classSectionRepository:IclassSection
    {
        private readonly ApplicationDbContext _context;

        public classSectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(classSection classSection)
        {
            _context.Add(classSection);
            return Save();
        }

        public bool Delete(classSection classSection)
        {
            _context.Remove(classSection);
            return Save();
        }

        public async Task<IEnumerable<classSection>> getAllSection()
        {
            return await _context.classSections.ToListAsync();
        }

        public async Task<classSection> getSectionById(int id)
        {
            return await _context.classSections.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<classSection>> getSectionByYear(string year)
        {
            return await _context.classSections.Where(c => c.Year == year).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(classSection classSection)
        {
            _context.Update(classSection);
            return Save();
        }
    }
}
