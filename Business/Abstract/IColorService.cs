using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(int colorId);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);

    }
}
