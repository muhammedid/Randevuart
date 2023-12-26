using Core.Utilities.ResultCore;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Entities.Concrete.Business> Login(LoginBussinesDto loginDto);
    }
}
