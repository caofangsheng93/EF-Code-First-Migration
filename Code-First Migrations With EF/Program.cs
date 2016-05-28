using EF.Core;
using EF.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Migrations_With_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你的名字：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入你的年龄：");
            int age = 0;
            bool isValid = int.TryParse(Console.ReadLine(),out age);
            Console.WriteLine("请输入你的Email：");
            string email=Console.ReadLine();

            using(EFDbContext db = new EFDbContext())
            {
                Student model = new Student() 
                {
                    StudentName=name,
                    Age=age,
                    Email=email
                };
                db.Entry(model).State = EntityState.Added;
                db.SaveChanges();
            }
            Console.WriteLine("恭喜你，执行成功了-----------------------");
            Console.ReadKey();
        }
    }
}
