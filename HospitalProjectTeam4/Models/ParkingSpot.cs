using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProjectTeam4.Models
{
    public class ParkingSpot
    {
        [Key]
        public string ParkingSpotID { get; set; }

        public string StaffID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("StaffID")]
        public virtual HospitalStaff HospitalStaff { get; set; }
    }
}