using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{
    public class DAL_Business_Disciplines
    {
        NadMedDataContext db = new NadMedDataContext();

        public List<Business_Discipline> getAll()
        {
            var BTList = from qr in db.Business_Disciplines
                         orderby qr.Business_Discipline_Name
                         select qr;

            return BTList.ToList();
        }

        public Business_Discipline get(int BDisciplineID)
        {
            var BTList = db.Business_Disciplines.SingleOrDefault(p => p.Business_Discipline_ID == BDisciplineID);
            return BTList;
        }

        public Business_Discipline get(int BDisciplineID, int BTypeID)
        {
            var BTList = db.Business_Disciplines.SingleOrDefault(p => p.Business_Discipline_ID == BDisciplineID && p.Businesstype_ID == BTypeID);
            return BTList;
        }
    }
}
