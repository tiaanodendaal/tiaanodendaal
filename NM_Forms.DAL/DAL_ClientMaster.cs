using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NM_Forms.DAL
{
    public class DAL_ClientMaster
    {
        NadMedDataContext db = new NadMedDataContext();
        
        public List<ClientMaster> getAll()
        {
            List<ClientMaster> CL_List = new List<ClientMaster>();
            var CLList = from cli in db.ClientMasters
                         orderby cli.Name_Last, cli.Name_First
                         select cli;
            return CLList.ToList();
        }


        public ClientMaster get(int ClientMasterID)
        {
            List<ClientMaster> CL_List = new List<ClientMaster>();
            var CLList = (from cli in db.ClientMasters
                          where cli.ClientMaster_ID == ClientMasterID
                          orderby cli.Name_Last, cli.Name_First
                          select cli).FirstOrDefault();
            return CLList;
        }

        public ClientMaster getbyID(string IDref)
        {
            List<ClientMaster> CL_List = new List<ClientMaster>();
            var CLList = (from cli in db.ClientMasters
                          where cli.REF_Identity == IDref
                          orderby cli.Name_Last, cli.Name_First
                          select cli).FirstOrDefault();
            return CLList;
        }

        public ClientMaster getbyID(Guid IDref)
        {
            List<ClientMaster> CL_List = new List<ClientMaster>();
            var CLList = (from cli in db.ClientMasters
                          where cli.UniqueID == IDref
                          orderby cli.Name_Last, cli.Name_First
                          select cli).FirstOrDefault();
            return CLList;
        }



        public bool Save(ClientMaster SaveMaster)
        {
            if(SaveMaster.ClientMaster_ID==0)
            {
                db.ClientMasters.InsertOnSubmit(SaveMaster);
                db.SubmitChanges();
            }
            else
            {
                ClientMaster xmaster = (from cm in db.ClientMasters
                                        where cm.ClientMaster_ID == SaveMaster.ClientMaster_ID
                                        select cm).FirstOrDefault();
                xmaster.ClientMaster_ID = SaveMaster.ClientMaster_ID;
                xmaster.ClientStatusID = SaveMaster.ClientStatusID;
                xmaster.UniqueID = SaveMaster.UniqueID;
                xmaster.Name_Title = SaveMaster.Name_Title;
                xmaster.Name_First  = SaveMaster.Name_First;
                xmaster.Name_Last  = SaveMaster.Name_Last;
                xmaster.Name_Initials  = SaveMaster.Name_Initials;
                xmaster.Name_Preferred  = SaveMaster.Name_Preferred;
                xmaster.Date_Birth = (DateTime)SaveMaster.Date_Birth;
                xmaster.REF_Identity  = SaveMaster.REF_Identity;
                xmaster.REF_Practitioner  = SaveMaster.REF_Practitioner;
                xmaster.REF_Practice  = SaveMaster.REF_Practice;
                xmaster.REF_Registered_Name  = SaveMaster.REF_Registered_Name;
                xmaster.REF_Registration_Number  = SaveMaster.REF_Registration_Number;
                xmaster.REF_VAT  = SaveMaster.REF_VAT;
                xmaster.Contact_Email = SaveMaster.Contact_Email;
                xmaster.Contact_Mobile  = SaveMaster.Contact_Mobile;
                xmaster.Contact_Practice1  = SaveMaster.Contact_Practice1;
                xmaster.Contact_Practice2  = SaveMaster.Contact_Practice2;
                xmaster.Contact_Home1  = SaveMaster.Contact_Home1;
                xmaster.Postal_Address_1A  = SaveMaster.Postal_Address_1A;
                xmaster.Postal_Address_1B  = SaveMaster.Postal_Address_1B;
                xmaster.Postal_Address_1C  = SaveMaster.Postal_Address_1C;
                xmaster.Postal_Address_1D  = SaveMaster.Postal_Address_1D;
                //Postal_Address_SuburbID  = (int)xclient.Postal_Address_SuburbID,
                xmaster.Postal_Address_1E = SaveMaster.Postal_Address_1E;
                //Postal_Address_CityID = (int)xclient.Postal_Address_CityID,
                xmaster.Postal_Address_1F  = SaveMaster.Postal_Address_1F;
                xmaster.Postal_Address_1G  = SaveMaster.Postal_Address_1G;
                xmaster.Practice_Address_1A  = SaveMaster.Practice_Address_1A;
                xmaster.Practice_Address_1B  = SaveMaster.Practice_Address_1B;
                xmaster.Practice_Address_1C  = SaveMaster.Practice_Address_1C;
                xmaster.Practice_Address_1D  = SaveMaster.Practice_Address_1D;
                //Practice_Address_SuburbID = (int)xclient.Practice_Address_SuburbID,
                xmaster.Practice_Address_1E  = SaveMaster.Practice_Address_1E;
                //Practice_Address_CityID = (int)xclient.Practice_Address_CityID,
                xmaster.Practice_Address_1F  = SaveMaster.Practice_Address_1F;
                xmaster.Practice_Address_1G  = SaveMaster.Practice_Address_1G;
                xmaster.Facility_Number = SaveMaster.Facility_Number;
                xmaster.Facility_Location = SaveMaster.Facility_Location;
                xmaster.InitialKey  = SaveMaster.InitialKey;
                xmaster.RequiresPasswordChange = SaveMaster.RequiresPasswordChange;
                xmaster.ProviderUserKey  = SaveMaster.ProviderUserKey;
                db.SubmitChanges();
            }
            return true;
        }
    }
}
