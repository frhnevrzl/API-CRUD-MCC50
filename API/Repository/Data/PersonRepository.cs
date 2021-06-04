using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Moq;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Extensions.Configuration;


namespace API.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, int>
    {
        MyContext conn;
        private readonly DbSet<RegisterVM> registers;
        public IConfiguration _configuration;
        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        private static bool ValidatePassword(string password, string correcthash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correcthash);
        }
        public PersonRepository(MyContext myContext, IConfiguration _configuration) : base(myContext)
        {
            this.conn = myContext;
            registers = conn.Set<RegisterVM>();
            this._configuration = _configuration;
        }
        public int Register(RegisterVM register)
        {
            var result = 0;
            var cek = conn.Persons.FirstOrDefault(p => p.Email == register.Email);
            if (cek == null)
            {
                Person person = new Person
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Phone = register.Phone,
                    BirthDate = register.BirthDate,
                    Salary = register.Salary,
                    Email = register.Email
                };
                conn.Add(person);
                result = conn.SaveChanges();
                Account account = new Account
                {
                    NIK = person.NIK,
                    Password = HashPassword(register.Password)
                };
                conn.Add(account);
                result = conn.SaveChanges();
                Education edu = new Education
                {
                    Degree = register.Degree,
                    GPA = register.GPA,
                    UniversityId = register.UniversityId
                };
                conn.Add(edu);
                result = conn.SaveChanges();
                Profiling profiling = new Profiling
                {
                    NIK = person.NIK,
                    EducationId = edu.EducationId
                };
                conn.Add(profiling);
                result = conn.SaveChanges();
                AccountRole accountRole = new AccountRole
                {
                    AccountNIK = account.NIK,
                    RoleId = 2,
                };
                conn.Add(accountRole);
                result = conn.SaveChanges();
                return result;
            }
            else
                return result;
        }
        public IEnumerable<RegisterVM> GetProfile()
        {
            var get = (from p in conn.Persons
                       join a in conn.Accounts
                       on p.NIK equals a.NIK
                       join pr in conn.Profilings 
                       on a.NIK equals pr.NIK
                       join e in conn.Educations
                       on pr.EducationId equals e.EducationId
                       join u in conn.Universities
                       on e.UniversityId equals u.UniversityId
                       join ar in conn.AccountRoles
                       on a.NIK equals ar.AccountNIK
                       select new RegisterVM
                       {
                           NIK = p.NIK,
                           FirstName = p.FirstName,
                           LastName = p.LastName,
                           Phone = p.Phone,
                           Email = p.Email,
                           UniversityId = u.UniversityId,
                           Degree = e.Degree,
                           GPA = e.GPA,
                           RoleId =ar.RoleId
                       }).ToList();
            return get;
        }
        public RegisterVM GetProfileById(int nik)
        {
            var get = (from p in conn.Persons
                       join a in conn.Accounts
                       on p.NIK equals a.NIK
                       join pr in conn.Profilings
                       on a.NIK equals pr.NIK
                       join e in conn.Educations
                       on pr.EducationId equals e.EducationId
                       join u in conn.Universities
                       on e.UniversityId equals u.UniversityId
                       select new RegisterVM
                       {
                           NIK = p.NIK,
                           FirstName = p.FirstName,
                           LastName = p.LastName,
                           Phone = p.Phone,
                           Email = p.Email,
                           UniversityId = u.UniversityId,
                           Degree = e.Degree,
                           GPA = e.GPA
                       }).ToList();
            return get.FirstOrDefault(p=> p.NIK == nik );
        }
        public int Login(RegisterVM register)
        {
            var res = 0;
            //var search = conn.Persons.Where(p => p.Email == (register.Email) && p.account.Password == (register.Password));
            var check = conn.Persons.Single(p => p.Email == register.Email);
            //var search = conn.Accounts.FirstOrDefault(a => a.NIK == check.NIK);

            //if (search.ToList().Count > 0)
            if (check!=null && ValidatePassword(register.Password,check.account.Password))
            {
                res = 1;
            }
            else
                res = 0;
            return res;
        }
        public int ChangePassword(ChangePassVM change)
        {
            Account account = new Account();
            int isupdated = 0;
            var check = conn.Persons.FirstOrDefault(p => p.Email == change.Email);
            var checkpassword = conn.Accounts.FirstOrDefault(a => a.NIK == check.NIK);
            if (check != null && checkpassword != null)
            {
                account.Password = change.NewPassword;
                conn.Entry(account).State = EntityState.Modified;
                conn.SaveChanges();
                return isupdated = 1;
            }
            else
                return isupdated;
        }
        public string GenerateToken(RegisterVM register)
        {
            var search = conn.Persons.SingleOrDefault(p => p.Email == register.Email);
            var searchRole = conn.AccountRoles.SingleOrDefault(p=> p.AccountNIK == search.NIK);


            var claims = new List<Claim>
            {
                new Claim("Email", search.Email),
                //new Claim(ClaimTypes.Role, searchRole.Roles.RoleName)
                new Claim("role", searchRole.Roles.RoleName)

            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],_configuration["Jwt:Audience"],claims, 
                signingCredentials:signin, expires: DateTime.UtcNow.AddDays(1));
            var tokenwrite = new JwtSecurityTokenHandler().WriteToken(token);
            claims.Add(new Claim("TokenSecurity", tokenwrite.ToString()));
            return tokenwrite;
        }
    }
}
