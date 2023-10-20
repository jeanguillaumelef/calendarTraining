using Domain.Object;

namespace Domain
{ 
    public class Client
    {
        public Guid Id { get; }
        public Patient Patient { get; }

        public Client(Patient patient) 
        {
            this.Patient = patient;
            Id = Guid.NewGuid();
        }
    }
}
