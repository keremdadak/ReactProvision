using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneWebAPI.Models
{
    public class Provision
    {
        
        public int ProvisionID { get; set; }
        [Required]
        [StringLength(11)]

        public string TCKN { get; set; }
        public DateTime ProvisionDate { get; set; }
        public string Expertise { get; set; }
        public string Diagnosis { get; set; }
        public string Complaint { get; set; }
        public string Operation { get; set; }
        public int ProvisionNumber { get; set; }

    }
}
