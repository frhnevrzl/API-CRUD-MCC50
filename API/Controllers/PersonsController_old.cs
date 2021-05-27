using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController_old : ControllerBase
    {
        PersonRepository repo;

        public PersonsController_old(PersonRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public ActionResult Post(Person Persons)
        {
            var post = repo.Insert(Persons);
            if (post > 0)
            {
                return Ok("Data Inserted Successfully");
            }
            else
                return BadRequest("You Didn't Insert Anything");

        }
        [HttpGet]
        public ActionResult Get()
        {
            var get = repo.Get();
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("You Don't Have a Record in The Table Yet");

        }

        [HttpGet("{nik}")]
        public ActionResult Get(int nik)
        {
            var get = repo.Get(nik);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("There is No Matching Record");

        }

        [HttpDelete("{nik}")]
        public ActionResult Delete(int nik)
        {
            var del = repo.Delete(nik);
            if (del > 0)
            {
                return Ok($"Record Deleted SuccessFully");
            }
            else
                return NotFound("Data Not Found");
        }

        [HttpPut]
        public ActionResult Put(Person Persons)
        {
            var put = repo.Update(Persons);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else
                return NotFound("Record Not Match");
        }
    }
}
