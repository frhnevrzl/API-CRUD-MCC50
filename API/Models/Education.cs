using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Education")]
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        //[ForeignKey("University")]
        //FK tidak perlu di deklarasikan jika one to many
        //public int UniversityId { get; set; }
        //public Profiling profiling { get; set; }

        public ICollection<Profiling> profiling { get; set; }
        public virtual University university { get; set; }
    }
}
