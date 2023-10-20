using Domain.Interfaces;
using Domain.Object;

namespace Domain
{
    public class ClientManager : IClientManager
    {
        public ClientManager() { }

        //too many parameter, refactor
        public Client CreateClient(string patientName, string animalType)
        {
            Patient patient = new Patient(Guid.NewGuid(), patientName, animalType);
            Client client = new Client(patient);

            return client;
        }
    }
}
