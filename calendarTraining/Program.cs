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

var dateTimeToCancel = new DateTime(2083, 10, 12, 12, 00, 00).ToUniversalTime();

Booking booking = new Booking();
booking.BookHour(client, patient, new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime());
booking.BookHour(client, patient, dateTimeToCancel);

//cancel a booking

booking.CancelBooking(client.Id, dateTimeToCancel);

//modify booking time
//see available booking time


