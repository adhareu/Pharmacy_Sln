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
   
    public class GenderController : ApiController
    {
        private readonly IGenderService _GenderService;
        public GenderController(IGenderService GenderService)
        {
            _GenderService = GenderService;
        }
        // GET: api/Gender
       
        [HttpGet]
        public List<Gender> GetAllGender()
        {
            return _GenderService.GetAll();
        }

        // GET: api/Gender/5
      
        [HttpGet]
        [ResponseType(typeof(Gender))]
        public Gender GetGender(int id)
        {
            Gender s_Gender = _GenderService.GetById(id);
            

            return s_Gender;
        }

        // PUT: api/Gender/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddGender( Gender s_Gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _GenderService.Add(s_Gender);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Gender
       
        [HttpPut]
        [ResponseType(typeof(Gender))]
        public IHttpActionResult UpdateGender(Gender s_Gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _GenderService.Update(s_Gender);

            return CreatedAtRoute("DefaultApi", new { id = s_Gender.GenderID }, s_Gender);
        }

        // DELETE: api/Gender/5
     
        [HttpDelete]
        [ResponseType(typeof(Gender))]
        public IHttpActionResult DeleteGender(int id)
        {
            Gender s_Gender = _GenderService.GetById(id);
            if (s_Gender == null)
            {
                return NotFound();
            }

            _GenderService.Delete(s_Gender);

            return Ok(s_Gender);
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
        public bool IsGenderExists(string Name)
        {
            return _GenderService.FindByName(Name).Count() > 0;
        }
        [HttpGet]
        public bool IsGenderExists(int id,string Name)
        {
            return _GenderService.FindByName(Name).Where(x=>x.GenderID!=id).Count() > 0;
        }
    }
}