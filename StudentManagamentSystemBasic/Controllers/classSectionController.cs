using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagamentSystemBasic.Data;
using StudentManagamentSystemBasic.Models;
using StudentManagamentSystemBasic.Repository;
using StudentManagamentSystemBasic.ViewModels;

namespace StudentManagamentSystemBasic.Controllers
{
    public class classSectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IclassSection _classSectionRepository;
        public classSectionController(ApplicationDbContext context, IclassSection classSectionRepository)
        {
            _context = context;
            _classSectionRepository = classSectionRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<classSection> classSection = await _classSectionRepository.getAllSection();
            IEnumerable<Student> student = await _context.Students.ToListAsync();
            var svm = new studentViewModel
            {
                listofclasssections = classSection,
                listofstudents = student
            };
            return View(svm);
        }
        public async Task<IActionResult> Details(int id)
        {
            classSection classsection = await _classSectionRepository.getSectionById(id);
            var scount = _context.Students.Where(c=>c.classSectionId == classsection.Id).Count();
            var fCount = _context.Students.Where(x => x.Sex == "Female").Where(c => c.classSectionId == classsection.Id).Count();
            var mCount = _context.Students.Where(x => x.Sex == "Male").Where(c => c.classSectionId == classsection.Id).Count();
            var svm = new classSectionViewModel
            {
                Id= id,
                Male = mCount,
                Female = fCount,
                Year = classsection.Year,
                SectionName = classsection.SectionName,
                TotalStudentbySection = scount
            };
            return View(svm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(classSectionViewModel csvm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error");
            }

            classSection classsection = new classSection
            {
                SectionName = csvm.SectionName,
                Year = csvm.Year
            };
            _classSectionRepository.Add(classsection);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var classsection = await _classSectionRepository.getSectionById(id);
            if (classsection == null) return View("Error");
            var svm = new classSectionViewModel
            {
                Id= id,
                SectionName=classsection.SectionName,
                Year = classsection.Year,
            };
            return View(svm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, classSectionViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit student");
                return View("Edit", cvm);
            }
            var newcs = new classSection
            {
                Id=id,
                SectionName=cvm.SectionName,
                Year=cvm.Year,
            };
            _classSectionRepository.Update(newcs);
            return RedirectToAction("Details", new { id = id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _classSectionRepository.getSectionById(id);
            if (student == null) return View("Error");
            _classSectionRepository.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
