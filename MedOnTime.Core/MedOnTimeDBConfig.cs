
namespace MedOnTime.Core
{
    public class MedOnTimeDBConfig
    {
        public string Database_Name { get; set; }

        public string Connection_String { get; set; }

        public string Patient_Collection_Name { get; set; }
        public string Medication_Collection_Name { get; set; }
        public string Caretaker_Collection_Name { get; set; }
    }
}
