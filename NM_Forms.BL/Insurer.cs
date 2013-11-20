using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class Insurer
    {
        public int Insurer_ID { get; set; }
        public string Insurer_Name { get; set; }
        public string Wording { get; set; }
        public bool ActiveYN { get; set; }


        public static List<Insurer> GetAll()
        {
            List<Insurer> iList = new List<Insurer>();
            DAL_Insurer xDal = new DAL_Insurer();
            foreach (var xclient in xDal.getAll())
            {
                iList.Add(
                    new BL.Insurer
                    {
                        Insurer_ID = xclient.Insurer_ID,
                        Insurer_Name = xclient.Insurer_Name,
                        Wording = xclient.Wording,
                        ActiveYN = xclient.ActiveYN
                    }
                );
            }

            return iList.ToList();
        }

        public static Insurer get(int InsID)
        {
            DAL_Insurer xDal = new DAL_Insurer();
            DAL.Insurer xInsDal = xDal.get(InsID);
            Insurer xIns = new Insurer
            {
                ActiveYN = xInsDal.ActiveYN,
                Insurer_ID = xInsDal.Insurer_ID,
                Insurer_Name = xInsDal.Insurer_Name,
                Wording = xInsDal.Wording
            };
            return xIns;
        }


        public bool Save()
        {
            DAL_Insurer xMaster = new DAL_Insurer();
            DAL.Insurer saveItem = new DAL.Insurer
            {
                Insurer_ID = this.Insurer_ID,
                Insurer_Name = this.Insurer_Name,
                Wording = this.Wording,
                ActiveYN = this.ActiveYN
            };
            return xMaster.Save(saveItem);
        }        
    }
}
