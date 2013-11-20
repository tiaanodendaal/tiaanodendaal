using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM_Forms.DAL;

namespace NM_Forms.BL
{
    public class Titles
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }


        public static List<Titles> GetAll()
        {
            List<Titles> TitlesList = new List<Titles>();
            DAL_Titles xDal = new DAL_Titles();
            foreach (var xclient in xDal.getAll())
            {
                TitlesList.Add(
                    new BL.Titles
                    {
                        TitleID = xclient.TitleID,
                        TitleName = xclient.TitleName
                    }
                );
            }

            return TitlesList.ToList();
        }


        public bool Save()
        {
            DAL_Titles xMaster = new DAL_Titles();
            DAL.Title saveTitle = new DAL.Title
            {
                TitleID = this.TitleID,
                TitleName = this.TitleName
            };
            return xMaster.Save(saveTitle);
        }        
    }

}
