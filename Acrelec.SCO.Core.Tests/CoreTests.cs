using System.Linq;
using Acrelec.SCO.Core.Interfaces;
using Acrelec.SCO.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acrelec.SCO.Core.Tests
{
    [TestClass]
    public class CoreTests
    {

        [TestMethod]
        public void ItemsProviderTest()
        {
            IItemsProvider itemsProvider = new ItemsProvider();
            Assert.AreEqual(4, itemsProvider.AllPOSItems.Count, "Different number of items are expected");

            //todo - write an assert to check only for items that are available (IsAvailable=True)
            Assert.AreEqual(3, itemsProvider.AvailablePOSItems.Count, "Different number of items are expected");
        }

        [TestMethod]
        public void OrderedItemsByCodeTest()
        {
            IItemsProvider itemsProvider = new ItemsProvider();
            string[] expectedCodesOrder = new[] { "200", "100", "101", "50" };

            //todo - write the code to order the items ascendent by UnitPrice
            string[] orderedCodes = itemsProvider.AllPOSItems.OrderBy(a => a.UnitPrice).Select(a => a.ItemCode).ToArray();

            //compare the ordered itemCodes to see it matches the expected order
            CollectionAssert.AreEqual(expectedCodesOrder, orderedCodes);
        }

    }
}
