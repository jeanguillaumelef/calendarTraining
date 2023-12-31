using Domain;
using Domain.Object;

namespace DomainTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ClientTest_AddPatient_Success()
        {
            int expectedNumberOfPatient = 1;
            string patientName = "roger";
            string patientAnimalType = "rabbit";
            Patient patient = new Patient(patientName, patientAnimalType);

            Client client = new Client("Paul");

            bool success = client.AddPatient(patient);            

            Assert.IsTrue(success);
            Assert.AreEqual(expectedNumberOfPatient, client.Patients.Count);
            Assert.IsTrue(client.Patients.Contains(patient));
        }

        [TestMethod]
        public void ClientTest_AddPatientTwice_failsecondtime()
        {
            int expectedNumberOfPatient = 1;
            string patientName = "roger";
            string patientAnimalType = "rabbit";
            Patient patient = new Patient(patientName, patientAnimalType);

            Client client = new Client("Paul");

            bool success = client.AddPatient(patient);
            bool success2 = client.AddPatient(patient);

            Assert.IsTrue(success);
            Assert.IsFalse(success2);
            Assert.AreEqual(expectedNumberOfPatient, client.Patients.Count);
            Assert.IsTrue(client.Patients.Contains(patient));
        }

        [TestMethod]
        public void ClientTest_AddNullPatient_fails()
        {
            int expectedNumberOfPatient = 0;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Patient patient = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Client client = new Client("Paul");

#pragma warning disable CS8604 // Possible null reference argument.
            bool success = client.AddPatient(patient);
#pragma warning restore CS8604 // Possible null reference argument.

            Assert.IsFalse(success);
            Assert.AreEqual(expectedNumberOfPatient, client.Patients.Count);
            Assert.IsFalse(client.Patients.Contains(patient));
        }

        [TestMethod]
        public void ClientTest_AddEmptyPatientName_fails()
        {
            int expectedNumberOfPatient = 0;
            string patientName = "";
            string patientAnimalType = "rabbit";
            Patient patient = new Patient(patientName, patientAnimalType);

            Client client = new Client("Paul");

            bool success = client.AddPatient(patient);

            Assert.IsFalse(success);
            Assert.AreEqual(expectedNumberOfPatient, client.Patients.Count);
            Assert.IsFalse(client.Patients.Contains(patient));
        }

        [TestMethod]
        public void ClientTest_AddEmptyAnimalType_fails()
        {
            int expectedNumberOfPatient = 0;
            string patientName = "1";
            string patientAnimalType = "";
            Patient patient = new Patient(patientName, patientAnimalType);

            Client client = new Client("Paul");

            bool success = client.AddPatient(patient);

            Assert.IsFalse(success);
            Assert.AreEqual(expectedNumberOfPatient, client.Patients.Count);
            Assert.IsFalse(client.Patients.Contains(patient));
        }
    }
}