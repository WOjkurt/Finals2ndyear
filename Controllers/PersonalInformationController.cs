using JwtAuthDemo.Helpers;
using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static JwtAuthDemo.Helpers.PersonalInformationHelper;

namespace JwtAuthDemo.Controllers
{
      public class PersonalInfomationsController : Controller
    {
        private readonly PersonalInformationsHelper _context;
        private Appdatacontext _appdatacontext;

        public PersonalInfomationsController(Appdatacontext context)
        {
            _context = new PersonalInformationsHelper(context);
            _appdatacontext = context;
        }

        public ActionResult Droptable(PersonalInformation model)
        {

            return View();

        }


        // GET: PersonalInfomationController
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: PersonalInfomation/Details/5
        public ActionResult Details(int id)
        {
            var personal = _context.Fetch(id);
            return View(personal);
        }

        // GET: PersonalInfomation/Create
        public ActionResult Create()
        {
            var dto = new PersonalInfomationDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.PersonalInfomation = new PersonalInformation();
            dto.PersonalInfomation.Employee = new Employee();
            return View(dto);
        }
        public JsonResult SaveEmployee(PersonalInformation model)
        {
            var response = _context.Create(model);


            return Json(response);
        }

        // POST: EmployeeController/Create
        [HttpPost("CreatePersonalInfomation")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePersonalInfomation(PersonalInfomationDto personalInfomationDto)
        {
            personalInfomationDto.PersonalInfomation.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == personalInfomationDto.PersonalInfomation.Id).FirstOrDefault();
            // Map DTO to the actual model entity
            var personal = new PersonalInformation
            {
                Id = 0,
                BirthDate = personalInfomationDto.PersonalInfomation.BirthDate,
                Religion = personalInfomationDto.PersonalInfomation.Religion,
                Citizenship = personalInfomationDto.PersonalInfomation.Citizenship,
                PermanentAddress = personalInfomationDto.PersonalInfomation.PermanentAddress,
                Height = personalInfomationDto.PersonalInfomation.Height,
                Weight = personalInfomationDto.PersonalInfomation.Weight,
                BloodType = personalInfomationDto.PersonalInfomation.BloodType,
                PersonContactedInCaseOfEmergency = personalInfomationDto.PersonalInfomation.PersonContactedInCaseOfEmergency,
                ContactNumber = personalInfomationDto.PersonalInfomation.ContactNumber
            };


            // Save to the database
            _appdatacontext.PersonalInformation.Add(personal);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            personalInfomationDto.Employees = _appdatacontext.Employee.ToList();
            return View(personalInfomationDto);
        }

        // GET: PersonalInfomation/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Fetch(id));
        }

        // POST: PersonalInfomations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalInformation model, int id)
        {
            try
            {
                var response = _context.Update(model, id);
                return RedirectToAction("Confirmation", new { message = "Data Updated successfully!" });
                
            }
            catch
            {
                return View();
            }
        }

        // GET: PerosonalInfomations/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Fetch(id));
        }

        // POST: PersonalInfomation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PersonalInformation collection)
        {
            try
            {
                var response = _context.Delete(id);
                return RedirectToAction("Confirmation", new { message = "Data Deleted successfully!" });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirmation(string message)
        {
            return View((object)message);
        }
    }
}
