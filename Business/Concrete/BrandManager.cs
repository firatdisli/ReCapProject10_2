using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _branddal;

        public BrandManager(IBrandDal branddal)
        {
            _branddal = branddal;
        }

        public IResult Add(Brand brand)
        {
            _branddal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _branddal.Delete(brand);
            return new SuccessResult(Messages.BranDeleted);
        }

        public IDataResult<Brand> Get(int brandId)
        {
            return new SuccessDataResult<Brand>(_branddal.Get(b => b.BrandId == brandId));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_branddal.GetAll());
        }

        public IResult Update(Brand brand)
        {
            _branddal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
