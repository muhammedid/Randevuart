using Business.Abstract;
using Core.Utilities;
using Core.Utilities.ResultCore;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IBusinessDal _businessDal;

        public AuthManager(IBusinessDal businessDal)
        {
            _businessDal = businessDal;
        }

        public IDataResult<Entities.Concrete.Business> Login(LoginBussinesDto loginDto)
        {
            var bs = _businessDal.Get(v => v.Email == loginDto.Email && v.Password == loginDto.Password);

            if (bs.IsNull())
                return new ErrorDataResult<Entities.Concrete.Business>();
            else
                return new SuccessDataResult<Entities.Concrete.Business>(bs);
        }
    }
}