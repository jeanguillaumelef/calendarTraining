namespace Domain.Interfaces
{
    internal interface IClientAdministration
    {
        public bool CreateClient(string clientName, string patientName, string animalType, out Client createdClient);
        //Task<bool> RegisterClient(string clientName, string patientName, string animalType);
    }
}