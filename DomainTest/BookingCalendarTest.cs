//using Domain;
//using Domain.Object;

//namespace DomainTest
//{
//    [TestClass]
//    public class BookingCalendarTest
//    {
//        [TestMethod]
//        public void BookingCalendar_BookUnoccupiedSlot_Succeed()
//        {
//            ClientAdministration clientAdministration = new ClientAdministration();
//            bool success = clientAdministration.CreateClient("Paul","roger", "rabbit", out Client client);            
//            DateTime bookingDateAndTime = new DateTime(2080, 12, 01, 9, 0, 0).ToUniversalTime();
//            Booking booking = new Booking(client, bookingDateAndTime);
            
//        }

//        public void BookingCalendar_BookUnoccupiedSlotInPast_Fail()
//        {
//            //ClientManager clientManager = new ClientManager();
//            //Client client = clientManager.CreateClient("Paul", "roger", "rabbit");
//            //Booking bookingSystem = new Booking();
//            //DateTime bookingDateAndTime = new DateTime(2080,12,01,9,0,0).ToUniversalTime();
//            //BookingSlot bookingSlot = new BookingSlot(client, bookingDateAndTime);
//            //bookingSystem.BookSlot();
//            Assert.Fail();
//        }

//        [TestMethod]
//        public void BookingCalendar_BookOccupiedSlot_Fail()
//        {
//            Assert.Fail();
//        }
//    }
//}
