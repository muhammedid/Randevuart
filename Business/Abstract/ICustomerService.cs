using Core.Utilities.ResultCore;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IDataResult<List<Customer>> GetAll();
        public IResult Add(Customer customer);
    }
}
