using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Pharmacy.Model;

using Pharmacy.Service;
using System.Web.Http.Cors;

namespace Pharmacy.WebAPI.Controllers
{
   
    public class CustomerInformationController : ApiController
    {
        private readonly ICustomerInformationService _CustomerInformationService;
        public CustomerInformationController(ICustomerInformationService CustomerInformationService)
        {
            _CustomerInformationService = CustomerInformationService;
        }
        // GET: api/CustomerInformation
       
        [HttpGet]
        public List<CustomerInformationView> GetAllCustomerInformation()
        {
            return _CustomerInformationService.GetAll();
        }

        // GET: api/CustomerInformation/5
      
        [HttpGet]
        [ResponseType(typeof(CustomerInformation))]
        public CustomerInformation GetCustomerInformation(int id)
        {
            CustomerInformation s_CustomerInformation = _CustomerInformationService.GetById(id);
           
            return s_CustomerInformation;
        }

        // PUT: api/CustomerInformation/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddCustomerInformation( CustomerInformation s_CustomerInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _CustomerInformationService.Add(s_CustomerInformation);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerInformation
       
        [HttpPut]
        [ResponseType(typeof(CustomerInformation))]
        public IHttpActionResult UpdateCustomerInformation(CustomerInformation s_CustomerInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _CustomerInformationService.Update(s_CustomerInformation);

            return CreatedAtRoute("DefaultApi", new { id = s_CustomerInformation.CustomerID }, s_CustomerInformation);
        }

        // DELETE: api/CustomerInformation/5
     
        [HttpDelete]
        [ResponseType(typeof(CustomerInformation))]
        public IHttpActionResult DeleteCustomerInformation(int id)
        {
            CustomerInformation s_CustomerInformation = _CustomerInformationService.GetById(id);
            if (s_CustomerInformation == null)
            {
                return NotFound();
            }

            _CustomerInformationService.Delete(s_CustomerInformation);

            return Ok(s_CustomerInformation);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
       
        [HttpGet]
        public bool IsCustomerInformationExists(string Name)
        {
            return _CustomerInformationService.FindByName(Name).Count() > 0;
        }
        [HttpGet]
        public bool IsCustomerInformationExistsWithID(int id,string Name)
        {
            return _CustomerInformationService.FindByName(Name).Where(x=>x.CustomerID!=id).Count() > 0;
        }
    }
}