using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;


namespace NM_Forms.BL
{
    public class ClientMaster
    {
        public int ClientMaster_ID { get; set; }
        public Guid UniqueID { get; set; }
        public int ClientStatusID { get; set; }
        public string Name_Title { get; set; }
        public string Name_First { get; set; }
        public string Name_Last { get; set; }
        public string Name_Initials { get; set; }
        public string Name_Preferred { get; set; }
        public DateTime Date_Birth { get; set; }
        public string REF_Identity { get; set; }
        public string REF_Practitioner { get; set; }
        public string REF_Practice { get; set; }
        public string REF_Registered_Name { get; set; }
        public string REF_Registration_Number { get; set; }
        public string REF_VAT { get; set; }
        public string Contact_Email { get; set; }
        public string Contact_Mobile { get; set; }
        public string Contact_Practice1 { get; set; }
        public string Contact_Practice2 { get; set; }
        public string Contact_Home1 { get; set; }
        public string Postal_Address_1A { get; set; }
        public string Postal_Address_1B { get; set; }
        public string Postal_Address_1C { get; set; }
        public string Postal_Address_1D { get; set; }
        public int Postal_Address_SuburbID { get; set; }
        public string Postal_Address_1E { get; set; }
        public int Postal_Address_CityID { get; set; }
        public string Postal_Address_1F { get; set; }
        public string Postal_Address_1G { get; set; }
        public string Practice_Address_1A { get; set; }
        public string Practice_Address_1B { get; set; }
        public string Practice_Address_1C { get; set; }
        public string Practice_Address_1D { get; set; }
        public int Practice_Address_SuburbID { get; set; }
        public string Practice_Address_1E { get; set; }
        public int Practice_Address_CityID { get; set; }
        public string Practice_Address_1F { get; set; }
        public string Practice_Address_1G { get; set; }
        public string Facility_Number { get; set; }
        public string Facility_Location { get; set; }
        public string InitialKey { get; set; }
        public bool RequiresPasswordChange { get; set; }
        public string ProviderUserKey { get; set; }

        public static List<ClientMaster> GetAll()
        {
            List<ClientMaster> ClientMasters = new List<ClientMaster>();
            DAL_ClientMaster xDal = new DAL_ClientMaster();
            foreach (var xclient in xDal.getAll())
            {
                ClientMasters.Add(
                    new ClientMaster
                    {
                        ClientMaster_ID = xclient.ClientMaster_ID,
                        UniqueID = xclient.UniqueID,
                        ClientStatusID = xclient.ClientStatusID,
                        Name_Title = xclient.Name_Title,
                        Name_First  = xclient.Name_First,
                        Name_Last  = xclient.Name_Last,
                        Name_Initials  = xclient.Name_Initials,
                        Name_Preferred  = xclient.Name_Preferred,
                        Date_Birth  = (DateTime)xclient.Date_Birth,
                        REF_Identity  = xclient.REF_Identity,
                        REF_Practitioner  = xclient.REF_Practitioner,
                        REF_Practice  = xclient.REF_Practice,
                        REF_Registered_Name  = xclient.REF_Registered_Name,
                        REF_Registration_Number  = xclient.REF_Registration_Number,
                        REF_VAT  = xclient.REF_VAT,
                        Contact_Email = xclient.Contact_Email,
                        Contact_Mobile  = xclient.Contact_Mobile,
                        Contact_Practice1  = xclient.Contact_Practice1,
                        Contact_Practice2  = xclient.Contact_Practice2,
                        Contact_Home1  = xclient.Contact_Home1,
                        Postal_Address_1A  = xclient.Postal_Address_1A,
                        Postal_Address_1B  = xclient.Postal_Address_1B,
                        Postal_Address_1C  = xclient.Postal_Address_1C,
                        Postal_Address_1D  = xclient.Postal_Address_1D,
                        //Postal_Address_SuburbID  = (int)xclient.Postal_Address_SuburbID,
                        Postal_Address_1E  = xclient.Postal_Address_1E,
                        //Postal_Address_CityID = (int)xclient.Postal_Address_CityID,
                        Postal_Address_1F  = xclient.Postal_Address_1F,
                        Postal_Address_1G  = xclient.Postal_Address_1G,
                        Practice_Address_1A  = xclient.Practice_Address_1A,
                        Practice_Address_1B  = xclient.Practice_Address_1B,
                        Practice_Address_1C  = xclient.Practice_Address_1C,
                        Practice_Address_1D  = xclient.Practice_Address_1D,
                        //Practice_Address_SuburbID = (int)xclient.Practice_Address_SuburbID,
                        Practice_Address_1E  = xclient.Practice_Address_1E,
                        //Practice_Address_CityID = (int)xclient.Practice_Address_CityID,
                        Practice_Address_1F  = xclient.Practice_Address_1F,
                        Practice_Address_1G  = xclient.Practice_Address_1G,
                        Facility_Number = xclient.Facility_Number,
                        Facility_Location = xclient.Facility_Location,
                        InitialKey  = xclient.InitialKey,
                        RequiresPasswordChange = xclient.RequiresPasswordChange,
                        ProviderUserKey  = xclient.ProviderUserKey
                    }
                );
            }

            return ClientMasters.ToList();
        }

