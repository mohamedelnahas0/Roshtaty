using Roshtaty.Core.Entites;

namespace Roshtaty.DTOS
{
    public class PrescriptionToReturnDTO
    {
        public int Id { get; set; }
        public string Prescription_Name { get; set; }
        public string ActiveIngridient_Name { get; set; }
        public string Dose { get; set; }
        public string Form { get; set; }
        public decimal Strength { get; set; }
        public string StrengthUnit { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public string PrescriptionDate => PrescriptionDateRaw.ToString("dd/MM/yyyy HH:mm:ss");
        public DateTime PrescriptionDateRaw { get; set; } // For internal usage
        public string? Dispensedmedication { get; set; }


    }

}
