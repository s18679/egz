using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egz.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public string Details { get; set; }
        public int Dose { get; set; }
    }
}