        public static ClientMaster Get(int CM_ID)
        {
            DAL_ClientMaster xMaster = new DAL_ClientMaster();
            DAL.ClientMaster xclient = xMaster.get(CM_ID);
            ClientMaster EClient = new ClientMaster
                    {
                        ClientMaster_ID = xclient.ClientMaster_ID,
                        UniqueID = xclient.UniqueID,
                        ClientStatusID = xclient.ClientStatusID,
                        Name_Title = xclient.Name_Title,
                        Name_First = xclient.Name_First,
                        Name_Last = xclient.Name_Last,
                        Name_Initials = xclient.Name_Initials,
                        Name_Preferred = xclient.Name_Preferred,
                        Date_Birth  = (DateTime)xclient.Date_Birth,
                        REF_Identity = xclient.REF_Identity,
                        REF_Practitioner = xclient.REF_Practitioner,
                        REF_Practice = xclient.REF_Practice,
                        REF_Registered_Name = xclient.REF_Registered_Name,
                        REF_Registration_Number = xclient.REF_Registration_Number,
                        REF_VAT = xclient.REF_VAT,
                        Contact_Email = xclient.Contact_Email,
                        Contact_Mobile = xclient.Contact_Mobile,
                        Contact_Practice1 = xclient.Contact_Practice1,
                        Contact_Practice2 = xclient.Contact_Practice2,
                        Contact_Home1 = xclient.Contact_Home1,
                        Postal_Address_1A = xclient.Postal_Address_1A,
                        Postal_Address_1B = xclient.Postal_Address_1B,
                        Postal_Address_1C = xclient.Postal_Address_1C,
                        Postal_Address_1D = xclient.Postal_Address_1D,
                        //Postal_Address_SuburbID  = (int)xclient.Postal_Address_SuburbID,
                        Postal_Address_1E = xclient.Postal_Address_1E,
                        //Postal_Address_CityID = (int)xclient.Postal_Address_CityID,
                        Postal_Address_1F = xclient.Postal_Address_1F,
                        Postal_Address_1G = xclient.Postal_Address_1G,
                        Practice_Address_1A = xclient.Practice_Address_1A,
                        Practice_Address_1B = xclient.Practice_Address_1B,
                        Practice_Address_1C = xclient.Practice_Address_1C,
                        Practice_Address_1D = xclient.Practice_Address_1D,
                        //Practice_Address_SuburbID = (int)xclient.Practice_Address_SuburbID,
                        Practice_Address_1E = xclient.Practice_Address_1E,
                        //Practice_Address_CityID = (int)xclient.Practice_Address_CityID,
                        Practice_Address_1F = xclient.Practice_Address_1F,
                        Practice_Address_1G = xclient.Practice_Address_1G,
                        Facility_Number = xclient.Facility_Number,
                        Facility_Location = xclient.Facility_Location,
                        InitialKey = xclient.InitialKey,
                        RequiresPasswordChange = xclient.RequiresPasswordChange,
                        ProviderUserKey = xclient.ProviderUserKey
                    };
            return EClient;
        }

