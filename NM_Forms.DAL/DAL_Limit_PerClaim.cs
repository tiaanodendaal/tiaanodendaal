using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{
    public class DAL_Limit_PerClaim
    {
        NadMedDataContext db = new NadMedDataContext();

        public List<Limit_PerClaim> getAll()
        {
            List<Title> CL_List = new List<Title>();
            var CLList = from cli in db.Limit_PerClaims
                         orderby cli.Limit_PerClaim1
                         select cli;
            return CLList.ToList();
        }


        public bool Save(Limit_PerClaim NewLimit)
        {
            if (NewLimit.Limit_PerClaim_ID == 0)
            {                
                Limit_PerClaim xclaim = new Limit_PerClaim
                {
                    Limit_PerClaim1 = NewLimit.Limit_PerClaim1,
                    ActiveYN = true
                };
                db.Limit_PerClaims.InsertOnSubmit(xclaim);
                db.SubmitChanges();
            }
            else
            {
                Limit_PerClaim xmaster = (from cm in db.Limit_PerClaims
                                 where cm.Limit_PerClaim_ID == NewLimit.Limit_PerClaim_ID
                                 select cm).FirstOrDefault();

                xmaster.Limit_PerClaim1 = NewLimit.Limit_PerClaim1;
                db.SubmitChanges();
            }
            return true;
        }
    }
}
