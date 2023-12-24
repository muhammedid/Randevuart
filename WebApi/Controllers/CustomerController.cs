using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpGet("Add")]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok(customer);
        }
    }
}
