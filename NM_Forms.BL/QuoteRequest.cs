using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class QuoteRequest
    {
        public int QuoteRequest_ID { get; set; } 
        public Guid UniqueID { get; set; }
        public int? QuoteType { get; set; }
        public int ClientMasterID { get; set; }
        public int? Businesstype_ID { get; set; }
        public string Business_Type { get; set; }
        public int? Business_Discipline_ID { get; set; }
        public string Business_Discipline { get; set; }
        public int? Limit_PerClaim_ID { get; set; }
        public string Limit_PerClaim { get; set; }
        public int? Limit_PerPeriod_ID { get; set; }
        public string Limit_PerPeriod { get; set; }
        public double? Stats_Private_Consultations { get; set; }
        public double? Stats_Private_Procedures { get; set; }
        public double? Stats_State_Consultations { get; set; }
        public double? Stats_State_Procedures { get; set; }
        public double? Stats_Private_Procedures_Income { get; set; }
        public double? Stats_State_Procedures_Income { get; set; }
        public double? Stats_State_Consultations_Income { get; set; }
        public double? Stats_Caesarians { get; set; }
        public double? Stats_NVD { get; set; }
        public double? Stats_Hysterectomies { get; set; }
        public string Cover_Current_Provider { get; set; }
        public int? Cover_Current_Years { get; set; }
        public string Stats_Surgery { get; set; }
        public string Claims_Enquiries { get; set; }
        public string Claims_Actual { get; set; }
        public string Claims_HPCSA { get; set; }
        public string Claims_Circumstances { get; set; }
        public string Material_Facts { get; set; }
        public bool? Declaration_Quote { get; set; }
        public DateTime? Acceptance_Quote { get; set; }
        public int? Premium_Period_Type_ID { get; set; }
        public int? Factility_Type_ID { get; set; }
        public string Factility_Type { get; set; }
        public int? Stats_Grid_ID { get; set; }
        public int? Stats_Number_Of_Nursing_Staff { get; set; }
        public int? Stats_Number_of_Births_Annual { get; set; }
        public int? Stats_Number_of_Deaths_Annual { get; set; }
        public bool? Authorize_Claims { get; set; }

        public bool save()
        {
            DAL.QuoteRequest NewQuoteRequest = new DAL.QuoteRequest
            {
                QuoteRequest_ID = this.QuoteRequest_ID,
                UniqueID = this.UniqueID,
                QuoteType = this.QuoteType,
                ClientMaster_ID = this.ClientMasterID,
                Businesstype_ID = this.Businesstype_ID,
                Business_Type = this.Business_Type,
                Business_Discipline_ID = (int)this.Business_Discipline_ID,
                Business_Discipline = this.Business_Discipline,
                Limit_PerClaim_ID = this.Limit_PerClaim_ID,
                Limit_PerClaim = this.Limit_PerClaim,
                Limit_PerPeriod_ID = this.Limit_PerPeriod_ID,
                Limit_PerPeriod = this.Limit_PerPeriod,
                Stats_Private_Consultations = this.Stats_Private_Consultations,
                Stats_Private_Procedures = this.Stats_Private_Procedures,
                Stats_State_Consultations = this.Stats_State_Consultations,
                Stats_State_Procedures = this.Stats_State_Procedures,
                Stats_Private_Procedures_Income = this.Stats_Private_Procedures_Income,
                Stats_State_Procedures_Income = this.Stats_State_Procedures_Income,
                Stats_State_Consultations_Income = this.Stats_State_Consultations_Income,
                Stats_Caesarians = this.Stats_Caesarians,
                Stats_NVD = this.Stats_NVD,
                Stats_Hysterectomies = this.Stats_Hysterectomies,
                Cover_Current_Provider = this.Cover_Current_Provider,
                Cover_Current_Years = this.Cover_Current_Years,
                Stats_Surgery = this.Stats_Surgery,
                Claims_Enquiries = this.Claims_Enquiries,
                Claims_Actual = this.Claims_Actual,
                Claims_HPCSA = this.Claims_HPCSA,
                Claims_Circumstances = this.Claims_Circumstances,
                Material_Facts = this.Material_Facts,
                Declaration_Quote = this.Declaration_Quote,
                Acceptance_Quote = this.Acceptance_Quote,
                Premium_Period_ID = this.Premium_Period_Type_ID,
                Factility_Type_ID = this.Factility_Type_ID,
                Factility_Type = this.Factility_Type,
                Stats_Grid_ID = this.Stats_Grid_ID,
                Stats_Number_Of_Nursing_Staff = this.Stats_Number_Of_Nursing_Staff,
                Stats_Number_of_Births_Annual = this.Stats_Number_of_Births_Annual,
                Stats_Number_of_Deaths_Annual = this.Stats_Number_of_Deaths_Annual,
                Authorize_Claims = this.Authorize_Claims
            };
            DAL_QuoteRequest xDAL = new DAL_QuoteRequest();
            xDAL.SaveRequest(NewQuoteRequest);
            return true;
        }

      

        public static QuoteRequest getByClient(int ClientID)
        {
            //ceck if one exists for client and send if yes else send new

            QuoteRequest NewQuoteRequest = new QuoteRequest();
            NewQuoteRequest.ClientMasterID = ClientID;
            return NewQuoteRequest;
        }

        public static QuoteRequest get(int QuoteReqID)
        {
            //ceck if one exists for client and send if yes else send new
            DAL_QuoteRequest Xrequest = new DAL_QuoteRequest();

            DAL.QuoteRequest getRequest = Xrequest.get(QuoteReqID);

            QuoteRequest NewQuoteRequest = new QuoteRequest
            {
                QuoteRequest_ID = getRequest.QuoteRequest_ID,
                UniqueID = getRequest.UniqueID,
                QuoteType = getRequest.QuoteType,
                ClientMasterID = getRequest.ClientMaster_ID,
                Businesstype_ID = getRequest.Businesstype_ID,
                Business_Type = getRequest.Business_Type,
                Business_Discipline_ID = getRequest.Business_Discipline_ID,
                Business_Discipline = getRequest.Business_Discipline,
                Limit_PerClaim_ID = getRequest.Limit_PerClaim_ID,
                Limit_PerClaim = getRequest.Limit_PerClaim,
                Limit_PerPeriod_ID = getRequest.Limit_PerPeriod_ID,
                Limit_PerPeriod = getRequest.Limit_PerPeriod,
                Stats_Private_Consultations = getRequest.Stats_Private_Consultations,
                Stats_Private_Procedures = getRequest.Stats_Private_Procedures,
                Stats_State_Consultations = getRequest.Stats_State_Consultations,
                Stats_State_Procedures = getRequest.Stats_State_Procedures,
                Stats_Private_Procedures_Income = getRequest.Stats_Private_Procedures_Income,
                Stats_State_Procedures_Income = getRequest.Stats_State_Procedures_Income,
                Stats_State_Consultations_Income = getRequest.Stats_State_Consultations_Income,
                Stats_Caesarians = getRequest.Stats_Caesarians,
                Stats_NVD = getRequest.Stats_NVD,
                Stats_Hysterectomies = getRequest.Stats_Hysterectomies,
                Cover_Current_Provider = getRequest.Cover_Current_Provider,
                Cover_Current_Years = getRequest.Cover_Current_Years,
                Stats_Surgery = getRequest.Stats_Surgery,
                Claims_Enquiries = getRequest.Claims_Enquiries,
                Claims_Actual = getRequest.Claims_Actual,
                Claims_HPCSA = getRequest.Claims_HPCSA,
                Claims_Circumstances = getRequest.Claims_Circumstances,
                Material_Facts = getRequest.Material_Facts,
                Declaration_Quote = getRequest.Declaration_Quote,
                Acceptance_Quote = getRequest.Acceptance_Quote,
                Premium_Period_Type_ID = getRequest.Premium_Period_ID,
                Factility_Type_ID = getRequest.Factility_Type_ID,
                Factility_Type = getRequest.Factility_Type,
                Stats_Grid_ID = getRequest.Stats_Grid_ID,
                Stats_Number_Of_Nursing_Staff = getRequest.Stats_Number_Of_Nursing_Staff,
                Stats_Number_of_Births_Annual = getRequest.Stats_Number_of_Births_Annual,
                Stats_Number_of_Deaths_Annual = getRequest.Stats_Number_of_Deaths_Annual,
                Authorize_Claims = getRequest.Authorize_Claims
            };
            return NewQuoteRequest;
        }

        public static QuoteRequest getByClient(Guid ClientUniqueID)
        {
            //ceck if one exists for client and send if yes else send new
            DAL_QuoteRequest Xrequest = new DAL_QuoteRequest();
            
            ClientMaster xMaster = ClientMaster.GetByUniqueID(ClientUniqueID);
            DAL.QuoteRequest getRequest = Xrequest.getbyUserID(xMaster.ClientMaster_ID);

            QuoteRequest NewQuoteRequest = new QuoteRequest
            {
                QuoteRequest_ID = getRequest.QuoteRequest_ID,
                UniqueID = getRequest.UniqueID,
                QuoteType = getRequest.QuoteType,
                ClientMasterID = getRequest.ClientMaster_ID,
                Businesstype_ID = getRequest.Businesstype_ID,
                Business_Type = getRequest.Business_Type,
                Business_Discipline_ID = getRequest.Business_Discipline_ID,
                Business_Discipline = getRequest.Business_Discipline,
                Limit_PerClaim_ID = getRequest.Limit_PerClaim_ID,
                Limit_PerClaim = getRequest.Limit_PerClaim,
                Limit_PerPeriod_ID = getRequest.Limit_PerPeriod_ID,
                Limit_PerPeriod = getRequest.Limit_PerPeriod,
                Stats_Private_Consultations = getRequest.Stats_Private_Consultations,
                Stats_Private_Procedures = getRequest.Stats_Private_Procedures,
                Stats_State_Consultations = getRequest.Stats_State_Consultations,
                Stats_State_Procedures = getRequest.Stats_State_Procedures,
                Stats_Private_Procedures_Income = getRequest.Stats_Private_Procedures_Income,
                Stats_State_Procedures_Income = getRequest.Stats_State_Procedures_Income,
                Stats_State_Consultations_Income = getRequest.Stats_State_Consultations_Income,
                Stats_Caesarians = getRequest.Stats_Caesarians,
                Stats_NVD = getRequest.Stats_NVD,
                Stats_Hysterectomies = getRequest.Stats_Hysterectomies,
                Cover_Current_Provider = getRequest.Cover_Current_Provider,
                Cover_Current_Years = getRequest.Cover_Current_Years,
                Stats_Surgery = getRequest.Stats_Surgery,
                Claims_Enquiries = getRequest.Claims_Enquiries,
                Claims_Actual = getRequest.Claims_Actual,
                Claims_HPCSA = getRequest.Claims_HPCSA,
                Claims_Circumstances = getRequest.Claims_Circumstances,
                Material_Facts = getRequest.Material_Facts,
                Declaration_Quote = getRequest.Declaration_Quote,
                Acceptance_Quote = getRequest.Acceptance_Quote,
                Premium_Period_Type_ID = getRequest.Premium_Period_ID,
                Factility_Type_ID = getRequest.Factility_Type_ID,
                Factility_Type = getRequest.Factility_Type,
                Stats_Grid_ID = getRequest.Stats_Grid_ID,
                Stats_Number_Of_Nursing_Staff = getRequest.Stats_Number_Of_Nursing_Staff,
                Stats_Number_of_Births_Annual = getRequest.Stats_Number_of_Births_Annual,
                Stats_Number_of_Deaths_Annual = getRequest.Stats_Number_of_Deaths_Annual,
                Authorize_Claims = getRequest.Authorize_Claims
            };
            NewQuoteRequest.ClientMasterID = xMaster.ClientMaster_ID;
            return NewQuoteRequest;
        }


    }
}
