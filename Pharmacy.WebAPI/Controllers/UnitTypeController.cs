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
   
    public class UnitTypeController : ApiController
    {
        private readonly IUnitTypeService _UnitTypeService;
        public UnitTypeController(IUnitTypeService UnitTypeService)
        {
            _UnitTypeService = UnitTypeService;
        }
        // GET: api/UnitType
       
        [HttpGet]
        public List<UnitType> GetAllUnitType()
        {
            return _UnitTypeService.GetAll();
        }

        // GET: api/UnitType/5
      
        [HttpGet]
        [ResponseType(typeof(UnitType))]
        public UnitType GetUnitType(int id)
        {
            UnitType s_UnitType = _UnitTypeService.GetById(id);
           

            return s_UnitType;
        }

        // PUT: api/UnitType/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddUnitType( UnitType s_UnitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _UnitTypeService.Add(s_UnitType);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UnitType
       
        [HttpPut]
        [ResponseType(typeof(UnitType))]
        public IHttpActionResult UpdateUnitType(UnitType s_UnitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _UnitTypeService.Update(s_UnitType);

            return CreatedAtRoute("DefaultApi", new { id = s_UnitType.UnitTypeID }, s_UnitType);
        }

        // DELETE: api/UnitType/5
     
        [HttpDelete]
        [ResponseType(typeof(UnitType))]
        public IHttpActionResult DeleteUnitType(int id)
        {
            UnitType s_UnitType = _UnitTypeService.GetById(id);
            if (s_UnitType == null)
            {
                return NotFound();
            }

            _UnitTypeService.Delete(s_UnitType);

            return Ok(s_UnitType);
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
        public bool IsUnitTypeExists(string Name)
        {
            return _UnitTypeService.FindByName(Name).Count() > 0;
        }
        [HttpGet]
        public bool IsUnitTypeExistsWithID(int id,string Name)
        {
            return _UnitTypeService.FindByName(Name).Where(x=>x.UnitTypeID!=id).Count() > 0;
        }
    }
}