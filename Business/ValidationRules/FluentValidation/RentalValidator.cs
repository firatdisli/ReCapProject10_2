using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {




        public RentalValidator()
        {

            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.ReturnDate).Empty();
            RuleFor(r=>r.CarId).Must(RentCheck).WithMessage("Araç Başkasında");
          
        }

        private bool RentCheck(int arg)
        {
           RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var rental = rentalManager.GetAll().Data;
            foreach (var r in rental)
            {
                if (r.ReturnDate == null && r.CarId == arg)
                    return false;
            }
            return true;
        }
        
    }
}
