// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("Hello, World!");

//create client
//create patient (animal) => assumption of client can not exist without a patient
ClientManager clientManager = new ClientManager();
Client myFirstClient = clientManager.CreateClient("roger", "rabbit");





//book a timeslot (booking)
//cancel a booking
//modify booking time
//see available booking time


