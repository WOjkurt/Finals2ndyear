using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using static JwtAuthDemo.Models.Interfaces.CrudBase;

namespace JwtAuthDemo.Helpers
{
    public class PersonalInformationHelper
    {
        public class PersonalInformationsHelper : ICrudBaseClass<PersonalInformation>
        {
            private Appdatacontext _context;
            public PersonalInformationsHelper(Appdatacontext context)
            {
                _context = context;
            }



            public string Create(PersonalInformation model)
            {
                string message = "";

                try
                {
                    _context.Add(model);

                    _context.SaveChanges();

                    message = "Successfully Saved!";
                }

                catch (Exception ex)
                {
                    message = ex.Message;
                }


                return message;
            }

            public bool Delete(int id)
            {
                bool isDeleted = false;

                var personalinfomation = _context.PersonalInformation

                    .Where(s => s.Id == id).FirstOrDefault();

                if (personalinfomation != null)
                {
                    _context.PersonalInformation.Remove(personalinfomation);
                    _context.SaveChanges(true);
                }

                return isDeleted;
            }


            public List<PersonalInformation> GetAll()
            {
                return _context.PersonalInformation.ToList();
            }

            public PersonalInformation Fetch(int id)
            {
                var personalInfomation = _context.PersonalInformation
                    //.Include(a => a.CertificationsAndLicenses)
                    //.Include(a => a.EducationalInformation)
                    //.Include(a => a.GovernmentInformation)
                    .FirstOrDefault(a => a.Id == id);
                return personalInfomation;
            }

            public PersonalInformation Update(PersonalInformation model, int id)
            {
                PersonalInformation result = new PersonalInformation();


                var personalinfo = _context.PersonalInformation.Where(a => a.Id == id).FirstOrDefault();

                if (personalinfo != null)
                {
                    model.Id = personalinfo.Id;

                    _context.PersonalInformation.Remove(personalinfo);
                    _context.PersonalInformation.Add(model);
                    _context.SaveChanges();

                    result = model;
                }

                return result;

            }
        }
    }
}
