using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_2_a
{
    class MyContextInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext db)
        {
            db.SaveChanges();

            Phone p1 = new Phone { Name = "Samsung Galaxy S5" };
            Phone p2 = new Phone { Name = "Samsung Galaxy S4" };
            Phone p3 = new Phone { Name = "iPhone5" };
            Phone p4 = new Phone { Name = "iPhone 4S" };
            
            db.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4 });
            db.SaveChanges();

            Company c1 = new Company { Name = "Samsung" };
            Company c2 = new Company { Name = "Apple" };
            c1.Phones.Add(p1);
            c1.Phones.Add(p2);
            c2.Phones.Add(p3);
            c2.Phones.Add(p4);
            db.Companies.AddRange(new List<Company>() { c1, c2 });
            db.SaveChanges();
        }
    }
}
