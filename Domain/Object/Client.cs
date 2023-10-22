using Domain.Interfaces;
using Domain.Object;

namespace Domain
{
    public class Client : IClient
    {
        private HashSet<Patient> patients;


        public Guid Id { get; }
        public string Name { get; }
        

        public Client(string clientName)
        {
            patients = new HashSet<Patient>();
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

            if (patients.Contains(patient))
            {
                return false;
            }
            else
            {
                patients.Add(patient);
                return true;
            }
        }

        //I don't like to pass a copy but i prefer that to the alternative of giving access to the property because AddPatient could be bypassed
        //the silver lining is that i don't expect this hashset to have more than 5 element

        /// <summary>
        /// Get a copy of the patients hashset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HashSet<Patient> GetPatientsCopy()
        {
            return new HashSet<Patient>(this.patients);
        }
    }
}
