using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.PrescriptionSpace
{
    public interface IPrescriptionServices
    {
        List<Prescription> GetPrescriptions();
        Prescription GetPrescription(string id);

        Prescription AddPrescription(Prescription prescription);

        void DeletePrescription(string id);

        Prescription UpdatePrescription(Prescription prescription);
    }
}
