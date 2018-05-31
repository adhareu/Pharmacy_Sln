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
   
    public class SalesInformationController : ApiController
    {
        private readonly ISalesInformationService _SalesInformationService;
        public SalesInformationController(ISalesInformationService SalesInformationService)
        {
            _SalesInformationService = SalesInformationService;
        }
        // GET: api/SalesInformation
       
        [HttpGet]
        public List<SalesInformationView> GetAllSalesInformation()
        {
            return _SalesInformationService.GetAll();
        }
        [HttpGet]
        public SalesInformation GetSalesInformationLastData()
        {
            return _SalesInformationService.GetLastData();
        }
        // GET: api/SalesInformation/5

        [HttpGet]
        [ResponseType(typeof(SalesInformation))]
        public IHttpActionResult GetSalesInformation(int id)
        {
            SalesInformation s_SalesInformation = _SalesInformationService.GetById(id);
            if (s_SalesInformation == null)
            {
                return NotFound();
            }

            return Ok(s_SalesInformation);
        }

        // PUT: api/SalesInformation/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddSalesInformation( SalesInformation s_SalesInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _SalesInformationService.Add(s_SalesInformation);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SalesInformation
       
        [HttpPut]
        [ResponseType(typeof(SalesInformation))]
        public IHttpActionResult UpdateSalesInformation(SalesInformation s_SalesInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _SalesInformationService.Update(s_SalesInformation);

            return CreatedAtRoute("DefaultApi", new { id = s_SalesInformation.SalesID }, s_SalesInformation);
        }

        // DELETE: api/SalesInformation/5
     
        [HttpDelete]
        [ResponseType(typeof(SalesInformation))]
        public IHttpActionResult DeleteSalesInformation(int id)
        {
            SalesInformation s_SalesInformation = _SalesInformationService.GetById(id);
            if (s_SalesInformation == null)
            {
                return NotFound();
            }

            _SalesInformationService.Delete(s_SalesInformation);

            return Ok(s_SalesInformation);
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
        public bool IsSalesInformationExists(string Name)
        {
            return _SalesInformationService.FindByName(Name).Count() > 0;
        }
        [HttpGet]
        public bool IsSalesInformationExists(int id,string Name)
        {
            return _SalesInformationService.FindByName(Name).Where(x=>x.SalesID!=id).Count() > 0;
        }
    }
}