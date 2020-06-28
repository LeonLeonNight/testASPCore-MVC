using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testASPCore.Models.DAL;
using testASPCore.Models.DAL.Entity;

namespace testASPCore.Services
{
    public class PhoneService
    {
        DataBaseContext db = new DataBaseContext();
        
        public IEnumerable<Phone> GetAll()
        {
            var result = db.Phones.AsEnumerable();
            db.Dispose();
            return result;
        }

        public Phone GetById(int? phoneId)
        {
            var result = db.Phones.Find(phoneId);
            db.Dispose();
            return result;
        }

        public void Create(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            db.Dispose();
        }

        public void Delete(int phoneId)
        {
            var result = db.Phones.Find(phoneId);
            if (result != null)
            {
                db.Entry(result).State = EntityState.Deleted;
                db.Phones.Remove(result);
                db.SaveChanges();
                db.Dispose();
            }
        }

        public void Update(Phone phone)
        {
            db.Entry(phone).State = EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
        }
    }
}
