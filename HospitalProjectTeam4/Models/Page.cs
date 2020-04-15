using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProjectTeam4.Models
{
    public class Page
    {
        [Key]
        public string PageID { get; set; }

        [Required]
        public string DoctorID { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string PageBody { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsPublished { get; set; }

        [Required]
        public string PageStyle { get; set; }

        [ForeignKey("DoctorID")]
        public virtual Doctor Doctor { get; set; }

        public string GetPageBodyWithStyle()
        {
            return this.PageStyle + "\n" + this.PageBody;
        }
    }
}