using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.Repository
{
    public interface IclassSection
    {
        Task<IEnumerable<classSection>> getAllSection();
        Task<classSection> getSectionById(int id);
        Task<IEnumerable<classSection>> getSectionByYear(string year);
        bool Add(classSection classSection);
        bool Update(classSection classSection);
        bool Delete(classSection classSection);
        bool Save();
    }
}
