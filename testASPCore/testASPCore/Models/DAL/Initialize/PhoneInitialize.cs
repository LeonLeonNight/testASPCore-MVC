using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testASPCore.Models.DAL.Entity;

namespace testASPCore.Models.DAL.Initialize
{
    public static class PhoneInitialize
    {
        public static void Initialize(DataBaseContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