        public static ClientMaster GetByUsername(string IDRef)
        {
            DAL_ClientMaster xMaster = new DAL_ClientMaster();
            DAL.ClientMaster xclient = xMaster.getbyID(IDRef);
            ClientMaster EClient = new ClientMaster
            {
                ClientMaster_ID = xclient.ClientMaster_ID,
                UniqueID = xclient.UniqueID,
                ClientStatusID = xclient.ClientStatusID,
                Name_Title = xclient.Name_Title,
                Name_First = xclient.Name_First,
                Name_Last = xclient.Name_Last,
                Name_Initials = xclient.Name_Initials,
                Name_Preferred = xclient.Name_Preferred,
                Date_Birth = (DateTime)xclient.Date_Birth,
                REF_Identity = xclient.REF_Identity,
                REF_Practitioner = xclient.REF_Practitioner,
                REF_Practice = xclient.REF_Practice,
                REF_Registered_Name = xclient.REF_Registered_Name,
                REF_Registration_Number = xclient.REF_Registration_Number,
                REF_VAT = xclient.REF_VAT,
                Contact_Email = xclient.Contact_Email,
                Contact_Mobile = xclient.Contact_Mobile,
                Contact_Practice1 = xclient.Contact_Practice1,
                Contact_Practice2 = xclient.Contact_Practice2,
                Contact_Home1 = xclient.Contact_Home1,
                Postal_Address_1A = xclient.Postal_Address_1A,
                Postal_Address_1B = xclient.Postal_Address_1B,
                Postal_Address_1C = xclient.Postal_Address_1C,
                Postal_Address_1D = xclient.Postal_Address_1D,
                //Postal_Address_SuburbID  = (int)xclient.Postal_Address_SuburbID,
                Postal_Address_1E = xclient.Postal_Address_1E,
                //Postal_Address_CityID = (int)xclient.Postal_Address_CityID,
                Postal_Address_1F = xclient.Postal_Address_1F,
                Postal_Address_1G = xclient.Postal_Address_1G,
                Practice_Address_1A = xclient.Practice_Address_1A,
                Practice_Address_1B = xclient.Practice_Address_1B,
                Practice_Address_1C = xclient.Practice_Address_1C,
                Practice_Address_1D = xclient.Practice_Address_1D,
                //Practice_Address_SuburbID = (int)xclient.Practice_Address_SuburbID,
                Practice_Address_1E = xclient.Practice_Address_1E,
                //Practice_Address_CityID = (int)xclient.Practice_Address_CityID,
                Practice_Address_1F = xclient.Practice_Address_1F,
                Practice_Address_1G = xclient.Practice_Address_1G,
                Facility_Number = xclient.Facility_Number,
                Facility_Location = xclient.Facility_Location,
                InitialKey = xclient.InitialKey,
                RequiresPasswordChange = xclient.RequiresPasswordChange,
                ProviderUserKey = xclient.ProviderUserKey
            };
            return EClient;
        }


        public static ClientMaster GetByUniqueID(Guid UniqueID)
        {
            DAL_ClientMaster xMaster = new DAL_ClientMaster();
            DAL.ClientMaster xclient = xMaster.getbyID(UniqueID);
            ClientMaster EClient = new ClientMaster
            {
                ClientMaster_ID = xclient.ClientMaster_ID,
                UniqueID = xclient.UniqueID,
                ClientStatusID = xclient.ClientStatusID,
                Name_Title = xclient.Name_Title,
                Name_First = xclient.Name_First,
                Name_Last = xclient.Name_Last,
                Name_Initials = xclient.Name_Initials,
                Name_Preferred = xclient.Name_Preferred,
                Date_Birth = (DateTime)xclient.Date_Birth,
                REF_Identity = xclient.REF_Identity,
                REF_Practitioner = xclient.REF_Practitioner,
                REF_Practice = xclient.REF_Practice,
                REF_Registered_Name = xclient.REF_Registered_Name,
                REF_Registration_Number = xclient.REF_Registration_Number,
                REF_VAT = xclient.REF_VAT,
                Contact_Email = xclient.Contact_Email,
                Contact_Mobile = xclient.Contact_Mobile,
                Contact_Practice1 = xclient.Contact_Practice1,
                Contact_Practice2 = xclient.Contact_Practice2,
                Contact_Home1 = xclient.Contact_Home1,
                Postal_Address_1A = xclient.Postal_Address_1A,
                Postal_Address_1B = xclient.Postal_Address_1B,
                Postal_Address_1C = xclient.Postal_Address_1C,
                Postal_Address_1D = xclient.Postal_Address_1D,
                //Postal_Address_SuburbID  = (int)xclient.Postal_Address_SuburbID,
                Postal_Address_1E = xclient.Postal_Address_1E,
                //Postal_Address_CityID = (int)xclient.Postal_Address_CityID,
                Postal_Address_1F = xclient.Postal_Address_1F,
                Postal_Address_1G = xclient.Postal_Address_1G,
                Practice_Address_1A = xclient.Practice_Address_1A,
                Practice_Address_1B = xclient.Practice_Address_1B,
                Practice_Address_1C = xclient.Practice_Address_1C,
                Practice_Address_1D = xclient.Practice_Address_1D,
                //Practice_Address_SuburbID = (int)xclient.Practice_Address_SuburbID,
                Practice_Address_1E = xclient.Practice_Address_1E,
                //Practice_Address_CityID = (int)xclient.Practice_Address_CityID,
                Practice_Address_1F = xclient.Practice_Address_1F,
                Practice_Address_1G = xclient.Practice_Address_1G,
                Facility_Number = xclient.Facility_Number,
                Facility_Location = xclient.Facility_Location,
                InitialKey = xclient.InitialKey,
                RequiresPasswordChange = xclient.RequiresPasswordChange,
                ProviderUserKey = xclient.ProviderUserKey
            };
            return EClient;
        }

