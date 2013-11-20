using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class Business_Disciplines
    {
        public int Business_Discipline_ID { get; set; }
        public int Businesstype_ID { get; set; }
        public string Business_Discipline_Name { get; set; }

        public static List<Business_Disciplines> GetAll()
        {
            List<Business_Disciplines> BT_List = new List<Business_Disciplines>();
            DAL_Business_Disciplines xDal = new DAL_Business_Disciplines();
            List<DAL.Business_Discipline> xList = xDal.getAll();
            foreach (var bt in xList)
            {
                BT_List.Add(
                    new Business_Disciplines
                    {
                        Business_Discipline_ID = bt.Business_Discipline_ID,
                        Businesstype_ID = bt.Businesstype_ID,
                        Business_Discipline_Name = bt.Business_Discipline_Name
                    }
                    );
            }

            return BT_List;
        }

        public static Business_Disciplines get(int DisciplineID)
        {
            DAL_Business_Disciplines xDal = new DAL_Business_Disciplines();
            DAL.Business_Discipline xItem = xDal.get(DisciplineID);
            return new Business_Disciplines
            {
                Business_Discipline_ID = xItem.Business_Discipline_ID,
                Businesstype_ID = xItem.Businesstype_ID,
                Business_Discipline_Name = xItem.Business_Discipline_Name
            };
        }

        public static Business_Disciplines get(int DisciplineID, int BTypeID )
        {
            DAL_Business_Disciplines xDal = new DAL_Business_Disciplines();
            DAL.Business_Discipline xItem = xDal.get(DisciplineID, BTypeID);
            return new Business_Disciplines
            {
                Business_Discipline_ID = xItem.Business_Discipline_ID,
                Businesstype_ID = xItem.Businesstype_ID,
                Business_Discipline_Name = xItem.Business_Discipline_Name
            };
        }
    }
}
