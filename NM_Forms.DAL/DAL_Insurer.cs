using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{
    public class DAL_Insurer
    {
        NadMedDataContext db = new NadMedDataContext();

        public List<Insurer> getAll()
        {
            List<Insurer> CL_List = new List<Insurer>();
            var CLList = from cli in db.Insurers
                         orderby cli.Insurer_Name
                         select cli;
            return CLList.ToList();
        }

        public Insurer get(int InsID)
        {
            var CLListItem = db.Insurers.SingleOrDefault(p => p.Insurer_ID == InsID);
            return CLListItem;
        }


        public bool Save(Insurer SaveItem)
        {
            if (SaveItem.Insurer_ID == 0)
            {
                db.Insurers.InsertOnSubmit(SaveItem);
                db.SubmitChanges();
            }
            else
            {
                Insurer xmaster = (from cm in db.Insurers
                                   where cm.Insurer_ID == SaveItem.Insurer_ID
                                 select cm).FirstOrDefault();

                xmaster.Insurer_Name = SaveItem.Insurer_Name;
                xmaster.Wording = SaveItem.Wording;
                xmaster.ActiveYN = SaveItem.ActiveYN;
                db.SubmitChanges();
            }
            return true;
        }
    }
}
