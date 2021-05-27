using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext Conn; //= new MyContext();
        public PersonRepository(MyContext conn)
        {
            Conn = conn;
        }

        public int Delete(int nik)
        {
            Person person = null;
            person = Conn.Persons.Find(nik);
            if (person != null)
            {
                Conn.Remove(person);
                Conn.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        public IEnumerable<Person> Get()
        {
            return Conn.Persons.ToList();
        }

        public Person Get(int nik)
        {
            return Conn.Persons.Find(nik);
            //return Conn.Persons.Where(p => p.NIK == nik).FirstOrDefault();
        }

        public int Insert(Person person)
        {
            Conn.Persons.Add(person);
            var result = Conn.SaveChanges();
            return result;
        }

        public int Update(Person person)
        {
            int isUpdated = 0;
            if (person != null)
            {
                Conn.Entry(person).State = EntityState.Modified;
                Conn.SaveChanges();
                isUpdated = 1;
            }
            else
                isUpdated = 0;

            return isUpdated;

        }
    }
}
