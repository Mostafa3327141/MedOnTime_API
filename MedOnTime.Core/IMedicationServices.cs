
using MedOnTime_WebApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core
{
    public interface IMedicationServices
    {
        List<Medication> GetMedications();
        Medication GetMedication(string id);

        Medication AddMedication(Medication medication);
        
    }
}
