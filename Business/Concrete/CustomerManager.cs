using Business.Abstract;
using Core.Utilities.ResultCore;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customer;
        public CustomerManager(ICustomerDal customer)
        {
                _customer = customer;
        }
        public IDataResult<List<Customer>> GetAll()
        {
            var lst =  _customer.GetAll();
            return new SuccessDataResult<List<Customer>>(lst);
        }
        public IResult Add(Customer customer)
        {
            _customer.Add(customer);
            return new SuccessResult();
        }

    }
}
