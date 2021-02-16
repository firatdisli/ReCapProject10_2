using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Business.Concrete;

using DataAccess.Concrete.EntityFramework;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarList();

            // Colorlist();
          //  BrandCRUDDeneme();
            // Brandlist();

           //
            CarDetailsList();

            //CarManager carManager = new CarManager(new EfCarDal());


            //  CRUDDeneme(carManager); //PRimarykey özelliğinden dolayı dikkat edilmedilidir
            // CarList();
            Console.ReadKey();
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
