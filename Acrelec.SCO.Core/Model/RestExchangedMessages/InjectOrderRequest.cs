using Acrelec.SCO.DataStructures;
using System.ComponentModel.DataAnnotations;

namespace Acrelec.SCO.Core.Model.RestExchangedMessages
{
    public class InjectOrderRequest
    {

        [Required]
        public Order Order { get; set; }

        [Required]
        public Customer Customer { get; set; }

    }
}
