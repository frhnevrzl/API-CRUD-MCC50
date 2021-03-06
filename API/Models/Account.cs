using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key]
        //[ForeignKey("Person")]
        public int NIK { get; set; }
        public string Password { get; set; }
        public virtual Profiling profiling { get; set; }
        //public virtual Role role { get; set; }
        //public int RoleId { get; set; }

        //public virtual AccountRole AccountRoles { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

        [JsonIgnore]
        public virtual Person person { get; set; }
        
    }
}
