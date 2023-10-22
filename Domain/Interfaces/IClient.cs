using Domain.Object;

namespace Domain.Interfaces
{
    public interface IClient
    {
        public bool AddPatient(Patient patient);
    }
}