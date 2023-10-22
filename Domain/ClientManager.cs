//using Domain.Interfaces;
//using Domain.Object;

//namespace Domain
//{
//    public class ClientAdministration : IClientAdministration
//    {

//        public ClientAdministration() 
//        { 
            
//        }

//        //this function might grow with too much parameter
//        //error handling can be done with enum of error
//        public bool CreateClient(string clientName, string patientName, string animalType, out Client createdClient)
//        {
//            Patient patient = new Patient(patientName, animalType);
//            createdClient = new Client(clientName, patient);

//            return true;
//        }

//        public Task<bool> RegisterClient(string clientName, string patientName, string animalType)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
