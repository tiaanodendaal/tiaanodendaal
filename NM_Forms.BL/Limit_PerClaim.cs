using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class Limit_PerClaim
    {
        public int Limit_PerClaim_ID { get; set; }
        public string Limit_PerClaimDetails { get; set; }

        public static List<Limit_PerClaim> GetAll()
        {
            List<Limit_PerClaim> TitlesList = new List<Limit_PerClaim>();
            DAL_Limit_PerClaim xDal = new DAL_Limit_PerClaim();
            foreach (var xclient in xDal.getAll())
            {
                TitlesList.Add(
                    new BL.Limit_PerClaim
                    {
                        Limit_PerClaim_ID = xclient.Limit_PerClaim_ID,
                        Limit_PerClaimDetails = xclient.Limit_PerClaim1
                    }
                );
            }

            return TitlesList.ToList();
        }


        public bool Save()
        {
            DAL_Limit_PerClaim xMaster = new DAL_Limit_PerClaim();
            DAL.Limit_PerClaim saveTitle = new DAL.Limit_PerClaim
            {
                Limit_PerClaim_ID = this.Limit_PerClaim_ID,
                Limit_PerClaim1 = this.Limit_PerClaimDetails
            };
            return xMaster.Save(saveTitle);
        }        
    }
}
