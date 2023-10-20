using Domain;

namespace DomainTest
{
    [TestClass]
    public class ClientManagerTest
    {
        [TestMethod]
        public void ClientCreationTest_basicCreationSucceed()
        {
            string patientName = "roger";
            string patientAnimalType = "rabbit";
            ClientManager clientManager = new ClientManager();
            Client client = clientManager.CreateClient(patientName, patientAnimalType);

            Assert.AreEqual(client.Patient.Name, patientName);
            Assert.AreEqual(client.Patient.AnimalType, patientAnimalType);
            Assert.IsNotNull(client.Patient.Id);
            Assert.AreNotEqual(client.Patient.Id, Guid.Empty);
            Assert.IsNotNull(client.Id);
            Assert.AreNotEqual(client.Id, Guid.Empty);
        }
    }
}
