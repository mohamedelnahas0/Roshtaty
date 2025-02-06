using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Entites
{
    public class Prescription : BaseEntity
    {
        public string Prescription_Name { get; set; }
        public string Dose { get; set; }
        public string Form { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string? Dispensedmedication{ get; set; }
         public int Active_IngredientId { get; set; } //Fk
        public Active_Ingredient Active_Ingredient { get; set; }
    }
}
