using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{
    public class DAL_QuoteFeedback
    {
        NadMedDataContext db = new NadMedDataContext();

        public bool Save(QuoteFeedback SaveFeedback)
        {
            if (SaveFeedback.QuoteFeedback_ID == 0)
            {
                string insName = db.Insurers.SingleOrDefault(p => p.Insurer_ID == (int)SaveFeedback.Insurer_ID).Insurer_Name;
                SaveFeedback.Insurer = insName;
                SaveFeedback.Quote_Processed_Datetime = DateTime.Now;
                SaveFeedback.Quote_Expiry_Datetime = DateTime.Now.AddDays(30);
                db.QuoteFeedbacks.InsertOnSubmit(SaveFeedback);
                db.SubmitChanges();
            }
            else
            {
                QuoteFeedback xmaster = (from cm in db.QuoteFeedbacks
                                         where cm.QuoteFeedback_ID == SaveFeedback.QuoteFeedback_ID
                                        select cm).FirstOrDefault();

                xmaster.Active_YN = SaveFeedback.Active_YN;
                xmaster.Comments = SaveFeedback.Comments;
                xmaster.Excess = SaveFeedback.Excess;
                xmaster.Excess_Type = SaveFeedback.Excess_Type;
                xmaster.Indemnity_limit = SaveFeedback.Indemnity_limit;
                xmaster.Insurer_ID = SaveFeedback.Insurer_ID;
                xmaster.Premium_Annual = SaveFeedback.Premium_Annual;
                xmaster.Quote_Expiry_Datetime = SaveFeedback.Quote_Expiry_Datetime;
                xmaster.Quote_Processed_Datetime = SaveFeedback.Quote_Processed_Datetime;
                xmaster.Wording = SaveFeedback.Wording;
                db.SubmitChanges();
            }
            return true;
        }


        public QuoteFeedback get(int QuoteID)
        {
            NadMedDataContext db = new NadMedDataContext();

            QuoteFeedback xfeedback = (from cm in db.QuoteFeedbacks
                                         where cm.QuoteFeedback_ID == QuoteID
                                        select cm).FirstOrDefault();
            return xfeedback;
        }

        public List<QuoteFeedback> getPerClient(int ClientQuoteID)
        {
            NadMedDataContext db = new NadMedDataContext();
            //var quotereq = db.QuoteRequests.SingleOrDefault(p => p.ClientMaster_ID == ClientID);

            var xfeedback = from cm in db.QuoteFeedbacks
                            where cm.QuoteRequest_ID == ClientQuoteID
                                       select cm;
            return xfeedback.ToList();
        }

        public List<QuoteFeedback> getPerClientQuote(int ClientQuoteID)
        {
            NadMedDataContext db = new NadMedDataContext();

            var xfeedback = from cm in db.QuoteFeedbacks
                            where cm.QuoteRequest_ID == ClientQuoteID
                            select cm;
            return xfeedback.ToList();
        }

        public List<QuoteFeedback> getPerClient(Guid ClientUniqueID)
        {
            NadMedDataContext db = new NadMedDataContext();

            var clm = db.ClientMasters.SingleOrDefault(p => p.UniqueID == ClientUniqueID);

            var quotereq = db.QuoteRequests.SingleOrDefault(p => p.ClientMaster_ID == clm.ClientMaster_ID);

            var xfeedback = from cm in db.QuoteFeedbacks
                            where cm.QuoteFeedback_ID == quotereq.QuoteRequest_ID
                            select cm;
            return xfeedback.ToList();
        }

        public List<getClientsAwaitingQuotesResult> getQuotesPerClient()
        {
            NadMedDataContext db = new NadMedDataContext();
            var qpc = db.getClientsAwaitingQuotes();
            return qpc.ToList();
        }
    }
}
