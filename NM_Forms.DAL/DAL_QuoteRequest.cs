using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{
    public class DAL_QuoteRequest
    {
        NadMedDataContext db = new NadMedDataContext();

        public List<QuoteRequest> getAll()
        {
            var QRList = from qr in db.QuoteRequests
                         orderby qr.QuoteRequest_ID descending
                         select qr;
            return QRList.ToList();
        }


        public QuoteRequest get(int RequestID)
        {
            var QRList = (from cli in db.QuoteRequests
                          where cli.QuoteRequest_ID == RequestID
                          select cli).FirstOrDefault();
            return QRList;
        }

        public QuoteRequest getbyUserID(int IDref)
        {
            var QRList = (from cli in db.QuoteRequests
                          where cli.ClientMaster_ID == IDref
                          orderby cli.Authorize_Claims_Date descending
                          select cli).FirstOrDefault();
            if (QRList != null)
            {
                return QRList;
            }
            else
            {
                return new QuoteRequest();
            }
        }

        public bool SaveRequest(QuoteRequest cRequest)
        {
            if (cRequest.QuoteRequest_ID == 0)
            {
                db.QuoteRequests.InsertOnSubmit(cRequest);
                db.SubmitChanges();
                return true;
            }
            else
            {
                var qrequest = db.QuoteRequests.SingleOrDefault(p => p.QuoteRequest_ID == cRequest.QuoteRequest_ID);
                qrequest.Businesstype_ID = cRequest.Businesstype_ID;
                qrequest.Business_Type = cRequest.Business_Type;
                qrequest.Business_Discipline_ID = cRequest.Business_Discipline_ID;
                qrequest.Business_Discipline = cRequest.Business_Discipline;
                qrequest.Limit_PerClaim_ID = cRequest.Limit_PerClaim_ID;
                qrequest.Limit_PerClaim = cRequest.Limit_PerClaim;
                qrequest.Limit_PerPeriod_ID = cRequest.Limit_PerPeriod_ID;
                qrequest.Limit_PerPeriod = cRequest.Limit_PerPeriod;
                qrequest.Stats_Private_Consultations = cRequest.Stats_Private_Consultations;
                qrequest.Stats_Private_Procedures = cRequest.Stats_Private_Procedures;
                qrequest.Stats_State_Consultations = cRequest.Stats_State_Consultations;
                qrequest.Stats_State_Procedures = cRequest.Stats_State_Procedures;
                qrequest.Stats_Private_Procedures_Income = cRequest.Stats_Private_Procedures_Income;
                qrequest.Stats_State_Procedures_Income = cRequest.Stats_State_Procedures_Income;
                qrequest.Stats_State_Consultations_Income = cRequest.Stats_State_Consultations_Income;
                qrequest.Stats_Caesarians = cRequest.Stats_Caesarians;
                qrequest.Stats_NVD = cRequest.Stats_NVD;
                qrequest.Stats_Hysterectomies = cRequest.Stats_Hysterectomies;
                qrequest.Cover_Current_Provider = cRequest.Cover_Current_Provider;
                qrequest.Cover_Current_Years = cRequest.Cover_Current_Years;
                qrequest.Stats_Surgery = cRequest.Stats_Surgery;
                qrequest.Claims_Enquiries = cRequest.Claims_Enquiries;
                qrequest.Claims_Actual = cRequest.Claims_Actual;
                qrequest.Claims_HPCSA = cRequest.Claims_HPCSA;
                qrequest.Claims_Circumstances = cRequest.Claims_Circumstances;
                qrequest.Material_Facts = cRequest.Material_Facts;
                qrequest.Declaration_Quote = cRequest.Declaration_Quote;
                qrequest.Acceptance_Quote = cRequest.Acceptance_Quote;
                qrequest.Premium_Period_ID = cRequest.Premium_Period_ID;
                qrequest.Factility_Type_ID = cRequest.Factility_Type_ID;
                qrequest.Factility_Type = cRequest.Factility_Type;
                qrequest.Stats_Grid_ID = cRequest.Stats_Grid_ID;
                qrequest.Stats_Number_Of_Nursing_Staff = cRequest.Stats_Number_Of_Nursing_Staff;
                qrequest.Stats_Number_of_Births_Annual = cRequest.Stats_Number_of_Births_Annual;
                qrequest.Stats_Number_of_Deaths_Annual = cRequest.Stats_Number_of_Deaths_Annual;
                qrequest.Authorize_Claims = cRequest.Authorize_Claims;
                db.SubmitChanges();
                return true;
            }
        }
    }
}
