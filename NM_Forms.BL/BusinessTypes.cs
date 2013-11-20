using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class BusinessTypes
    {
        public int Businesstype_ID { get; set; }
        public string Businesstype_Name { get; set; }

        public static List<BusinessTypes> GetAll()
        {
            List<BusinessTypes> BT_List = new List<BusinessTypes>();
            DAL_BusinessTypes xDal = new DAL_BusinessTypes();
            List<DAL.Businesstype> xList = xDal.getAll();
            foreach (var bt in xList)
            {
                BT_List.Add(
                    new BusinessTypes
                    {
                        Businesstype_ID = bt.Businesstype_ID,
                        Businesstype_Name = bt.Businesstype_Name
                    }
                    );
            }

            return BT_List;
        }

        public static BusinessTypes get(int BTypeID)
        {
            DAL_BusinessTypes xDal = new DAL_BusinessTypes();
            DAL.Businesstype xItem =  xDal.get(BTypeID);
            return new BusinessTypes
                    {
                        Businesstype_ID = xItem.Businesstype_ID,
                        Businesstype_Name = xItem.Businesstype_Name
                    };
        }
    }
}
