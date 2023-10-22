using Domain.Interfaces;
using Domain.Object;

namespace Domain
{
    public class Client : IClient
    {
        public Guid Id { get; }
        public string Name { get; }
        public HashSet<Patient> Patients { get; }

        public Client(string clientName)
        {
            Patients = new HashSet<Patient>();
            Name = clientName;
            Id = Guid.NewGuid();
        }

        //for more detailled error handling, enumeration will be good
        public bool AddPatient(Patient patient)
        {
            if(patient == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(patient.Name) || string.IsNullOrEmpty(patient.AnimalType))
            {
                return false;
            }

            if (Patients.Contains(patient))
            {
                return false;
            }
            else
            {
                Patients.Add(patient);
                return true;
            }
        }
    }
}
