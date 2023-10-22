// See https://aka.ms/new-console-template for more information
using Domain;
using Domain.Object;

Console.WriteLine("Hello, World!");

//create client
Client client = new Client("Paul");

//create patient (animal)
Patient patient = new Patient("roger", "rabbit");

bool success = client.AddPatient(patient);

if (success)
{
    Console.WriteLine("patient associated to client");
}
else
{
    Console.WriteLine("patient association to client failed");
}


//book a timeslot (booking)
//cancel a booking
//modify booking time
//see available booking time


