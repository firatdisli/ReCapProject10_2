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

            CarManager carMamager = new CarManager(new EfCarDal());

            foreach(var car in carMamager.GetAll())
            {
                Console.WriteLine(car.Id+" "+car.ModelYear+" "+car.DailyPrice+" "+car.Description);
            }


            Car car1 = new Car() {Id=10,CarName="F", BrandId=3,ColorId=2,DailyPrice=10,ModelYear=2012,Description="Eklenemeyen"};
            Car car2 = new Car() { Id = 11, CarName = "Ford Fiesta", BrandId = 3, ColorId = 2, DailyPrice = 0, ModelYear = 2012, Description = "Eklenemeyen" };
            Car car3 = new Car() { Id = 12, CarName = "Ford Fiesta", BrandId = 3, ColorId = 2, DailyPrice = 100, ModelYear = 2012, Description = "Aile Arabası" };

            //Bir Önceki çalıştırmada eklenen değerler primarykey özelliğinden dolayı, comment yapılmalı
           // carMamager.Delete(car3);
            carMamager.Add(car1);
            carMamager.Add(car2);
           // carMamager.Add(car3);
            //Delete metodu car nennesi istediğinden şimdilik tüm özelliklerini göndermek gerekli
            //carMamager.Add(new Car() {Id=3,BrandId=2,ColorId=3,ModelYear=2017,DailyPrice=250,Description="Lüx Araba",CarName="Ford Mondeo" });
            carMamager.Update(new Car() { Id = 4, BrandId = 3, ColorId = 2, ModelYear = 2014, DailyPrice = 250, Description = "Lüx Araba", CarName = "Ford Mondeo" });

            Console.WriteLine("---------ekleme güncelleme ve silmeden sonra arabalar------");
            foreach (var car in carMamager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }
            Console.ReadKey();
        }
    }
}
