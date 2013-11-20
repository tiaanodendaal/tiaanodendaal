using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{    

    public class DAL_BusinessTypes
    {
        NadMedDataContext db = new NadMedDataContext();

        public List<Businesstype> getAll()
        {
            var BTList = from qr in db.Businesstypes
                         orderby qr.Businesstype_Name
                         select qr;

            return BTList.ToList();
        }

        public Businesstype get(int BT_ID)
        {
            var BTList = db.Businesstypes.SingleOrDefault(p => p.Businesstype_ID == BT_ID);
            return BTList;
        }
    }
}
