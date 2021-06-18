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

        [EnableCors("AllowOrigin")]
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
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetProfile")]
        //[EnableCors("AllowOrigin")]
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
        //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "Admin")]
        [HttpPost("Login")]
        //[Route("Login")]
        public ActionResult Login(LoginVM loginvm)
        {
            var login = repo.Login(loginvm);

            if (login == 404)
            {
                return BadRequest("Email Belum Terdaftar");
            }
            else if (login == 401)
            {
                return BadRequest("Password Salah");
            }
            else if (login == 1)
            {
                return Ok(new JWTokenVM
                {
                    Token = repo.GenerateToken(loginvm),
                    Message = "Login Sukses"
                });
            }
            else
                return BadRequest("Gagal Login");
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("DeleteProfile/{nik}")]
        public ActionResult DeleteProfile(int nik)
        {
            var del = repo.DeleteProfile(nik);
            if (del != 0)
            {
                return Ok("Delete Success");
            }
            else
                return NotFound("No Record");
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("UpdateProfile")]
        public ActionResult UpdateProfile(RegisterVM register)
        {
            var put = repo.UpdateProfile(register);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else
                return NotFound("Record Not Match");
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
