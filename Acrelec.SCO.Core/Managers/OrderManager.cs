using Acrelec.SCO.Core.Interfaces;
using System;
using System.Threading.Tasks;
using Acrelec.SCO.DataStructures;

namespace Acrelec.SCO.Core.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IItemsProvider _itemsProvider;

        /// <summary>
        /// constructor
        /// </summary>
        public OrderManager(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }

        //todo - implement interface knowing that it has to call the REST API described in readme.txt file 
        public Task<string> InjectOrderAsync(Order orderToInject)
        {
            foreach (var orderItem in orderToInject.OrderItems)
            {
                if (orderItem.Qty <= 0)
                {
                    throw new Exception("Order quality must be available");
                }

                if (string.IsNullOrWhiteSpace(orderItem.ItemCode))
                {
                    throw new Exception("Order item code is null");
                }

                if (!_itemsProvider.AvailablePOSItems.Exists(a => a.ItemCode == orderItem.ItemCode))
                {
                    throw new Exception("Order item code is no found");
                } 

                // TODO: late we need impl qty property
            }

            return Task.FromResult("10");
        }
    }
}
