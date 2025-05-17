using JwtAuthDemo.Helpers;
using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace JwtAuthDemo.Controllers
{
    public class CertificationsandLicencesController : Controller
    {
        private readonly CertificationsandLicencesHelper _context;
        private readonly Appdatacontext _appdatacontext;

        public CertificationsandLicencesController(Appdatacontext context)
        {
            _context = new CertificationsandLicencesHelper(context);
            _appdatacontext = context;

        }
        public ActionResult Droptable(CertificationsLicensces model)
        {

            return View();

        }

        // GET: CertificationsAndlicenses
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: CertificationsAndlicenses/Details/5
        public ActionResult Details(int id)
        {
            var certificate = _context.Fetch(id);
            return View(certificate);
        }

        // GET: CertificationsAndlicenses/Create
        public ActionResult Create()
        {
            var dto = new CertificationsAndLisencesDto();
            dto.Employee = _appdatacontext.Employee.ToList();
            dto.CertificationsAndlicenses = new CertificationsLicensces();
            dto.CertificationsAndlicenses.Employee = new Employee();

            return View(dto);
        }

        public JsonResult Save(CertificationsLicensces model)
        {
            var response = _context.Create(model);


            return Json(response);
        }

        // POST: CertificationsAndlicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateCertificationsAndlicenses")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCertificationsAndlicenses(CertificationsAndLisencesDto CertificationsAndlicensesDto)
        {
            if (CertificationsAndlicensesDto.CertificationsAndlicenses.Id == 0)
            {
                // Handle cases where EmployeeId is null
                // You can either leave it null or set a default EmployeeId if needed
                CertificationsAndlicensesDto.CertificationsAndlicenses.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == CertificationsAndlicensesDto.CertificationsAndlicenses.Id).FirstOrDefault();
            }


            var certificate = new CertificationsLicensces
            {
                Id = 0,
                PRCLicense = CertificationsAndlicensesDto.CertificationsAndlicenses.PRCLicense,
                StartDate = CertificationsAndlicensesDto.CertificationsAndlicenses.StartDate,
                OtherCertification = CertificationsAndlicensesDto.CertificationsAndlicenses.OtherCertification


            };

            // Save to the database
            _appdatacontext.CertificationsLicenses.Add(certificate);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            CertificationsAndlicensesDto.Employee = _appdatacontext.Employee.ToList();
            return View(CertificationsAndlicensesDto);

        }

        // GET: CertificationsAndlicenses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Fetch(id));
        }

        // POST: CertificationsAndlicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CertificationsLicensces model, int id)
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

        // GET: CertificationsAndlicenses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Fetch(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CertificationsLicensces collection)
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
