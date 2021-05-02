using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneWebAPI.Models
{
    public class Diagnoses
    {
        public int DiagnosisID { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisName { get; set; }
    }
}
