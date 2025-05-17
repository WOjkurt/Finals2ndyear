using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using static JwtAuthDemo.Models.Interfaces.CrudBase;

namespace JwtAuthDemo.Helpers
{
    public class CertificationsandLicencesHelper : ICrudBaseClass<CertificationsLicensces>
    {
        private Appdatacontext _context;

        public CertificationsandLicencesHelper(Appdatacontext context)
        {
            _context = context;
        }
        public string Create(CertificationsLicensces model)
        {
            string message = "";

            try
            {
                _context.Add(model);
                _context.SaveChanges();
                message = "Successfully Saved";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return message;
        }
        public bool Delete(int id)
        {
            bool isDeleted  = false;
            var certificate = _context.CertificationsLicenses
                .Where(s => s.Id == id).FirstOrDefault();

            if (certificate != null)
            {
                _context.CertificationsLicenses.Remove(certificate);
                _context.SaveChanges(true);

            }
            return isDeleted;
        
        }
        public List<CertificationsLicensces> GetAll()
        {
            return _context.CertificationsLicenses.ToList();
        }
        public CertificationsLicensces Fetch(int id)
        {
            var certificate = _context.CertificationsLicenses
                .Include(a => a.Employee)
                .FirstOrDefault(a => a.Id == id);
            return certificate;
        }
        public CertificationsLicensces Update(CertificationsLicensces model, int id)
        {
            CertificationsLicensces result = new CertificationsLicensces();
            var certificate = _context.CertificationsLicenses.Where(a => a.Id == id).FirstOrDefault();

            if (certificate != null)
            {
                model.Id = certificate.Id;

                _context.CertificationsLicenses.Remove(certificate);
                _context.CertificationsLicenses.Add(model);
                _context.SaveChanges();

                result = model;
            }
            return result;
        }

    }
}
