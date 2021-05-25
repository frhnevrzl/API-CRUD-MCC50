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
    public class PersonsController : ControllerBase
    {
        PersonRepository repo;

        public PersonsController(PersonRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public ActionResult Post(Person Persons)
        {
            var post = repo.Insert(Persons);
            if (post > 0)
            {
                return Ok();
            }
            else
                return BadRequest("You Didn't Insert Anything");

        }
        [HttpGet]
        public ActionResult Get()
        {
            var get = repo.Get();
            return Ok(get);
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
                return Ok(del);
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
                return Ok(put);
            }
            else
                return BadRequest("Record Not Match");
        }
    }
}
