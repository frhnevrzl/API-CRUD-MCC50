using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class where Repository : IRepository<Entity, Key>
    {
        Repository repo;
        public BaseController(Repository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            var post = repo.Insert(entity);
            if (post > 0)
            {
                return Ok("Data Inserted Successfully");
            }
            else
                return BadRequest("You Didn't Insert Anything");
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var get = repo.Get();
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }

        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            var get = repo.Get(key);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            var del = repo.Delete(key);
            if (del > 0)
            {
                return Ok("Data Deleted Successfully");
            }
            else
                return NotFound("Data Not Found");
        }

        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            var put = repo.Update(entity);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else
                return NotFound("Record Not Match");
        }
    }

}
