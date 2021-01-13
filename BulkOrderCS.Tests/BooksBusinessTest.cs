using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DatabaseLayer;
using DatabaseLayer.Models;
using BusinessLogicLayer;
using System.Collections.Generic;
using System.Text;

namespace BulkOrderCS.Tests
{
    [TestClass]
    public class BooksBusinessTest
    {
        BooksBusiness br = new BooksBusiness();
        Book b;

        [TestInitialize]
        public void Init()
        {
            b = new Book(100, "test", "test", "test", 12.2, "test", "test", "test", 1);
            br.InsertBook(b);
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!br.GetAllBooks().Exists(x => x.Isbn == b.Isbn))
                Assert.Fail("Nije uneta knjiga!");
        }

        [TestMethod]
        public void TestDelete()
        {
            br.DeleteBook(b.Isbn);
            if (br.GetAllBooks().Exists(x => x.Isbn == b.Isbn))
                Assert.Fail("Nije obrisana knjiga!");
        }

        [TestMethod]
        public void TestModify()
        {
            b.Description = "test 2";
            br.UpdateBook(b);
            if (!br.GetAllBooks().Exists(x => (x.Isbn == b.Isbn) && (x.Description == b.Description)))
                Assert.Fail("Nije izmenjena knjiga!");
        }

        [TestCleanup]
        public void Cleanup()
        {
            br.DeleteBook(b.Isbn);
        }
    }
}
