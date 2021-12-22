using Acrelec.SCO.Core.Interfaces;
using Acrelec.SCO.DataStructures;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Acrelec.SCO.Core.Providers
{
    /// <summary>
    /// class providing the list of items as retrieved from POS system
    /// </summary>
    public class ItemsProvider : IItemsProvider
    {
        private List<POSItem> _posItems;

        /// <summary>
        /// constructor
        /// </summary>
        public ItemsProvider()
        {
            _posItems = new List<POSItem>();

            LoadItemsFromPOS();
        }

        /// <summary>
        /// retrieving items from POS is a simple parse of a json
        /// </summary>
        private void LoadItemsFromPOS()
        {
            //todo - implement the code to load items from Data\ContentItems.json file
            var dataPath = Path.Combine("Data", "ContentItems.json");
            var jsonData = File.ReadAllText(dataPath);

            _posItems = JsonSerializer.Deserialize<List<POSItem>>(jsonData);
        }

        //todo - implement missing methods of interface
        public List<POSItem> AllPOSItems => _posItems;

        public List<POSItem> AvailablePOSItems => _posItems.FindAll(a => a.IsAvailable);

    }
}
