using Domain.Object;

namespace Domain.Interfaces
{
    internal interface IClientManager
    {
        Client CreateClient(string patientName, string animalType);
    }
}