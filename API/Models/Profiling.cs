using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_Profiling")]
    public class Profiling
    {
        [Key]
        public int NIK { get; set; }
        //FK tidak perlu di deklarasikan jika one to many
        //[ForeignKey("Education")]
        public virtual Account account { get; set; }
        [JsonIgnore]
        public virtual Education education { get; set; }
        public int EducationId { get; set; }
    }
}