        public bool Delete()
        {
            return true;
        }

        public bool Save()
        {
            DAL_ClientMaster xMaster = new DAL_ClientMaster();
            DAL.ClientMaster saveMaster = new DAL.ClientMaster{
                    ClientMaster_ID = this.ClientMaster_ID,
                        UniqueID = this.UniqueID,
                        Name_Title = this.Name_Title,
                        Name_First  = this.Name_First,
                        Name_Last  = this.Name_Last,
                        Name_Initials  = this.Name_Initials,
                        Name_Preferred  = this.Name_Preferred,
                        Date_Birth = (DateTime)this.Date_Birth,
                        REF_Identity  = this.REF_Identity,
                        REF_Practitioner  = this.REF_Practitioner,
                        REF_Practice  = this.REF_Practice,
                        REF_Registered_Name  = this.REF_Registered_Name,
                        REF_Registration_Number  = this.REF_Registration_Number,
                        REF_VAT  = this.REF_VAT,
                        Contact_Email = this.Contact_Email,
                        Contact_Mobile  = this.Contact_Mobile,
                        Contact_Practice1  = this.Contact_Practice1,
                        Contact_Practice2  = this.Contact_Practice2,
                        Contact_Home1  = this.Contact_Home1,
                        Postal_Address_1A  = this.Postal_Address_1A,
                        Postal_Address_1B  = this.Postal_Address_1B,
                        Postal_Address_1C  = this.Postal_Address_1C,
                        Postal_Address_1D  = this.Postal_Address_1D,
                        //Postal_Address_SuburbID  = (int)xclient.Postal_Address_SuburbID,
                        Postal_Address_1E  = this.Postal_Address_1E,
                        //Postal_Address_CityID = (int)xclient.Postal_Address_CityID,
                        Postal_Address_1F  = this.Postal_Address_1F,
                        Postal_Address_1G  = this.Postal_Address_1G,
                        Practice_Address_1A  = this.Practice_Address_1A,
                        Practice_Address_1B  = this.Practice_Address_1B,
                        Practice_Address_1C  = this.Practice_Address_1C,
                        Practice_Address_1D  = this.Practice_Address_1D,
                        //Practice_Address_SuburbID = (int)xclient.Practice_Address_SuburbID,
                        Practice_Address_1E  = this.Practice_Address_1E,
                        //Practice_Address_CityID = (int)xclient.Practice_Address_CityID,
                        Practice_Address_1F  = this.Practice_Address_1F,
                        Practice_Address_1G  = this.Practice_Address_1G,
                        Facility_Number = this.Facility_Number,
                        Facility_Location = this.Facility_Location,
                        InitialKey  = this.InitialKey,
                        RequiresPasswordChange = this.RequiresPasswordChange,
                        ProviderUserKey  = this.ProviderUserKey,
                        ClientStatusID = this.ClientStatusID
                };
            return xMaster.Save(saveMaster);
        }        
    }
}
