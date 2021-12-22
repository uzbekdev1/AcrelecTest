using Acrelec.SCO.DataStructures;

namespace Acrelec.SCO.Core.Helpers
{
    public static class POSItemExtensions
    {

        //todo - write an extension method which returns only the first 3 letters of the POSItem.Name
        public static string FormatName(this POSItem item) => item.Name.Length > 3 ? item.Name.Substring(0, 3) : item.Name;

    }
}
