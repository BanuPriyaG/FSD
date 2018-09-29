using WebAPI.Controllers;
using System.Linq;
using WebAPI;
using NUnit.Framework;
using Moq;

namespace POPS.Test
{
    [TestFixture]
    public class Items
    {
        [Test]
        public void Test1()
        {
            var controller = new ITEMsController();
            var result = controller.GetITEMs();
            Assert.IsInstanceOf(typeof(IQueryable<ITEM>), result);
        }

        [Test]
        public void Test2()
        {            
            var item = new ITEM() { ITCODE = "3", ITDESC ="item3",  ITRATE=22 };
            
            var mockDB = new  Mock<IStoreAppContext>();
            mockDB.Setup(s => s.ITEMs).Returns(new TestDbSet<ITEM>());
            var controller = new ITEMsController(mockDB.Object);

            var result = controller.PostITEM(item);
            Assert.IsInstanceOf(typeof(System.Web.Http.Results.OkNegotiatedContentResult<int>), result);
        }
    }
}
