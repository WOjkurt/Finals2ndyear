using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using static JwtAuthDemo.Models.Interfaces.CrudBase;

namespace JwtAuthDemo.Helpers
{
    public class EducationalBackgroundHelper : ICrudBaseClass<Educationalbackground>
    {
          
        private Appdatacontext _context;
        public EducationalBackgroundHelper(Appdatacontext context)
        {
            _context = context;
        }

        public string Create(Educationalbackground model)
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

            var educationalbackground = _context.Educationalbackground

                .Where(s => s.Id == id).FirstOrDefault();

            if (educationalbackground != null)
            {
                _context.Educationalbackground.Remove(educationalbackground);
                _context.SaveChanges(true);
            }

            return isDeleted;
        }


        public List<Educationalbackground> GetAll()
        {
            return _context.Educationalbackground.ToList();
        }

        public Educationalbackground Fetch(int id)
        {
            var educationalbackground = _context.Educationalbackground
                //.Include(a => a.CertificationsAndLicenses)
                //.Include(a => a.EducationalInformation)
                //.Include(a => a.GovernmentInformation)
                .FirstOrDefault(a => a.Id == id);
            return educationalbackground;
        }

        public Educationalbackground Update(Educationalbackground model, int id)
        {
            Educationalbackground result = new Educationalbackground();


            var educationalbackground = _context.Educationalbackground.Where(a => a.Id == id).FirstOrDefault();

            if (educationalbackground != null)
            {
                model.Id = educationalbackground.Id;

                _context.Educationalbackground.Remove(educationalbackground);
                _context.Educationalbackground.Add(model);
                _context.SaveChanges();



                result = model;
            }

            return result;

        }
    }
}
    

