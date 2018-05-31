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
   
    public class MedicineInformationController : ApiController
    {
        private readonly IMedicineInformationService _MedicineInformationService;
        public MedicineInformationController(IMedicineInformationService MedicineInformationService)
        {
            _MedicineInformationService = MedicineInformationService;
        }
        // GET: api/MedicineInformation
       
        [HttpGet]
        public List<MedicineInformationView> GetAllMedicineInformation()
        {
            return _MedicineInformationService.GetAll();
        }

        // GET: api/MedicineInformation/5
      
        [HttpGet]
        [ResponseType(typeof(MedicineInformation))]
        public MedicineInformation GetMedicineInformation(int id)
        {
            MedicineInformation s_MedicineInformation = _MedicineInformationService.GetById(id);
            

            return s_MedicineInformation;
        }

        // PUT: api/MedicineInformation/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddMedicineInformation( MedicineInformation s_MedicineInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _MedicineInformationService.Add(s_MedicineInformation);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MedicineInformation
       
        [HttpPut]
        [ResponseType(typeof(MedicineInformation))]
        public IHttpActionResult UpdateMedicineInformation(MedicineInformation s_MedicineInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _MedicineInformationService.Update(s_MedicineInformation);

            return CreatedAtRoute("DefaultApi", new { id = s_MedicineInformation.MedicineID }, s_MedicineInformation);
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
        public bool IsMedicineInformationExists(string Name)
        {
            return _MedicineInformationService.FindByName(Name).Count() > 0;
        }
        [HttpGet]
        public bool IsMedicineInformationExistsWithID(int id,string Name)
        {
            return _MedicineInformationService.FindByName(Name).Where(x=>x.MedicineID!=id).Count() > 0;
        }
    }
}