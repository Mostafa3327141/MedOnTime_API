using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.PatientSpace
{
    public interface IPatientServices
    {
        List<Patient> GetPatients(int careTakerID);
        List<Patient> GetPatients();
        Patient GetPatient(string id);

        Patient AddPatient(Patient patient);

        void DeletePatient(string id);

        Patient UpdatePatient(Patient patient);
    }
}
