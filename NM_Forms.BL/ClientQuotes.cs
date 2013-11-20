using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.BL
{
    
    public class ClientQuotes
    {
        public int ClientMasterID { get; set; }
        public string ClientName { get; set; }
        public DateTime RequestDate { get; set; }
        public int NrQuotes { get; set; }

        public List<ClientQuotes> getQuotesPerClient(int ClientID)
        {
            List<ClientQuotes> QList = new List<ClientQuotes>();
            return QList;
        }
    }
}
