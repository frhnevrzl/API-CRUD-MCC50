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
                           BirthDate = p.BirthDate,
                           Phone = p.Phone,
                           Salary = p.Salary,
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
                           BirthDate = p.BirthDate,
                           Phone = p.Phone,
                           Salary = p.Salary,
                           Email = p.Email,
                           Password = a.Password,
                           UniversityId = u.UniversityId,
                           Degree = e.Degree,
                           GPA = e.GPA
                       }).ToList();
            return get.FirstOrDefault(p=> p.NIK == nik );
        }
        public int Login(LoginVM login)
        {
            var res = 0;
            //var search = conn.Persons.Where(p => p.Email == (register.Email) && p.account.Password == (register.Password));
            var check = conn.Persons.FirstOrDefault(p => p.Email == login.Email);
            //var search = conn.Accounts.FirstOrDefault(a => a.NIK == check.NIK);

            //if (search.ToList().Count > 0)
            if (check!=null && ValidatePassword(login.Password,check.account.Password))
            {
                res = 1;
            }
            else
                res = 0;
            return res;
        }

        public int DeleteProfile(int nik)
        {
            var del = conn.Persons.Find(nik);
            if (del != null)
            {
                conn.Remove(del);
                conn.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        //public int UpdateProfile(Person person)
        //{
        //    if (person != null)
        //    {
        //        conn.Entry(person).State = EntityState.Modified;
        //        var result = conn.SaveChanges();
        //        return result;
        //    }
        //    throw new ArgumentNullException("Entity");
        //}
        public int UpdateProfile(RegisterVM register)
        {
            Profiling profiling = conn.Profilings.Find(register.NIK);

            Account account = conn.Accounts.Find(register.NIK);
            account.NIK = register.NIK;
            account.Password = HashPassword(register.Password.ToString()).ToString();
            account.profiling = profiling;
            conn.Update(account);
            conn.SaveChanges();

            Education education = conn.Educations.Find(profiling.EducationId);
            education.UniversityId = register.UniversityId;
            education.Degree = register.Degree;
            education.GPA = register.GPA;
            conn.Update(education);
            conn.SaveChanges();

            Person person = conn.Persons.Find(register.NIK);
            person.NIK = register.NIK;
            person.FirstName = register.FirstName;
            person.LastName = register.LastName;
            person.Phone = register.Phone;
            person.BirthDate = register.BirthDate;
            person.Salary = register.Salary;
            person.Email = register.Email;
            person.account = account;
            conn.Update(person);
            return conn.SaveChanges();

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
        public string GenerateToken(LoginVM login)
        {
            var search = conn.Persons.SingleOrDefault(p => p.Email == login.Email);
            var searchRole = conn.AccountRoles.SingleOrDefault(p=> p.AccountNIK == search.NIK);


            var claims = new List<Claim>
            {
                new Claim("Email", search.Email),
                //new Claim(ClaimTypes.Role, searchRole.Roles.RoleName)
                new Claim("role", searchRole.Roles.RoleName)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],_configuration["Jwt:Audience"],claims, 
                signingCredentials:signin, expires: DateTime.UtcNow.AddDays(1));
            var tokenwrite = new JwtSecurityTokenHandler().WriteToken(token);
            claims.Add(new Claim("TokenSecurity", tokenwrite.ToString()));
            return tokenwrite;
        }
    }
}
//if (register.Password.ToString() != "")
//{
//    account.Password = HashPassword(register.Password.ToString()).ToString();
//}