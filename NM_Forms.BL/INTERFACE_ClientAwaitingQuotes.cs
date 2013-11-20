using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.BL
{
    public class INTERFACE_ClientAwaitingQuotes
    {
            public int ClientMasterID { get; set; }
            public string ClientName { get; set; }
            public DateTime RequestDate { get; set; }
            public int QuoteRequestID { get; set; }
            public int NrQuotes { get; set; }
    }
}
