using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagamentSystemBasic.Data;
using StudentManagamentSystemBasic.Models;
using StudentManagamentSystemBasic.Repository;
using StudentManagamentSystemBasic.ViewModels;
using System.Diagnostics;

namespace StudentManagamentSystemBasic.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudent _studentRepository;
        public StudentController(ApplicationDbContext context, IStudent studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> student = await _studentRepository.getAllStudent();
            IEnumerable<classSection> classsection = await _context.classSections.ToListAsync();
            var svm = new studentViewModel
            {
                listofstudents = student,
                listofclasssections = classsection
            };
            return View(svm);
        }
        public async Task<IActionResult> Details(int id)
        {
            Student student = await _studentRepository.getStudentById(id);
            classSection classsection = await _context.classSections.FirstOrDefaultAsync(x=>x.Id==student.classSectionId);
            if (classsection == null)
            {
                var svm2 = new studentViewModel
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Sex = student.Sex,
                    SectionName = "",
                    Year = "",
                };
                return View(svm2);
            };
            var svm = new studentViewModel
            {
                Id = student.Id,
                FirstName= student.FirstName,
                LastName= student.LastName,
                Sex = student.Sex,
                Year = classsection.Year,
                SectionName = classsection.SectionName,
            };
            return View(svm);
        }
        public async Task<IActionResult> Create()
        {
            IEnumerable<classSection> cs = _context.classSections.ToList();
            var vm = new studentViewModel
            {
                listofclasssections=cs
            };
            return View(vm);
        }
        public JsonResult sectionlist(string val)
        {
            var data = _context.classSections.Where(x => x.Year == val).ToList();
            return new JsonResult(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(studentViewModel vmstudent)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error");
            }
            var csId= await _context.classSections.Where(x=>x.Year==vmstudent.Year).Where(y=>y.SectionName==vmstudent.SectionName).FirstOrDefaultAsync();
            Student student = new Student
            {
                FirstName = vmstudent.FirstName,
                LastName = vmstudent.LastName,
                Sex = vmstudent.Sex,
                classSectionId=csId.Id
            };
            _studentRepository.Add(student);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.getStudentById(id);
            classSection classection = await _context.classSections.FirstOrDefaultAsync(x=>x.Id==student.classSectionId);
            if (student == null) return View("Error");
            if (classection == null)
            {
                var svm2 = new studentViewModel
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Sex = student.Sex,
                    SectionName = "",
                    Year = "",
                };
                return View(svm2);
            };
            var svm = new studentViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Sex = student.Sex,
                SectionName=classection.SectionName,
                Year=classection.Year,
            };
            return View(svm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, studentViewModel svm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit student");
                return View("Edit", svm);
            }
            var csId = await _context.classSections.Where(x => x.Year == svm.Year).Where(y => y.SectionName == svm.SectionName).FirstOrDefaultAsync();
            var newStudentModel = new Student
            {
                Id = id,
                FirstName = svm.FirstName,
                LastName = svm.LastName,
                Sex = svm.Sex,
                classSectionId= csId.Id,
            };
            _studentRepository.Update(newStudentModel);
            return RedirectToAction("Details", new { id = id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.getStudentById(id);
            if (student == null) return View("Error");
            _studentRepository.Delete(student);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
