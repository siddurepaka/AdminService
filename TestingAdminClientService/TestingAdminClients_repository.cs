using AdminClientServices.Entities;
using AdminClientServices.Manager;
using AdminClientServices.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAdminClientService
{
    [TestFixture]
    class TestingAdminClients_repository
    {
        AdminClientRepositorycs _repo;
        public void setup()
        {
            _repo = new AdminClientRepositorycs(new EmartDBContext());

        }
        [TearDown]
        public void Teardown()
        {
            _repo = null;
        }

        [Test]
        [Description("Get All Sellers")]
        public void testGetAllSellers()
        {
            try
            {
                var result = _repo.getAllSellers();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


    }
}
