using NUnit.Framework;

namespace Tour.WebApi.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //First You should Authorize after that you should add token inside of your request Header with Authorization attribute

        //Authorization
        //Request With Postman
        //URL:http://localhost:57712/api/v1.0/account/authenticate
        //Body :{"Email" : "superadmin@gmail.com","Password": "123Pa$$word!"}

        //Example Result 

        //        {
        //    "succeeded": true,
        //    "message": "Authenticated superadmin",
        //    "errors": null,
        //    "data": {
        //        "id": "955e0811-5af1-453a-ac1e-614b735f85db",
        //        "userName": "superadmin",
        //        "email": "superadmin@gmail.com",
        //        "roles": [
        //            "Admin",
        //            "Moderator",
        //            "Basic",
        //            "SuperAdmin"
        //        ],
        //"isVerified":         true,"jwToken":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzdXBlcmFkbWluIiwianRpIjoiMDgyYzU3YzUtMjdkMy00OTkwLWFiYTYtYWFhOTA3ZDVkYjk3IiwiZW1haWwiOiJzdXBlcmFkbWluQGdtYWlsLmNv   bSIs       InVpZCI6Ijk1NWUwODExLTVhZjEtNDUzYS1hYzFlLTYxNGI3MzVmODVkYiIsImlwIjoiMTkyLjE2OC4xLjE0OCIsInJvbGVzIjpbIkFkbWluIiwiTW9kZXJhdG9yIiwiQmFzaWMiLCJTdXBlckFkbWluIl0sImV4cCI6MTYwNTM5NzczN   Swia  XNzIjoiQ29yZUlkZW50aXR5IiwiYXVkIjoiQ29yZUlkZW50aXR5VXNlciJ9.imA_IzJGnCFMFKuAZuJaiKHI_vgVCVMXzgf2ARJ-z-Y"
        //    }
        //}


        //Create Tour
        //Request With Postman
        //URL :http://localhost:57712/api/v1.0/tour
        //Body: {"Name": "Üsküdar'a gider iken", "FromWhere": "Büyükçekmece", "ToWhere":"Üsküdar","StartDate":"2020-11-14", "ArrivalDate":"2020-11-14", "Description": "Deneme 1-2", "Notes":"Deneme 2-3", "NumberOfSeats":5, "Status": "Çýkýþ saati Bekleniyor", "IsActive": true}

        //For Header
        //Authorization bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzdXBlcmFkbWluIiwianRpIjoiMDgyYzU3YzUtMjdkMy00OTkwLWFiYTYtYWFhOTA3ZDVkYjk3IiwiZW1haWwiOiJzdXBlcmFkbWluQGdtYWlsLmNv   bSIs       InVpZCI6Ijk1NWUwODExLTVhZjEtNDUzYS1hYzFlLTYxNGI3MzVmODVkYiIsImlwIjoiMTkyLjE2OC4xLjE0OCIsInJvbGVzIjpbIkFkbWluIiwiTW9kZXJhdG9yIiwiQmFzaWMiLCJTdXBlckFkbWluIl0sImV4cCI6MTYwNTM5NzczN   Swia  XNzIjoiQ29yZUlkZW50aXR5IiwiYXVkIjoiQ29yZUlkZW50aXR5VXNlciJ9.imA_IzJGnCFMFKuAZuJaiKHI_vgVCVMXzgf2ARJ-z-Y



        //Create Reservation
        //Request With Postman
        //URL:http://localhost:57712/api/v1.0/Reservation
        //Body: {"TourId": 1, "CustomerFullName": "Yasin Yenil", "CustomerPhone":"01234567891","NumberOfPerson":4, "IsActive": true}

        //For Header
        //Authorization bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzdXBlcmFkbWluIiwianRpIjoiMDgyYzU3YzUtMjdkMy00OTkwLWFiYTYtYWFhOTA3ZDVkYjk3IiwiZW1haWwiOiJzdXBlcmFkbWluQGdtYWlsLmNv   bSIs       InVpZCI6Ijk1NWUwODExLTVhZjEtNDUzYS1hYzFlLTYxNGI3MzVmODVkYiIsImlwIjoiMTkyLjE2OC4xLjE0OCIsInJvbGVzIjpbIkFkbWluIiwiTW9kZXJhdG9yIiwiQmFzaWMiLCJTdXBlckFkbWluIl0sImV4cCI6MTYwNTM5NzczN   Swia  XNzIjoiQ29yZUlkZW50aXR5IiwiYXVkIjoiQ29yZUlkZW50aXR5VXNlciJ9.imA_IzJGnCFMFKuAZuJaiKHI_vgVCVMXzgf2ARJ-z-Y



        //Search Tours With FromWhere To Where 
        //Request With Postman
        //GET
        //URL:http://localhost:57712/api/v1.0/tour/get-criteria?FromWhere=Büyükçekmece&ToWhere=Üsküdar
        

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
