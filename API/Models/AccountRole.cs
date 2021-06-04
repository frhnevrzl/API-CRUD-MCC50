using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_N_AccountRole")]
    public class AccountRole
    {
        //[Key]
        //public int Id { get; set; }
        public int AccountNIK { get; set; }
        public int RoleId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Role Roles { get; set; }

        //public virtual ICollection<Role> Role { get; set; }

    }
}
