using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<Person, PersonRepository, int>
    {
        //private readonly MyContext myContext;
        //private readonly PersonRepository repo = new PersonRepository(myContext);
        PersonRepository repo;
        public PersonController(PersonRepository person) : base(person) {
            this.repo = person;
        }

        [HttpPost("{Register}")]
        public ActionResult Register(RegisterVM register)
        {
            var reg = repo.Register(register);
            if (reg > 0)
            {
                return Ok("Data Inserted");
            }
            else
                return BadRequest("Email Duplicate, Try New Email");
        }

        //[Route("GetProfile")]
        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin")]
        [HttpGet("GetProfile")]
        [EnableCors("AllowOrigin")]
        public ActionResult Profile()
        {
            var get = repo.GetProfile();
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetProfileById/{nik}")]
        public ActionResult GetProfileById(int nik)
        {
            var get = repo.GetProfileById(nik);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }

        [HttpPost("Login")]
        //[Route("Login")]
        public ActionResult Login(RegisterVM register)
        {
            var post = repo.Login(register);
           
            if (post > 0)
            {
                string token = repo.GenerateToken(register);
                return Ok($"Berhasil Login \n Token : {token}");
                //repo.ValidateCurrentToken(token);
            }
            else
                return BadRequest("Email atau Password Tidak Sesuai");

        }
        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(ChangePassVM changePass)
        {
            var put = repo.ChangePassword(changePass);
            if (put > 0)
            {
                return Ok("Data Berhasil Diubah");
            }
            else
                return BadRequest("Password Tidak Berhasil Diubah");
        }
    
    }
}
