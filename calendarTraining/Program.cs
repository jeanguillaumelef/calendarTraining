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

Booking booking = new Booking();
booking.BookHour(client, patient, new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime());

//cancel a booking
//modify booking time
//see available booking time


