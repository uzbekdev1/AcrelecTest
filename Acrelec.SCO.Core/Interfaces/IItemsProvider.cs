using Acrelec.SCO.DataStructures;
using System.Collections.Generic;

namespace Acrelec.SCO.Core.Interfaces
{
    public interface IItemsProvider
    {

        /// <summary>
        /// list of all POS items
        /// </summary>
        List<POSItem> AllPOSItems { get; }

        /// <summary>
        /// list of all POS items that are available
        /// </summary>
        List<POSItem> AvailablePOSItems { get; }
         
    }
}
