using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        
        public IResult Add(Rental rental)
        {

            //Araç kiraya verilip geri getirilmemişse kiraya verme

            var carRentallist = _rentalDal.GetAll(r => r.CarId == rental.CarId );
            foreach (var carRental in carRentallist)
            {
                if(carRental.ReturnDate==null)
                return new ErrorResult(Messages.FailedRentalAddOrUpdate);
            }
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int rentalId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        public IResult CompleteRentalByCarId(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id);
            var updatedRental = result.SingleOrDefault();

            //To prevent to complete rental that is already completed.
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalAlreadyCompleted);
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalCompleted);
        }

    }
}
