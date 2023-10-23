using Domain.Interfaces;
using Domain.Object;

namespace Domain
{
    public class Client : IClient
    {
        public Guid Id { get; }
        public string Name { get; }
        //List directly accessible outside the class, the AddPatient function could be bypassed, alternative would be to do by copy
        public IList<Patient> Patients;
        public IList<Guid> BookingIds;


        public Client(string clientName)
        {
            Patients = new List<Patient>();
            BookingIds = new List<Guid>();
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
