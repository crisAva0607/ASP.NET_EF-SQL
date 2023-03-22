using Microsoft.AspNetCore.Mvc;
using RESUME_BUILDER.Models;
using System.Diagnostics;

namespace RESUME_BUILDER.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ResumeContext _context;

        public HomeController(ILogger<HomeController> logger, ResumeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var student = _context.Students.FirstOrDefault();

            var vm = new HomeViewModel();

            vm.FirstName = student.FirstName;
            vm.LastName = student.LastName;
            vm.MiddleName = student.MiddleName;
            vm.Role = student.Role;
            vm.Address = student.Address;
            vm.ContactNumber = student.ContactNumber;
            vm.Objective = student.Objective;

            var link = _context.Links
                               .Where(x => x.StudentId == student.Id)
                               .ToList();

            vm.LinkList = new List<Link1>();

            foreach (var i in link)
            {
                vm.LinkList.Add(new Link1 { Gmail = i.Gmail });
                vm.LinkList.Add(new Link1 { GitHub = i.Github });

            }

            var education = _context.EducationBgs
                                    .Where(x => x.StudentId == student.Id)
                                    .ToList();

            vm.EducationList = new List<Education1>();
            foreach (var i in education)
            {
                vm.EducationList.Add(new Education1 { School = i.School });
                vm.EducationList.Add(new Education1 { YearAttended = i.YearAttended });
                vm.EducationList.Add(new Education1 { Course = i.Course });

            }

            var skills = _context.Skills
                                 .Where(x => x.StudentId == student.Id)
                                 .ToList();

            vm.SkillList = new List<Skill1>();

            foreach (var i in skills)
            {
                vm.SkillList.Add(new Skill1 { skillName = i.SkillName });
            }

            var xp = _context.Experiences
                                 .Where(x => x.Id == student.Id)
                                 .ToList();
            vm.ExperienceList = new List<Experience1>();
            foreach (var i in xp)
            {
                vm.ExperienceList.Add(new Experience1 { role = i.Role });
                vm.ExperienceList.Add(new Experience1 { company = i.Company });

            }

            var tr = _context.Trainings
                                 .Where(x => x.Id == student.Id)
                                 .ToList();
            vm.TrainingList = new List<Training1>();
            foreach (var i in tr)
            {
                vm.TrainingList.Add(new Training1 { trainingName = i.TrainingName });
                vm.TrainingList.Add(new Training1 { yearAttended = i.YearAttended });

            }
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}