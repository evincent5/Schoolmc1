using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schoolmc1.Models;
using Schoolmc1.Models.Repositories;

namespace SchoolUnitTestProject
{
    [TestClass]
    public class RequestRepositoryTest
    {
        [TestMethod]
        public void GetById_Request()
        {
            //arrange
            int id = 1;

            SchoolDataEntities1 context = new SchoolDataEntities1();
            RequestRepository requestRepo = new RequestRepository(context);

            //act
            Request request = requestRepo.GetById(id);

            //assert
            Assert.AreEqual(id, request.Id);
            Assert.IsInstanceOfType(request, typeof(Request));
        }
        [TestMethod]
        public void Update_Request()
        {


        }
    }
}
