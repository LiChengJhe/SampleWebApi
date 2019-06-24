using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SampleWebApi.Models;

namespace SampleWebApi.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : Controller
    {

        private static List<Customer> _Customers = new List<Customer> {
                     new Customer{ Id="A54A",Name="Broadcom",Location="usa" },
                     new Customer{ Id="A73A",Name="Murata",Location="jp" }
                };


        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return Ok(_Customers);
        }

        [Route("{id}"), HttpGet]
        public ActionResult<Customer> GetCustomer(string  id )
        {
            try
            {
                return Ok(_Customers.Find(o => o.Id == id));
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,new{ detail= ex.Message});
            }
        }


        [HttpPost]
        public ActionResult AddCustomer([FromBody]Customer customer)
        {
            _Customers.Add(customer);
            return Ok(new { Response= "added successfully ", Customer=customer});
        }

        [Route("{id}"), HttpPut]
        public ActionResult ReplaceCustomer(string id, [FromBody]Customer customer)
        {
            Customer temp = _Customers.Find(o => o.Id == id);
            temp.Name = customer.Name;
            temp.Location = customer.Location;
            return Ok(new { Response = "replace successfully ", Customer = customer });
        }


        [Route("{id}"), HttpPatch]
        public ActionResult UpdateCustomerName(string id, [FromBody]Customer customer)
        {
            Customer temp = _Customers.Find(o => o.Id == id);
            if(!string.IsNullOrEmpty( customer.Name)) temp.Name = customer.Name;
            if (!string.IsNullOrEmpty(customer.Location)) temp.Location = customer.Location;
            return Ok(new { Response = "updated successfully ", Customer = customer });
        }

        [Route("{id}"), HttpDelete]
        public ActionResult DelCustomer(string id)
        {
           _Customers.Remove(_Customers.Find(o => o.Id == id));
            return Ok(new { Response = "deleted successfully ", Customer = id });
        }
    }


}