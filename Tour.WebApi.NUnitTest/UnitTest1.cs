using NUnit.Framework;

namespace Tour.WebApi.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Create Tour
        //Request With Postman
        //URL :http://localhost:57712/api/v1.0/tour
        //Body: {"Name": "Üsküdar'a gider iken", "FromWhere": "Büyükçekmece", "ToWhere":"Üsküdar","StartDate":"2020-11-14", "ArrivalDate":"2020-11-14", "Description": "Deneme 1-2", "Notes":"Deneme 2-3", "NumberOfSeats":5, "Status": "Çýkýþ saati Bekleniyor", "IsActive": true}



        //Create Reservation
        //Request With Postman
        //URL:http://localhost:57712/api/v1.0/Reservation
        //Body: {"TourId": 1, "CustomerFullName": "Yasin Yenil", "CustomerPhone":"01234567891","NumberOfPerson":4, "IsActive": true}



        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}