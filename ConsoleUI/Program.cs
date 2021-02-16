using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarList();

            //Colorlist();
            BrandCRUDDeneme();
            //Brandlist();

            //CarDetailsList();

            //CarManager carManager = new CarManager(new EfCarDal());
            //UserAdd();

            //CustomerAdd();



            //  CRUDDeneme(carManager); //PRimarykey özelliğinden dolayı dikkat edilmedilidir
            // CarList();
            Console.ReadKey();
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            List<Customer> customers = new List<Customer>()
            {new Customer(){UserId=1,CompanyName="Kodlama.io"},
            new Customer(){UserId=2,CompanyName="Yazılım Bilimi"}
            };
            customerManager.Add(customers[0]);
            customerManager.Add(customers[1]);
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(new User() { Id = 1, FirstName = "Firat", LastName = "Dişli", Email = "sss_frt@hotmail.com", Password = "firat" });
            userManager.Add(new User() { Id = 2, FirstName = "Nedim", LastName = "Bilgin", Email = "ndmblgn@hotmail.com", Password = "nedim" });
        }

        private static void BrandCRUDDeneme()
        {
            Brandlist();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand() { BrandId = 10, BrandName = "Suziki" });
            brandManager.Update(new Brand() { BrandId = 10, BrandName = "Yu-Ma-Tu" });
            Brandlist();
            brandManager.Delete(new Brand() { BrandId = 10, BrandName = "Yu-Ma-Tu" });
            Brandlist();
        }

        private static void Brandlist()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} ", brand.BrandId, brand.BrandName);
            }
        }

        private static void CRUDDeneme(CarManager carManager)
        {
            carManager.Add(new Car() { Id = 21, BrandId = 3, CarName = "Mustang GTX", ColorId = 2, ModelYear = 2014, DailyPrice = 300, Description = "Ultra Lüx Araba" });

            Console.WriteLine(" eklendikten sonra");
            CarList();

            Console.WriteLine(" Updateden sonra sonra");
            carManager.Update(new Car() { Id = 21, BrandId = 3, CarName = "Mustang GTX", ColorId = 2, ModelYear = 2014, DailyPrice = 200, Description = "Orta Lüx Araba" });
            Console.WriteLine(" Silindikten Sonra");
            carManager.Delete(new Car() { Id = 21, BrandId = 3, CarName = "Mustang GTX", ColorId = 2, ModelYear = 2014, DailyPrice = 200, Description = "Orta Lüx Araba" });
        }

        private static void CarDetailsList()
        {
            CarManager carMamager = new CarManager(new EfCarDal());

            foreach (var car in carMamager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", car.CarId, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void Colorlist()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void CarList()
        {
            CarManager carMamager = new CarManager(new EfCarDal());

            foreach (var car in carMamager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }
        }
    }
}
