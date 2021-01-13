using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DatabaseLayer;
using DatabaseLayer.Models;
using System.Linq;

namespace BulkOrderCS.Tests
{
    [TestClass]
    public class ClientsRepositoryTest
    {
        ClientsRepository cr = new ClientsRepository();
        Client c;

        [TestInitialize]
        public void Init()
        {
            c = new Client(0, "test", "test", "test", "test", "test", "test", "test", "test");
            cr.InsertClient(c);
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!cr.GetAllClients().Exists(x => x.Name == c.Name))
                Assert.Fail("Nije unet klijent!");
        }

        [TestMethod]
        public void TestDelete()
        {
            cr.DeleteClient(cr.GetAllClients().Where(x => (x.Name == c.Name)).ToList()[0].Id);
            if (!cr.GetAllClients().Exists(x => x.Name == c.Name))
                Assert.Fail("Nije obrisan klijent!");
        }

        [TestMethod]
        public void TestModify()
        {
            c.City = "test 2";
            cr.UpdateClient(c);
            if (cr.GetAllClients().Exists(x => (x.Name == c.Name) && (x.City == c.City)))
                Assert.Fail("Nije izmenjen klijent!");
        }

        [TestCleanup]
        public void Cleanup()
        {
            cr.DeleteClient(cr.GetAllClients().Where(x => (x.Name == c.Name)).ToList()[0].Id);
        }
    }
}
