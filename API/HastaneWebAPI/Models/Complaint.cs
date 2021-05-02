using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneWebAPI.Models
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public int ComplaintCode { get; set; }
        public string ComplaintName { get; set; }
    }
}
