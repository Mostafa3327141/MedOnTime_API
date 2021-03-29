using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.MedicationNameSpace
{
    public interface IMedicationServices
    {
        List<Medication> GetMedications();
        Medication GetMedication(string id);

        Medication AddMedication(Medication medication);

        void DeleteMedication(string id);

        Medication UpdateMedication(Medication medication);
        
    }
}
