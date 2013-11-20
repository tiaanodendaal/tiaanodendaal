using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class QuoteFeedback
    {
        public int QuoteFeedback_ID { get; set; } 
        public int QuoteRequest_ID { get; set; } 
        public int Insurer_ID { get; set; } 
        public string Insurer { get; set; } 
        public double Indemnity_limit { get; set; }
        public double Premium_Annual { get; set; }
        public double Excess { get; set; }
        public string Excess_Type { get; set; }
        public string Comments { get; set; }
        public string Wording { get; set; } 
        public DateTime Quote_Processed_Datetime { get; set; }
        public DateTime Quote_Expiry_Datetime { get; set; }
        public bool Active_YN { get; set; }

        public bool save()
        {
            DAL.QuoteFeedback newFeedback = new DAL.QuoteFeedback
            {
                QuoteFeedback_ID = this.QuoteFeedback_ID,
                QuoteRequest_ID = this.QuoteRequest_ID,
                Insurer_ID = this.Insurer_ID,
                Insurer = this.Insurer,
                Indemnity_limit = this.Indemnity_limit,
                Premium_Annual = this.Premium_Annual,
                Excess = this.Excess,
                Excess_Type = this.Excess_Type,
                Comments = this.Comments,
                Wording = this.Wording,
                Quote_Processed_Datetime = DateTime.Now,
                Quote_Expiry_Datetime = this.Quote_Expiry_Datetime,
                Active_YN = this.Active_YN,
            };
            DAL_QuoteFeedback xDal = new DAL_QuoteFeedback();
            xDal.Save(newFeedback);
            return true;
        }

        public static QuoteFeedback get(int FeedbackID)
        {
            DAL_QuoteFeedback xDAL = new DAL_QuoteFeedback();
            DAL.QuoteFeedback xFeedback = xDAL.get(FeedbackID);
            QuoteFeedback newFeedback = new QuoteFeedback
            {
                QuoteFeedback_ID = xFeedback.QuoteFeedback_ID,
                QuoteRequest_ID = xFeedback.QuoteRequest_ID,
                Insurer_ID = xFeedback.Insurer_ID,
                Insurer = xFeedback.Insurer,
                Indemnity_limit = xFeedback.Indemnity_limit,
                Premium_Annual = xFeedback.Premium_Annual,
                Excess = xFeedback.Excess,
                Excess_Type = xFeedback.Excess_Type,
                Comments = xFeedback.Comments,
                Wording = xFeedback.Wording,
                Quote_Processed_Datetime = xFeedback.Quote_Processed_Datetime,
                Quote_Expiry_Datetime = xFeedback.Quote_Expiry_Datetime,
                Active_YN = xFeedback.Active_YN,
            };
            return newFeedback;
        }

        public static List<QuoteFeedback> getPerClientQuote(int ClientQuoteID)
        {
            List<QuoteFeedback> xFeedback = new List<QuoteFeedback>();
            DAL_QuoteFeedback xDAL = new DAL_QuoteFeedback();
            List<DAL.QuoteFeedback> cList = xDAL.getPerClient(ClientQuoteID);
            foreach (var itm in cList)
            {
                xFeedback.Add(new QuoteFeedback
                {
                    QuoteFeedback_ID = itm.QuoteFeedback_ID,
                    QuoteRequest_ID = itm.QuoteRequest_ID,
                    Insurer_ID = itm.Insurer_ID,
                    Insurer = itm.Insurer,
                    Indemnity_limit = itm.Indemnity_limit,
                    Premium_Annual = itm.Premium_Annual,
                    Excess = itm.Excess,
                    Excess_Type = itm.Excess_Type,
                    Comments = itm.Comments,
                    Wording = itm.Wording,
                    Quote_Processed_Datetime = itm.Quote_Processed_Datetime,
                    Quote_Expiry_Datetime = itm.Quote_Expiry_Datetime,
                    Active_YN = itm.Active_YN,
                    }
                );
            }
            return xFeedback;
        }

        public static List<INTERFACE_ClientAwaitingQuotes> getClientsAwaitingQuotes()
        {
            DAL_QuoteFeedback xDal = new DAL_QuoteFeedback();
            List<INTERFACE_ClientAwaitingQuotes> QuoteList = new List<INTERFACE_ClientAwaitingQuotes>();
            List<getClientsAwaitingQuotesResult> QList = xDal.getQuotesPerClient();
            foreach (var itm in QList)
            {
                QuoteList.Add(new INTERFACE_ClientAwaitingQuotes
                {
                    ClientMasterID = itm.ClientMaster_ID,
                    ClientName = itm.Name_Title + " " + itm.Name_First + " " + itm.Name_Last,
                    NrQuotes = (int)itm.QuoteCount,
                    QuoteRequestID = itm.QuoteRequest_ID,
                    RequestDate = (DateTime)itm.Acceptance_Quote
                });
            };
            return QuoteList;
        }
    }
}
